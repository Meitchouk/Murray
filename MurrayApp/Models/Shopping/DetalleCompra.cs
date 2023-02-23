using Models.Interfaces;

namespace Models.Shopping
{
    /// <summary>
    ///     Elemento de compra
    /// </summary>
    public class DetalleCompra : IIdentity, ITransacctionDetail
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="ITransacctionDetail.Cantidad"/>
        public int Cantidad { get; set; }

        /// <inheritdoc cref="ITransacctionDetail.Precio"/>
        public double Precio { get; set; }

        /// <inheritdoc cref="ITransacctionDetail.Descuento"/>
        public double Descuento { get; set; }

        /// <inheritdoc cref="ITransacctionDetail.Subtotal"/>
        public double Subtotal => (Cantidad * Precio) - Descuento;

        #region Foreing Keys

        /// <inheritdoc cref="ITransacctionDetail.IdProducto"/>
        public int IdProducto { get; set; }

        /// <summary>
        ///     Id de la compra asociado detalle
        /// </summary>
        public int IdCompra { get; set; }

        #endregion
    }
}