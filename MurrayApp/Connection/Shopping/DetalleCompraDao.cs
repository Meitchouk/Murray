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
            // Validar los datos del modelo antes de crear un registro nuevo
            if (Validate(model, Operation.CREATE))
                return new DetalleCompra();

            // Crear un nuevo registro de DetalleCompra usando procedimientos almacenados con los datos del modelo
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
            // Eliminar un registro de DetalleCompra usando procedimientos almacenados con el ID proporcionado
            return Read(StoredProcedures.DetalleCompraDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new DetalleCompra();
        }

        /// <inheritdoc cref="IDetalleCompraDao.GetByCompraId(int)"/>
        public IEnumerable<DetalleCompra> GetByCompraId(int id)
        {
            // Obtener una lista de registros de DetalleCompra basados en el ID de la compra proporcionada
            return Read(StoredProcedures.DetalleCompraGet, new Dictionary<string, object>
            {
                ["IdCompra"] = id
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<DetalleCompra> Read()
        {
            // Obtener todos los registros de DetalleCompra
            return Read(StoredProcedures.DetalleCompraGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override DetalleCompra Update(int id, DetalleCompra model)
        {
            // Validar los datos del modelo antes de actualizar un registro existente
            if (Validate(model, Operation.UPDATE))
                return new DetalleCompra();

            // Actualizar el registro existente con los nuevos datos proporcionados en el modelo
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
            // Realizar validaciones en el modelo para asegurarse de que cumple con los requisitos necesarios antes de ser creado o actualizado
            if (Validations.Validate(model, Handler, operation))
                return false;

            // Verificar que el subtotal del DetalleCompra no sea negativo
            if (model.Subtotal < 0D)
                Handler.Add("SUBTOTAL_IS_NEGATIVE");

            return Handler.HasError();
        }

        #endregion
    }
}

