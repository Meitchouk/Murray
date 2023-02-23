using Models.Interfaces;

namespace Models.Common
{
    /// <summary>
    ///     Departamento de region geografica
    /// </summary>
    public class Departamento : IIdentity, INameable
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="INameable.Nombre"/>
        public string Nombre { get; set; }
    }
}