using Common.Util; //Librería externa agregada para que se utilice en este archivo
using System;
using System.Collections.Generic;

namespace Connection.Base //Se define el namespace de la clase
{
    /// <summary>
    /// Implementacion base del acceso de un objeto
    /// </summary>
     /// <typeparam name="TModel">
    /// Modelo del objeto
    /// </typeparam>
    internal abstract class BaseDao<TModel> : IDao<TModel> where TModel : new () //Se define la clase principal y que implementa la interfaz común IDao
    {
        #region Protected Fields

        /// <summary>
        /// Servicio de conexión a base de datos
        /// </summary>
        protected readonly Database Connection;

        /// <summary>
        /// Administrador de errores
        /// </summary>
        protected readonly ErrorHandler Handler;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructir base
        /// </summary>
        public BaseDao(string connectionString, ErrorHandler handler) //constructor con parametros 'connectionString' y 'handler'
        {
            Connection = new Database(connectionString, handler); //Establece la nueva conexión a la BD usando la cadena 'connectionString' y asignando el manejador de errores definido en 'handler'.
            Handler = handler; //Asigna la instancia atributos 'handler'
        }

        #endregion

        #region Public Methods

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>
        public abstract TModel Create(TModel model); //Método abstracto que crea nuevo modelo

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public abstract TModel Delete(int id); //Método abstracto que elimina un modelo por id.

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public virtual void Dispose() //Método virtual no abstracto, solo establece destructor para liberar recursos compartidos.
        {
            // Here should free common resources
        }

        /// <inheritdoc cref="IDao{TModel}.Read()"/>
        public abstract IEnumerable<TModel> Read(); //Método abstracto que lee todos los modelos

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public abstract TModel Update(int id, TModel model); //Método abstracto que actualiza un modelo por id y definición

        #endregion

        #region Protected Methods

        /// <inheritdoc cref="Database.Read{TResult}(string, IDictionary{string, object})"/>
        protected IEnumerable<TModel> Read(string procedure, IDictionary<string, object> parameters = null) => Connection.Read<TModel>(procedure, parameters);

        #endregion
    }
}
