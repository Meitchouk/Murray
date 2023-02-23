using Models.Interfaces;

namespace Models.Identity
{
    /// <summary>
    ///     Usuario de sistema
    /// </summary>
    public class Usuario : IIdentity, IActivable
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <summary>
        ///     Nombre del usuario
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Rol de usuario en el sistyema
        /// </summary>
        public string Role { get; set; }

        /// <inheritdoc cref="IActivable.Estado"/>
        public bool Estado { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Id del empleado asociado al usuario
        /// </summary>
        public int IdEmpleado { get; set; }

        #endregion
    }
}
