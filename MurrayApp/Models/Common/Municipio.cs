using Models.Interfaces;

namespace Models.Common
{
    /// <summary>
    ///     Municipio de region geografica
    /// </summary>
    public class Municipio : IIdentity, INameable
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="INameable.Nombre"/>
        public string Nombre { get; set; }

        #region Foreing Key

        /// <summary>
        ///     Id del departamento al cual pertenece el municipio
        /// </summary>
        public int IdDepartamento { get; set; }

        #endregion
    }
}
