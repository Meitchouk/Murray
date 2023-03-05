using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Sale;
using Models.Sale;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Sale
{
    internal class VentaDao : BaseDao<Venta>, IVentaDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public VentaDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        // Crear una nueva venta.
        public override Venta Create(Venta model)
        {
            if (Validate(model, Operation.CREATE))
                return new Venta();

            return Read(StoredProcedures.VentaCreate, new Dictionary<string, object>
            {
                ["IdCliente"] = model.IdCliente,
                ["IdEmpleado"] = model.IdEmpleado,
                ["Fecha"] = model.Fecha

            }).FirstOrDefault() ?? new Venta();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        // Eliminar una venta existente dado su Id.
        public override Venta Delete(int id)
        {
            return Read(StoredProcedures.VentaDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Venta();
        }

         /// <inheritdoc cref="IVentaDao.GetById(int)"/>
        // Obtener información de una venta existente dado su Id.
        public Venta GetById(int id)
        {
            return Read(StoredProcedures.VentaGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Venta();
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        // Obtener la información de todas las ventas existentes.
        public override IEnumerable<Venta> Read()
        {
            return Read(StoredProcedures.VentaGet);
        }

        /// <inheritdoc cref="IVentaDao.Read(string)"/>
        // Obtener la información de todas las ventas existentes que cumplan con ciertas condiciones definidas en una consulta personalizada.
        public IEnumerable<Venta> Read(string query)
        {
            return Read(StoredProcedures.VentaGet, new Dictionary<string, object>
            {
                ["Query"] = query
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        // Actualizar la información de una venta existente.
        public override Venta Update(int id, Venta model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Venta();

            return Read(StoredProcedures.VentaUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdCliente"] = model.IdCliente,
                ["IdEmpleado"] = model.IdEmpleado,
                ["Fecha"] = model.Fecha

            }).FirstOrDefault() ?? new Venta();
        }

        #region Private Methods

        private bool Validate(Venta model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            return Handler.HasError();
        }

        #endregion
    }
}
