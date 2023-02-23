namespace Models.Interfaces
{
    /// <summary>
    ///     Representa si el registro fue desactivado
    /// </summary>
    public interface IActivable
    {
        /// <summary>
        ///     Referencia si el registro se encuentra activo para
        ///     nuevas transacciones
        /// </summary>
        bool Estado { get; set; }
    }
}
