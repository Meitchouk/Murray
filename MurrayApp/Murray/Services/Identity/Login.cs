using Common.Util;
using Connection.Interfaces.Identity;
using Models.Identity;
using Murray.Services.Base;
using System;

namespace Murray.Services.Identity
{
    /// <summary>
    /// Clase auxiliar para el uso en la vista de login
    /// </summary>
    internal class Login : ServiceBase
    {
        #region Private Fields

        /// <summary>
        /// DAO de conexión con el usuario
        /// </summary>
        private readonly IUsuarioDao Dao;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Login(ErrorHandler handler) : base(handler)
        {
            Dao = DaoFactory.Get<IUsuarioDao>(handler);
        }

        #endregion

        /// <summary>
        /// Realiza el inicio de sesión del usuario
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        public Usuario DoLogin(string username, string password)
        {
            // Verifica si ya existe una sesión activa
            if (Session.ActiveLogin)
                return Session.User;

            // Validación de campos vacios
            if (string.IsNullOrEmpty(username))
                Handler.Add("USERNAME_IS_EMPTY");

            if (string.IsNullOrEmpty(password))
                Handler.Add("PASSWORD_IS_EMPTY");

            if (Handler.HasError())
                return new Usuario();

            // Verifica el login con los datos proporcionados
            var user = Dao.Login(username, password);

            if (Handler.HasError())
                return new Usuario();

            // Inicia una nueva sesión y devuelve el objeto User.
            Session.SetSession(user);
            return user;
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public override void Dispose()
        {
            // Liberar recursos
            Dao.Dispose();
            Handler.Clear();
        }
    }
}

