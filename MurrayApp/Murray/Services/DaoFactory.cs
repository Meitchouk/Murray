using Common.Util;
using Murray.Properties;

namespace Murray.Services
{
    /// <summary>
    ///     Clase encargada como middleware interno para invocacion
    ///     de DAO's
    /// </summary>
    internal static class DaoFactory
    {
        #region Fields

        /// <summary>
        ///     Cadena de conexion a la base de datos
        /// </summary>
        private static readonly string ConnectionString;

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        static DaoFactory()
        {
            ConnectionString = Settings.Default.ConnectionString;
        }

        #endregion

        /// <summary>
        ///     Obtiene un DAO
        /// </summary>
        /// <typeparam name="TDao">
        ///     Tipo del DAO a obtener
        /// </typeparam>=
        public static TDao Get<TDao>(ErrorHandler handler) => Connection.Factory.Invoke<TDao>(ConnectionString, handler);
    }
}
