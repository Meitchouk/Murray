namespace Models.Interfaces
{
    /// <summary>
    ///     Representa el identificador unico de un registro de tabla en base de datos
    /// </summary>
    public interface IIdentity
    {
        /// <summary>
        ///     Identidad del registro en base dato, este es un valor unico
        /// </summary>
        int Id { get; set; }
    }
}
