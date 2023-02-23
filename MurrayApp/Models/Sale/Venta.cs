using Models.Interfaces;
using System;

namespace Models.Sale
{
    /// <summary>
    ///     Transacción de venta de elementos
    /// </summary>
    public class Venta : IIdentity, ITransacction
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="ITransacction.Fecha"/>
        public DateTime Fecha { get; set; }

        #region Foreing Key

        /// <summary>
        ///     Id del cliente involucrado en la venta
        /// </summary>
        public int IdCliente { get; set; }

        /// <inheritdoc cref="ITransacction.IdEmpleado"/>
        public int IdEmpleado { get; set; }

        #endregion
    }
}
