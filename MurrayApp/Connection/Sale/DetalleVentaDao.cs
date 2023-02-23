using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Sale;
using Models.Sale;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Sale
{
    /// <inheritdoc cref="IDetalleVentaDao"/>/>
    internal class DetalleVentaDao : BaseDao<DetalleVenta>, IDetalleVentaDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public DetalleVentaDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override DetalleVenta Create(DetalleVenta model)
        {
            if (Validate(model, Operation.CREATE))
                return new DetalleVenta();

            return Read(StoredProcedures.DetalleVentaCreate, new Dictionary<string, object>
            {
                ["IdProducto"] = model.IdProducto,
                ["Cantidad"] = model.Cantidad,
                ["Precio"] = model.Precio,
                ["Descuento"] = model.Descuento,
                ["Subtotal"] = model.Subtotal,
                ["IdVenta"] = model.IdVenta

            }).FirstOrDefault() ?? new DetalleVenta();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override DetalleVenta Delete(int id)
        {
            return Read(StoredProcedures.DetalleVentaDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new DetalleVenta();
        }

        /// <inheritdoc cref="IDetalleVentaDao.GetByVentaId(int)"/>
        public IEnumerable<DetalleVenta> GetByVentaId(int id)
        {
            return Read(StoredProcedures.DetalleVentaGet, new Dictionary<string, object>
            {
                ["IdVenta"] = id
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<DetalleVenta> Read()
        {
            return Read(StoredProcedures.DetalleVentaGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override DetalleVenta Update(int id, DetalleVenta model)
        {
            if (Validate(model, Operation.UPDATE))
                return new DetalleVenta();

            return Read(StoredProcedures.DetalleVentaUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdProducto"] = model.IdProducto,
                ["Cantidad"] = model.Cantidad,
                ["Precio"] = model.Precio,
                ["Descuento"] = model.Descuento,
                ["Subtotal"] = model.Subtotal,
                ["IdVenta"] = model.IdVenta

            }).FirstOrDefault() ?? new DetalleVenta();
        }

        #region Private Methods

        private bool Validate(DetalleVenta model, Operation operation)
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
