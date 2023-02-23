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
        ///     Constructor
        /// </summary>
        public Location(ErrorHandler handler) : base(handler)
        {
            DepartamentosDao = DaoFactory.Get<IDepartamentoDao>(handler);
        }

        public void GetDepartamentos()
        {
            DepartamentosDao.Read();
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public override void Dispose()
        {
            Handler.Clear();
        }
    }
}
