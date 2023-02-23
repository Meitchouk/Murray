using System;
using Models.Identity;

namespace Murray
{
    /// <summary>
    ///     Valores globales de de sesion a utilizar propios del usuario
    /// </summary>
    internal static class Session
    {
        #region Public Properties

        /// <summary>
        ///     Perfil de autenticación del usuario
        /// </summary>
        public static Usuario User { get; private set; }

        /// <summary>
        ///     Indica que existe un usuario logueado en el sistema
        /// </summary>
        public static bool ActiveLogin => User != null && !User.Id.Equals(default) && User.Estado;

        #endregion

        #region Public Methods

        /// <summary>
        ///     Realiza las acciones para obtener credenciales de sesion
        ///      de usuario
        /// </summary>
        /// <exception cref="NullReferenceException">
        ///     Se genera excepcion si el no se brinda un usuario valido
        /// </exception>
        public static void SetSession(Usuario user)
        {
            if (user is null || user.Id.Equals(default))
            {
                RemoveSession();
                return;
            }

            User = user;
        }
        
        /// <summary>
        ///     Realiza todas las acciones para eliminar la sesion de usuario
        /// </summary>
        public static void RemoveSession()
        {
            User = null;
        }

        #endregion
    }
}
