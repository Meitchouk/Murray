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
        public override Venta Delete(int id)
        {
            return Read(StoredProcedures.VentaDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Venta();
        }

        /// <inheritdoc cref="IVentaDao.GetById(int)"/>
        public Venta GetById(int id)
        {
            return Read(StoredProcedures.VentaGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Venta();
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Venta> Read()
        {
            return Read(StoredProcedures.VentaGet);
        }

        /// <inheritdoc cref="IVentaDao.Read(string)"/>
        public IEnumerable<Venta> Read(string query)
        {
            return Read(StoredProcedures.VentaGet, new Dictionary<string, object>
            {
                ["Query"] = query
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
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
