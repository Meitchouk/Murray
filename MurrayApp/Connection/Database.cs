using Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Connection
{
    /// <summary>
    /// Clase encargada de realiza la lectura utilizando procedimientos de almacenado
    /// </summary>
    internal sealed class Database
    {
        #region Private Fields

        /// <summary>
        /// Cadena de conexion a la base de datos
        /// </summary>
        private readonly string ConnectionString;

        /// <summary>
        /// Administrador de errores
        /// </summary>
        private readonly ErrorHandler Handler;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Database(string connectionString, ErrorHandler handler)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Cadena de conexión no especificada");

            ConnectionString = connectionString;
            Handler = handler;
        }

        #endregion

        /// <summary>
        /// Realiza la ejecucion de un procedimiento de almacenado
        /// </summary>
        public IEnumerable<TResult> Read<TResult>(string procedure, IDictionary<string, object> parameters = null) where TResult : new()
        {
            // Verifica si existe el nombre del procedimiento de almacenado
            if (string.IsNullOrEmpty(procedure))
                throw new NullReferenceException("Nombre del procedimiento de almacenado no especificado");

            if (parameters is null)
                parameters = new Dictionary<string, object>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    // Si no establece conexión con la base de datos lanza una ArgumentException
                    throw new ArgumentException("No se pudo establecer conexión con la base de datos");
                }

                using (var sql = new SqlCommand(procedure, connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 20
                })
                {
                    // Deriva los parámetros y los agrega al comando SQL
                    SqlCommandBuilder.DeriveParameters(sql);

                    foreach (SqlParameter parameter in sql.Parameters)
                    {
                        // Evalúa si el diccionario de parámetros contiene el nombre del parámetro SQL y su valor
                        parameters.TryGetValue(RemoveAtSign(parameter.ParameterName), out var value);
                        parameter.Value = value is null ? DBNull.Value : value;
                    }

                    try
                    {
                        // Ejecuta el procedimiento de almacenado y mapea el resultado a un objeto del tipo TResult
                        var reader = sql.ExecuteReader();
                        return MapToObject<TResult>(reader).ToArray();
                    }
                    catch (SqlException sqlex)
                    {
                        // Agrega una excepción de SqlException al controlador de eventos de errores y retorna Enumerable.Empty<TResult>()
                        Handler.Add(sqlex);
                        return Enumerable.Empty<TResult>();
                    }
                    catch
                    {
                        // Agrega "UNKNOWN_ERROR" al controlador de eventos de errores y retorna Enumerable.Empty<TResult>()
                        Handler.Add("UNKNOWN_ERROR");
                        return Enumerable.Empty<TResult>();
                    }
                }
            }
        }

        #region Private Methods

        /// <summary>
        /// Realiza el mapping del resultado de la ejecución del procedimiento de almacenado a un tipo en específico
        /// </summary>
        private static IEnumerable<TResult> MapToObject<TResult>(IDataReader reader) where TResult : new()
        {
            var type = typeof(TResult);

            while (reader.Read())
            {
                var instance = new TResult();
                // Ciclo for que recorre los campos leídos y los asigna a las propiedades correspondientes del objeto nuevo "instance"
                for (int index = 0; index < reader.FieldCount; index++)
                {
                    var name = reader.GetName(index);
                    var property = type.GetProperty(name);

                    if (property is null) continue;

                    var value = reader.IsDBNull(index) ? null : reader.GetValue(index);

                    // Evalúa si el valor es decimal y si el tipo de propiedad es double, convierte el valor a double
                    if (value is decimal && property.PropertyType == typeof(double))
                        value = Convert.ToDouble(value);

                    // Evalúa si el valor es double y si el tipo de propiedad es decimal, convierte el valor a decimal
                    if (value is double && property.PropertyType == typeof(decimal))
                        value = Convert.ToDecimal(value);

                    // Asigna el valor resultante a la propiedad correspondiente
                    property.SetValue(instance, value);
                }

                yield return instance;
            }
        }

        /// <summary>
        /// Remueve primer caracter, suponiendo que es un arroba
        /// </summary>
        /// <param name="val">
        ///     Valor a alterar
        /// </param>
        private static string RemoveAtSign(string val) => val.Substring(1);

        #endregion
    }
}

