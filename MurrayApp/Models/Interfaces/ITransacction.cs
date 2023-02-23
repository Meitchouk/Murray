using System;

namespace Models.Interfaces
{
    /// <summary>
    ///     Representa un movimiento transaccional del sistema, ya sea una venta o una compra
    /// </summary>
    public interface ITransacction
    {
        /// <summary>
        ///     Fecha de de la transacción
        /// </summary>
        DateTime Fecha { get; set; }

        /// <summary>
        ///     Id del empleado a cargo de la transacción
        /// </summary>
        int IdEmpleado { get; set; }
    }
}
