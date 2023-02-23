using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Shopping;
using Models.Shopping;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Shopping
{
    /// <inheritdoc cref="IProveedorDao">
    internal class ProveedorDao : BaseDao<Proveedor>, IProveedorDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public ProveedorDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override Proveedor Create(Proveedor model)
        {
            if (Validate(model, Operation.CREATE))
                return new Proveedor();

            return Read(StoredProcedures.ProveedorCreate, new Dictionary<string, object>
            {
                ["IdContactoJur"] = model.IdContactoJur

            }).FirstOrDefault() ?? new Proveedor();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Proveedor Delete(int id)
        {
            return Read(StoredProcedures.ProveedorDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Proveedor();
        }

        /// <inheritdoc cref="IProveedorDao.GetById(int)"/>
        public Proveedor GetById(int id)
        {
            return Read(StoredProcedures.ProveedorGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Proveedor();
        }

        /// <inheritdoc cref="IProveedorDao.Read(bool, int)"/>
        public IEnumerable<Proveedor> Read(bool estado, int idContactoJur)
        {
            return Read(StoredProcedures.ProveedorGet, new Dictionary<string, object>
            {
                ["Estado"] = estado,
                ["IdContactoJur"] = idContactoJur
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Proveedor> Read()
        {
            return Read(StoredProcedures.ProveedorGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Proveedor Update(int id, Proveedor model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Proveedor();

            return Read(StoredProcedures.ProveedorUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdContactoJur"] = model.IdContactoJur

            }).FirstOrDefault() ?? new Proveedor();
        }

        #region Private Methods

        private bool Validate(Proveedor model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            return Handler.HasError();
        }

        #endregion
    }
}
