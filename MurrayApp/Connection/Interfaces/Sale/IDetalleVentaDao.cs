using Connection.Base;
using Models.Sale;
using System.Collections.Generic;

namespace Connection.Interfaces.Sale
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto DetalleVenta
    /// </summary>
    public interface IDetalleVentaDao : IDao<DetalleVenta>
    {
        /// <summary>
        ///     Obtiene los detalles de una venta
        /// </summary>
        /// <param name="id">
        ///     Id de la venta a obtener detalles
        /// </param>=
        IEnumerable<DetalleVenta> GetByVentaId(int id);
    }
}
