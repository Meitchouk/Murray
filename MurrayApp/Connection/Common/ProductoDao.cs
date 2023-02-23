using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    /// <inheritdoc cref="IProductoDao"/>/>
    internal class ProductoDao : BaseDao<Producto>, IProductoDao
    {
        #region Constructor

        /// <summary>
        ///     Consturctor por defecto
        /// </summary>
        public ProductoDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        #region Public Methods
        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override Producto Create(Producto model)
        {
            if (Validate(model, Operation.CREATE))
                return new Producto();

            return Read(StoredProcedures.ProductoCreate, new Dictionary<string, object>
            {
                ["Descripcion"] = model.Descripcion,
                ["Precio"] = model.Precio,
                ["IdCategoria"] = model.IdCategoria

            }).FirstOrDefault() ?? new Producto();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Producto Delete(int id)
        {
            return Read(StoredProcedures.ProductoDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Producto();
        }

        /// <inheritdoc cref="IProductoDao.GetById(int)"/>
        public Producto GetById(int id)
        {
            return Read(StoredProcedures.ProductoGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Producto();
        }

        /// <inheritdoc cref="IProductoDao.Read(string)"/>
        public IEnumerable<Producto> Read(string value)
        {
            return Read(StoredProcedures.ProductoGet, new Dictionary<string, object>
            {
                ["Descripcion"] = value
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Producto> Read()
        {
            return Read(string.Empty);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Producto Update(int id, Producto model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Producto();

            return Read(StoredProcedures.ProductoUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Descripcion"] = model.Descripcion,
                ["Precio"] = model.Precio,
                ["IdCategoria"] = model.IdCategoria

            }).FirstOrDefault() ?? new Producto();
        }
        #endregion

        #region Private Methods

        private bool Validate(Producto model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            if (model.Precio.Equals(decimal.Zero))
                Handler.Add("PRECIO_IS_EMPTY");

            if (model.IdCategoria.Equals(default))
                Handler.Add("ID_CATEGORIA_NOT_EXISTS");

            return Handler.HasError();
        }

        #endregion
    }
}
