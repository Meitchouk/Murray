using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    internal class CategoriaDao : BaseDao<Categoria>, ICategoriaDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public CategoriaDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        #region Public Methods

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override Categoria Create(Categoria model)
        {
            if (Validate(model, Operation.CREATE))
                return new Categoria();

            return Read(StoredProcedures.CategoriaCreate, new Dictionary<string, object>
            {
                ["Nombre"] = model.Nombre

            }).FirstOrDefault() ?? new Categoria();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Categoria Delete(int id)
        {
            return Read(StoredProcedures.CategoriaDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Categoria();
        }

        /// <inheritdoc cref="ICategoriaDao.GetById(int)"/>
        public Categoria GetById(int id)
        {
            return Read(StoredProcedures.CategoriaGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Categoria();
        }

        /// <inheritdoc cref="ICategoriaDao.Read(string)"/>
        public IEnumerable<Categoria> Read(string value)
        {
            return Read(StoredProcedures.CategoriaGet, new Dictionary<string, object>
            {
                ["Nombre"] = value
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Categoria> Read()
        {
            return Read(string.Empty);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Categoria Update(int id, Categoria model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Categoria();

            return Read(StoredProcedures.CategoriaUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Nombre"] = model.Nombre

            }).FirstOrDefault() ?? new Categoria();
        }

        #endregion

        #region Private Methods

        private bool Validate(Categoria model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            return Handler.HasError();
        }

        #endregion
    }
}
