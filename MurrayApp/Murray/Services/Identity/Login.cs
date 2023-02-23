using Common.Util;
using Connection.Interfaces.Identity;
using Models.Identity;
using Murray.Services.Base;
using System;

namespace Murray.Services.Identity
{
    /// <summary>
    ///     Clase auxiliar para el uso en la vista de
    ///     login
    /// </summary>
    internal class Login : ServiceBase
    {
        #region Private Fields

        /// <summary>
        ///     DAO de conexion con el usuario
        /// </summary>
        private readonly IUsuarioDao Dao;

        #endregion

        #region Constructors
        
        /// <summary>
        ///     Constructor
        /// </summary>
        public Login(ErrorHandler handler) : base(handler)
        {
            Dao = DaoFactory.Get<IUsuarioDao>(handler);
        }

        #endregion

        /// <summary>
        ///     Realiza inicio de sesion
        /// </summary>
        /// <param name="username">
        ///     Nombre del usuario
        /// </param>
        /// <param name="password">
        ///     Contrasena del usuario
        /// </param>
        public Usuario DoLogin(string username, string password)
        {
            if (Session.ActiveLogin)
                return Session.User;

            if (string.IsNullOrEmpty(username))
                Handler.Add("USERNAME_IS_EMPTY");

            if (string.IsNullOrEmpty(password))
                Handler.Add("PASSWORD_IS_EMPTY");

            if (Handler.HasError())
                return new Usuario();

            var user = Dao.Login(username, password);

            if (Handler.HasError())
                return new Usuario();

            Session.SetSession(user);
            return user;
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public override void Dispose()
        {
            Dao.Dispose();
            Handler.Clear();
        }
    }
}
