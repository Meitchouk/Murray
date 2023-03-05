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
        /// Constructor por defecto que recibe una cadena de conexión y un manejador de errores.
        /// </summary>
        public DetalleVentaDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override DetalleVenta Create(DetalleVenta model)
        {
            // Valida el modelo para la operación CREATE
            if (Validate(model, Operation.CREATE))
                return new DetalleVenta();

            // LLama al procedimiento almacenado de la operación CREATE y devuelve el resultado o un nuevo objeto DetalleVenta si no hubo resultado
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
            // LLama al procedimiento almacenado de la operación DELETE y devuelve el resultado o un nuevo objeto DetalleVenta si no hubo resultado
            return Read(StoredProcedures.DetalleVentaDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new DetalleVenta();
        }

        /// <inheritdoc cref="IDetalleVentaDao.GetByVentaId(int)"/>
        public IEnumerable<DetalleVenta> GetByVentaId(int id)
        {
            // LLama al procedimiento almacenado de la operación GET BY VENTA ID y devuelve los resultados
            return Read(StoredProcedures.DetalleVentaGet, new Dictionary<string, object>
            {
                ["IdVenta"] = id
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<DetalleVenta> Read()
        {
            // LLama al procedimiento almacenado de la operación de lectura sin filtros y devuelve los resultados
            return Read(StoredProcedures.DetalleVentaGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override DetalleVenta Update(int id, DetalleVenta model)
        {
            // Valida el modelo para la operación UPDATE
            if (Validate(model, Operation.UPDATE))
                return new DetalleVenta();

            // LLama al procedimiento almacenado de la operación UPDATE y devuelve el resultado o un nuevo objeto DetalleVenta si no hubo resultado
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
            // Valida el modelo contra las validaciones necesarias definidas por el manejador de errores
            if (Validations.Validate(model, Handler, operation))
                return false;

            // Verifica si el subtotal es negativo y agrega el error correspondiente al manejador de errores
            if (model.Subtotal < 0D)
                Handler.Add("SUBTOTAL_IS_NEGATIVE");

            // Retorna true si no hubo errores, false en caso contrario
            return Handler.HasError();
        }

        #endregion
    }
}
