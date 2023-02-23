using Connection.Base;
using Models.Common;

using System.Collections.Generic;

namespace Connection.Interfaces.Common
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Producto
    /// </summary>
    public interface IProductoDao : IDao<Producto>
    {
        /// <summary>
        ///     Busca un producto por Id
        /// </summary>
        /// <param name="id">
        ///     Id del producto
        /// </param>
        /// <returns></returns>
        Producto GetById(int id);

        /// <summary>
        ///     Busca todos los productos en la base de datos
        /// </summary>
        /// <param name="value">
        ///     Busca productos con el valor como filtro
        /// </param>
        /// <returns>
        ///     Lista de productos con coincidencia en el filtro
        /// </returns>
        IEnumerable<Producto> Read(string value);
    }
}
