using System;
using System.Collections.Generic;

namespace Connection.Base
{
    /// <summary>
    ///     Comportamiento de un conexion de un objeto
    /// </summary>
    /// <typeparam name="TModel">
    ///     Modelo a obtener informacion
    /// </typeparam>
    public interface IDao<TModel> : IDisposable
    {
        #region CRUD

        /// <summary>
        ///     Creacion de un nuevo modelo
        /// </summary>
        /// <param name="model">
        ///     Modelo a crear
        /// </param>
        TModel Create(TModel model);

        /// <summary>
        ///     Lectura de resgistros de un modelo
        /// </summary>=
        IEnumerable<TModel> Read();

        /// <summary>
        ///     Actualiza un modelo
        /// </summary>
        /// <param name="id">
        ///     Id del registro a actualizar
        /// </param>
        /// <param name="model">
        ///     Valores del modelo a actualizar
        /// </param>
        TModel Update(int id, TModel model);

        /// <summary>
        ///     Elimina un modelo
        /// </summary>
        /// <param name="id">
        ///     Id del modelo a eliminar
        /// </param>
        TModel Delete(int id);

        #endregion
    }
}
