using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    //Implementación de la interfaz IDepartamentoDao
    internal class DepartamentoDao : BaseDao<Departamento>, IDepartamentoDao
    {
        #region Constructors

        /// <summary>
        /// Construye una nueva instancia de DepartamentoDao.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos de SQL.</param>
        /// <param name="handler">Manejador de errores.</param>
        public DepartamentoDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Crea un nuevo departamento en la base de datos.
        /// </summary>
        /// <param name="model">Modelo del departamento a crear.</param>
        /// <returns>El departamento creado o un objeto vacío si no se creó exitosamente.</returns>
        public override Departamento Create(Departamento model)
        {
            if (Validate(model, Operation.CREATE))
                return new Departamento();

            //Llama al procedimiento almacenado DepartamentoCreate para crear el departamento.
            return Read(StoredProcedures.DepartamentoCreate, new Dictionary<string, object>
            {
                ["Nombre"] = model.Nombre
            })
            .FirstOrDefault() ?? new Departamento();
        }

        /// <summary>
        /// Elimina un departamento de la base de datos.
        /// </summary>
        /// <param name="id">ID del departamento a eliminar.</param>
        /// <returns>El departamento eliminado o un objeto vacío si no se eliminó exitosamente.</returns>
        public override Departamento Delete(int id)
        {
            //Llama al procedimiento almacenado DepartamentoDelete para eliminar el departamento.
            return Read(StoredProcedures.DepartamentoDelete, new Dictionary<string, object>
            {
                ["Id"] = id
            })
            .FirstOrDefault() ?? new Departamento();
        }

        /// <summary>
        /// Lee todos los departamentos en la base de datos.
        /// </summary>
        /// <returns>Lista de todos los departamentos.</returns>
        public override IEnumerable<Departamento> Read()
        {
            return Read(string.Empty);
        }

        /// <summary>
        /// Busca departamentos en la base de datos por nombre.
        /// </summary>
        /// <param name="nombre">Nombre del departamento a buscar.</param>
        /// <returns>Una lista de departamentos.</returns>
        public IEnumerable<Departamento> Read(string nombre)
        {
            //Llama al procedimiento almacenado DepartamentoGet para leer los departamentos con el mismo nombre.
            return Read(StoredProcedures.DepartamentoGet, new Dictionary<string, object>
            {
                ["Nombre"] = nombre
            });
        }

        /// <summary>
        /// Actualiza un departamento existente en la base de datos.
        /// </summary>
        /// <param name="id">ID del departamento a actualizar.</param>
        /// <param name="model">El modelo actualizado del departamento.</param>
        /// <returns>El departamento actualizado o un objeto vacío si la actualización falló.</returns>
        public override Departamento Update(int id, Departamento model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Departamento();

            //Llama al procediminto almacenado DepartamentoUpdate para actualizar el departamento.
            return Read(StoredProcedures.DepartamentoUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Nombre"] = model.Nombre
            })
            .FirstOrDefault() ?? new Departamento();
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Realiza validaciones específicas al modelo de un departamento.
        /// </summary>
        /// <param name="model">El modelo a validar.</param>
        /// <param name="operation">La operación que se está realizando.</param>
        /// <returns>True si hay errores, False si no.</returns>
        private bool Validate(Departamento model, Operation operation)
        {
            //Realiza validaciones genéricas al modelo, como asegurarse que no sea nulo.
            if (Validations.Validate(model, Handler, operation))
                return false;

            //Verifica que el nombre del departamento no sea demasiado largo.
            if (model.Nombre.Length > 50)
                Handler.Add("NOMBRE_LENGTH_EXCEED");

            //Retorna True si hay errores, False si no.
            return Handler.HasError();
        }

        #endregion
    }
}
