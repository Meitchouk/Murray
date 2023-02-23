using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Shopping;
using Models.Shopping;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Shopping
{
    /// <inheritdoc cref="IDetalleCompraDao">
    internal class DetalleCompraDao : BaseDao<DetalleCompra>, IDetalleCompraDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public DetalleCompraDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override DetalleCompra Create(DetalleCompra model)
        {
            if (Validate(model, Operation.CREATE))
                return new DetalleCompra();

            return Read(StoredProcedures.DetalleCompraCreate, new Dictionary<string, object>
            {
                ["IdProducto"] = model.IdProducto,
                ["Cantidad"] = model.Cantidad,
                ["Precio"] = model.Precio,
                ["Descuento"] = model.Descuento,
                ["Subtotal"] = model.Subtotal,
                ["IdCompra"] = model.IdCompra

            }).FirstOrDefault() ?? new DetalleCompra();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override DetalleCompra Delete(int id)
        {
            return Read(StoredProcedures.DetalleCompraDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new DetalleCompra();
        }

        /// <inheritdoc cref="IDetalleCompraDao.GetByCompraId(int)"/>
        public IEnumerable<DetalleCompra> GetByCompraId(int id)
        {
            return Read(StoredProcedures.DetalleCompraGet, new Dictionary<string, object>
            {
                ["IdCompra"] = id
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<DetalleCompra> Read()
        {
            return Read(StoredProcedures.DetalleCompraGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override DetalleCompra Update(int id, DetalleCompra model)
        {
            if (Validate(model, Operation.UPDATE))
                return new DetalleCompra();

            return Read(StoredProcedures.DetalleCompraUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdProducto"] = model.IdProducto,
                ["Cantidad"] = model.Cantidad,
                ["Precio"] = model.Precio,
                ["Descuento"] = model.Descuento,
                ["Subtotal"] = model.Subtotal,
                ["IdCompra"] = model.IdCompra

            }).FirstOrDefault() ?? new DetalleCompra();
        }

        #region Private Methods

        private bool Validate(DetalleCompra model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            // Calculate
            if (model.Subtotal < 0D)
                Handler.Add("SUBTOTAL_IS_NEGATIVE");

            return Handler.HasError();
        }

        #endregion
    }
}
