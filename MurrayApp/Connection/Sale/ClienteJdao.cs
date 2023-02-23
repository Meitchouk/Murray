using Common.Util;
using Connection.Base;
using Connection.Interfaces.Sale;
using Models.Sale;
using System.Collections.Generic;

namespace Connection.Sale
{
    internal class ClienteJdao : BaseDao<ClienteJuridico>, IClienteJuridicoDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public ClienteJdao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        public override ClienteJuridico Create(ClienteJuridico model)
        {
            throw new System.NotImplementedException();
        }

        public override ClienteJuridico Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ClienteJuridico Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ClienteJuridico> Read(bool estado, int Id)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<ClienteJuridico> Read()
        {
            throw new System.NotImplementedException();
        }

        public override ClienteJuridico Update(int id, ClienteJuridico model)
        {
            throw new System.NotImplementedException();
        }
    }
}
