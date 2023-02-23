namespace Models.Interfaces
{
    /// <summary>
    ///     Representa que el registro tiene un nombre para ser identificado
    /// </summary>
    public interface INameable
    {
        /// <summary>
        ///     Nombre con el cual se identifica el registro
        /// </summary>
        string Nombre { get; set; }
    }
}
