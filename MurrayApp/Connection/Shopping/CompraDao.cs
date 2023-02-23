using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Shopping;
using Models.Shopping;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Shopping
{
    /// <inheritdoc cref="ICompraDao">
    internal class CompraDao : BaseDao<Compra>, ICompraDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public CompraDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override Compra Create(Compra model)
        {
            if (Validate(model, Operation.CREATE))
                return new Compra();

            return Read(StoredProcedures.CompraCreate, new Dictionary<string, object>
            {
                ["IdProveedor"] = model.IdProveedor,
                ["IdEmpleado"] = model.IdEmpleado,
                ["Fecha"] = model.Fecha

            }).FirstOrDefault() ?? new Compra();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Compra Delete(int id)
        {
            return Read(StoredProcedures.CompraDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Compra();
        }

        /// <inheritdoc cref="ICompraDao.GetById(int)"/>
        public Compra GetById(int id)
        {
            return Read(StoredProcedures.CompraGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Compra();
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Compra> Read()
        {
            return Read(StoredProcedures.CompraGet);
        }

        /// <inheritdoc cref="ICompraDao.Read(string)"/>
        public IEnumerable<Compra> Read(string query)
        {
            return Read(StoredProcedures.CompraGet, new Dictionary<string, object>
            {
                ["Query"] = query
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Compra Update(int id, Compra model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Compra();

            return Read(StoredProcedures.CompraUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdProveedor"] = model.IdProveedor,
                ["IdEmpleado"] = model.IdEmpleado,
                ["Fecha"] = model.Fecha

            }).FirstOrDefault() ?? new Compra();
        }

        #region Private Methods

        private bool Validate(Compra model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            return Handler.HasError();
        }

        #endregion
    }
}
