using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Sale;
using Models.Sale;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Sale
{
    /// <inheritdoc cref="IClienteDao">
    internal class ClienteDao : BaseDao<Cliente>, IClienteDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public ClienteDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override Cliente Create(Cliente model)
        {
            if (Validate(model, Operation.CREATE))
                return new Cliente();

            return Read(StoredProcedures.ClienteCreate, new Dictionary<string, object>
            {
                ["IdContacto"] = model.IdContacto

            }).FirstOrDefault() ?? new Cliente();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Cliente Delete(int id)
        {
            return Read(StoredProcedures.ClienteDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Cliente();
        }

        /// <inheritdoc cref="IClienteDao.GetById(int)"/>
        public Cliente GetById(int id)
        {
            return Read(StoredProcedures.ClienteGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Cliente();
        }

        /// <inheritdoc cref="IClienteDao.Read(bool, int)"/>
        public IEnumerable<Cliente> Read(bool estado, int idContacto)
        {
            return Read(StoredProcedures.ClienteGet, new Dictionary<string, object>
            {
                ["Estado"] = estado,
                ["IdContacto"] = idContacto
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Cliente> Read()
        {
            return Read(StoredProcedures.ClienteGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Cliente Update(int id, Cliente model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Cliente();

            return Read(StoredProcedures.ClienteUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdContacto"] = model.IdContacto

            }).FirstOrDefault() ?? new Cliente();
        }

        #region Private Methods

        private bool Validate(Cliente model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            return Handler.HasError();
        }

        #endregion
    }
}
