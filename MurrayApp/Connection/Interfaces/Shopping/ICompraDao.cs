using Connection.Base;
using Models.Shopping;
using System.Collections.Generic;

namespace Connection.Interfaces.Shopping
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Compra
    /// </summary>
    public interface ICompraDao : IDao<Compra>
    {
        /// <summary>
        ///     Busca ventas que coincidan con un criterio de busqueda
        /// </summary>
        /// <param name="query">
        ///     Criterio de busqueda
        /// </param>
        /// <returns>
        ///     Lista de ventas que coincidan con el filtro
        /// </returns>
        IEnumerable<Compra> Read(string query);

        /// <summary>
        ///     Obtiene compra por Id
        /// </summary>
        /// <param name="id">
        ///     Id de la compra
        /// </param>=
        Compra GetById(int id);
    }
}
