using Common.Util;
using System;
using System.Collections.Generic;

namespace Connection.Base
{
    /// <summary>
    ///     Implementacion base del acceso de un objeto
    /// </summary>
    /// <typeparam name="TModel">
    ///     Modelo del objeto
    /// </typeparam>
    internal abstract class BaseDao<TModel> : IDao<TModel> where TModel : new ()
    {
        #region Protected Fields

        /// <summary>
        ///     Servicio de conexion a base de datos
        /// </summary>
        protected readonly Database Connection;

        /// <summary>
        ///     Administrador de errores
        /// </summary>
        protected readonly ErrorHandler Handler;

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructir base
        /// </summary>
        public BaseDao(string connectionString, ErrorHandler handler)
        {
            Connection = new Database(connectionString, handler);
            Handler = handler;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>
        public abstract TModel Create(TModel model);

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public abstract TModel Delete(int id);

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public virtual void Dispose()
        {
            // Here should free common resources
        }

        /// <inheritdoc cref="IDao{TModel}.Read()"/>
        public abstract IEnumerable<TModel> Read();

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public abstract TModel Update(int id, TModel model);

        #endregion

        #region Protected Methods

        /// <inheritdoc cref="Database.Read{TResult}(string, IDictionary{string, object})"/>
        protected IEnumerable<TModel> Read(string procedure, IDictionary<string, object> parameters = null) => Connection.Read<TModel>(procedure, parameters);

        #endregion
    }
}
