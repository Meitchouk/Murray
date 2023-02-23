using Connection.Base;
using Models.Sale;
using System.Collections.Generic;

namespace Connection.Interfaces.Sale
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Venta
    /// </summary>
    public interface IVentaDao : IDao<Venta>
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
        IEnumerable<Venta> Read(string query);

        /// <summary>
        ///     Obtiene venta por Id
        /// </summary>
        /// <param name="id">
        ///     Id de la venta
        /// </param>=
        Venta GetById(int id);
    }
}
