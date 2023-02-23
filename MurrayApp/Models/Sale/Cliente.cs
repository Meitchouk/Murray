using Models.Interfaces;

namespace Models.Sale
{
    public class Cliente : IIdentity, IActivable
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="IActivable.Estado"/>
        public bool Estado { get; set; }

        #region Foreing Key

        /// <summary>
        ///     Id del Contacto
        /// </summary>
        public int IdContacto { get; set; }

        #endregion
    }
}