using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    /// <inheritdoc cref="IProductoDao"/>
    internal class ProductoDao : BaseDao<Producto>, IProductoDao
    {
        #region Constructor
        
        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public ProductoDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        #region Métodos Públicos (Public Methods)

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>
        public override Producto Create(Producto model)
        {
            //Valida el modelo antes de crear un nuevo producto
            if (Validate(model, Operation.CREATE))
                return new Producto();

            //Crea el nuevo producto utilizando procedimientos almacenados y lo retorna
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
            //elimina un producto buscandolo por su ID utilizando procedimientos almacenados y lo retorna
            return Read(StoredProcedures.ProductoDelete, new Dictionary<string, object>
            {
                //Argumentos de entrada al procedimiento almacenado para eliminar un producto con id recibido
                ["Id"] = id

            }).FirstOrDefault() ?? new Producto();
        }

        
        /// <inheritdoc cref="IProductoDao.GetById(int)"/>
        public Producto GetById(int id)
        {
            //obtiene un producto por su id utilizando procedimientos almacenados y lo retorna
            return Read(StoredProcedures.ProductoGet, new Dictionary<string, object>
            {
                //Argumentos de entrada al procedimiento almacenado para obtener un producto con id recibido
                ["Id"] = id

            }).FirstOrDefault() ?? new Producto();
        }


        /// <inheritdoc cref="IProductoDao.Read(string)"/>
        public IEnumerable<Producto> Read(string value)
        {
            //Busca(producto)s filtrando por descripción utilizando procedimientos almacenados y los retorna
            return Read(StoredProcedures.ProductoGet, new Dictionary<string, object>
            {
                //Argumentos de entrada al procedimiento almacenado para filtrar por la descripción del producto recibido
                ["Descripcion"] = value
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Producto> Read()
        {
            //Llama a la sobrecarga sin argumentos que a su vez llama al método publico anteriormente declarado.
            return Read(string.Empty);
        }


        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Producto Update(int id, Producto model)
        {
            //valida el modelo recibido y si pasa las validaciones, actualiza el producto relacionado con el id provisto utilizando procedimientos almacenados
            if (Validate(model, Operation.UPDATE))
                return new Producto();

            return Read(StoredProcedures.ProductoUpdate, new Dictionary<string, object>
            {
                //Argumentos de entrada al procedimiento almacenado para actualizar el producto con el id recibido y la información del modelo provisto
                ["Id"] = id,
                ["Descripcion"] = model.Descripcion,
                ["Precio"] = model.Precio,
                ["IdCategoria"] = model.IdCategoria

            }).FirstOrDefault() ?? new Producto();
        }

        #endregion
        
        #region Métodos Privados (Private Methods)

        //Método que valida el producto
        private bool Validate(Producto model, Operation operation)
        { 
            //valida el modelo provisto y retorna falso si no se encontró ningún error
            if (Validations.Validate(model, Handler, operation))
                return false;

            //Si el precio es cero, agrega el error "PRECIO_IS_EMPTY"
            if (model.Precio.Equals(decimal.Zero))
                Handler.Add("PRECIO_IS_EMPTY");

            //Si el IdCategoria es igual al valor por defecto, agrega el error "ID_CATEGORIA_NOT_EXISTS"
            if (model.IdCategoria.Equals(default))
                Handler.Add("ID_CATEGORIA_NOT_EXISTS");

            //Retorna verdadero si se encontraron errores/invalidaciones
            return Handler.HasError();
        }
        #endregion
    }
}
