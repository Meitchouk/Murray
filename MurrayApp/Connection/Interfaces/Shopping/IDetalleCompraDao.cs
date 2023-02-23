using Connection.Base;
using Models.Shopping;
using System.Collections.Generic;

namespace Connection.Interfaces.Shopping
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto DetalleCompra
    /// </summary>
    public interface IDetalleCompraDao : IDao<DetalleCompra>
    {
        /// <summary>
        ///     Obtiene los detalles de una compra
        /// </summary>
        /// <param name="id">
        ///     Id de la compra a obtener detalles
        /// </param>=
        IEnumerable<DetalleCompra> GetByCompraId(int id);
    }
}
