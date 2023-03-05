using Common.Util;
using Connection.Interfaces.Common;
using Murray.Services.Base;
using System;

namespace Murray.Services.Common
{
    internal class Location : ServiceBase
    {
        #region Private Fields

        /// <summary>
        ///     DAO de conexion con departamentos
        /// </summary>
        private readonly IDepartamentoDao DepartamentosDao;

        #endregion

        /// <summary>
        ///     Constructor de la clase Location
        /// </summary>
        /// <param name="handler">Manejador del error</param>
        public Location(ErrorHandler handler) : base(handler)
        {
            //Inicializa el objeto DepartamentosDao con una instancia apropiada de IDepartamentoDao utilizando la fábrica DaoFactory 
            DepartamentosDao = DaoFactory.Get<IDepartamentoDao>(handler);
        }

        /// <summary>
        /// Metodo que obtiene los departamentos desde DepartamentosDAO.
        /// </summary>
        public void GetDepartamentos()
        {
            DepartamentosDao.Read();
        }

        /// <summary>
        /// Libera los recursos no administrados utilizados por Location y, opcionalmente, libera los recursos administrados.
        /// </summary>
        public override void Dispose()
        {
            Handler.Clear();
        }
    }
}

