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
    // Implementa la interfaz IProveedorDao e hereda de BaseDao la entidad Proveedor.
    internal class ProveedorDao : BaseDao<Proveedor>, IProveedorDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        // Constructor que recibe una cadena de texto con el connectionString y un manejador de errores.
        public ProveedorDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        // Método override que crea un registro en la tabla Proveedor, verifica antes si el modelo es valido mediante el método Validate
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
        // Método override que elimina un registro de la tabla Proveedor
        public override Proveedor Delete(int id)
        {
            return Read(StoredProcedures.ProveedorDelete, new Dictionary<string, object>
            {
                ["Id"] = id
            }).FirstOrDefault() ?? new Proveedor();
        }

        /// <inheritdoc cref="IProveedorDao.GetById(int)"/>
        // Método que devuelve un proveedor por su id en la tabla Proveedor
        public Proveedor GetById(int id)
        {
            return Read(StoredProcedures.ProveedorGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Proveedor();
        }

        /// <inheritdoc cref="IProveedorDao.Read(bool, int)"/>
        // Método que trae proveedores filtrando por estado y/o por Id del Contacto jurídico
        public IEnumerable<Proveedor> Read(bool estado, int idContactoJur)
        {
            return Read(StoredProcedures.ProveedorGet, new Dictionary<string, object>
            {
                ["Estado"] = estado,
                ["IdContactoJur"] = idContactoJur
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        // Obtiene todos los proveedores existentes.
        public override IEnumerable<Proveedor> Read()
        {
            return Read(StoredProcedures.ProveedorGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        // Método override que actualiza un registro por su clave primaria (Id)
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

        //Método privados:
        private bool Validate(Proveedor model, Operation operation)
        {   
            //Usa otro método externo que valida si el objeto-modelo es válido.
            if (Validations.Validate(model, Handler, operation))
                return false;

            return Handler.HasError();
        }

        #endregion
    }
}

