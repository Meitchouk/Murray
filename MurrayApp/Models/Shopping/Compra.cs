using Models.Interfaces;
using System;

namespace Models.Shopping
{
    /// <summary>
    ///     Transacción de compra de elementos
    /// </summary>
    public class Compra : IIdentity, ITransacction
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="ITransacction.Fecha"/>
        public DateTime Fecha { get; set; }

        #region Foreing Key

        /// <summary>
        ///     Id del proveedor involucrado en la compra
        /// </summary>
        public int IdProveedor { get; set; }

        /// <inheritdoc cref="ITransacction.IdEmpleado"/>
        public int IdEmpleado { get; set; }

        #endregion
    }
}
