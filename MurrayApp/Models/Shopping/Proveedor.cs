using Models.Interfaces;

namespace Models.Shopping
{
    public class Proveedor : IIdentity, IActivable
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="IActivable.Estado"/>
        public bool Estado { get; set; }

        #region Foreing Key

        /// <summary>
        ///     Id del Contacto
        /// </summary>
        public int IdContactoJur { get; set; }

        #endregion
    }
}
