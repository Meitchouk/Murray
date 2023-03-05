using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Sale;
using Models.Sale;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Sale
{
    /// <inheritdoc cref="IClienteDao">
    internal class ClienteDao : BaseDao<Cliente>, IClienteDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public ClienteDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)" />
        public override Cliente Create(Cliente model)
        {
            //Valida el modelo antes de insertarlo
            if (Validate(model, Operation.CREATE))
                return new Cliente();

            //Inserta el nuevo registro y lo retorna
            return Read(StoredProcedures.ClienteCreate, new Dictionary<string, object>
            {
                ["IdContacto"] = model.IdContacto

            }).FirstOrDefault() ?? new Cliente();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)" />
        public override Cliente Delete(int id)
        {   
            //Elimina un registro por su id y lo retorna
            return Read(StoredProcedures.ClienteDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Cliente();
        }

        /// <inheritdoc cref="IClienteDao.GetById(int)" />
        public Cliente GetById(int id)
        {
            //Obtiene un cliente por su Id y lo retorna
            return Read(StoredProcedures.ClienteGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Cliente();
        }

        /// <inheritdoc cref="IClienteDao.Read(bool, int)" />
        public IEnumerable<Cliente> Read(bool estado, int idContacto)
        {
            //Obtiene los clientes dada una condición "estado" e "idContacto"
            return Read(StoredProcedures.ClienteGet, new Dictionary<string, object>
            {
                ["Estado"] = estado,
                ["IdContacto"] = idContacto
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read" />
        public override IEnumerable<Cliente> Read()
        {   
            //Obtiene todos los clientes y los retorna
            return Read(StoredProcedures.ClienteGet);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)" />
        public override Cliente Update(int id, Cliente model)
        {   
            //Valida el modelo antes de actualizarlo
            if (Validate(model, Operation.UPDATE))
                return new Cliente();

            //Actualiza un registro por su id y lo retorna
            return Read(StoredProcedures.ClienteUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdContacto"] = model.IdContacto

            }).FirstOrDefault() ?? new Cliente();
        }

        #region Private Methods

        //Método privado utilizado para validar un modelo
        private bool Validate(Cliente model, Operation operation)
        {   
            //Realiza validaciones en el modelo y lo relacionado con este
            if (Validations.Validate(model, Handler, operation))
                return false;

            return Handler.HasError();
        }   

        #endregion
    }
}

