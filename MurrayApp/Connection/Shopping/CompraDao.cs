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
            // Validar la entrada del modelo
            if (Validate(model, Operation.CREATE))
                return new Compra();

            // Crear una nueva instancia de Compra consultando la base de datos
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
            // Consultar la base de datos para eliminar una Compra por su ID
            return Read(StoredProcedures.CompraDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Compra();
        }

        /// <inheritdoc cref="ICompraDao.GetById(int)"/>
        public Compra GetById(int id)
        {
            // Leer una Compra de la base de datos por su ID
            return Read(StoredProcedures.CompraGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Compra();
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Compra> Read()
        {
            // Obtener una lista de todos las Compras en la base de datos
            return Read(StoredProcedures.CompraGet);
        }

        /// <inheritdoc cref="ICompraDao.Read(string)"/>
        public IEnumerable<Compra> Read(string query)
        {
            // Ejecutar una consulta personalizada de Compra contra la base de datos
            return Read(StoredProcedures.CompraGet, new Dictionary<string, object>
            {
                ["Query"] = query
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Compra Update(int id, Compra model)
        {
            // Validar la entrada del modelo
            if (Validate(model, Operation.UPDATE))
                return new Compra();

            // Actualizar una Compra en la base de datos y obtener una nueva instancia de Compra
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
            // Validar el modelo de Compra según la operación especificada
            if (Validations.Validate(model, Handler, operation))
                return false;

            // Verificar si hubo algún error durante el proceso de validación
            return Handler.HasError();
        }

        #endregion
    }
}

