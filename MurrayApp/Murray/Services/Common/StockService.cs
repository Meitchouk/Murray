using Common.Util;
using Connection.Interfaces.Common;
using Models.Common;
using Murray.Services.Base;
using Murray.ViewModels.Common;

using System.Collections.Generic;
using System.Linq;

namespace Murray.Services.Common
{
    internal class StockService : ServiceBase
    {
        private readonly IProductoDao ProductoDao;  // DAO para acceder a productos
        private readonly ICategoriaDao CategoriaDao;  // DAO para acceder a categorías

        public StockService(ErrorHandler handler) : base(handler)
        {
            ProductoDao = DaoFactory.Get<IProductoDao>(handler);  // Obtener instancia de ProductoDao
            CategoriaDao = DaoFactory.Get<ICategoriaDao>(handler);  // Obtener instancia de CategoriaDao
        }

        public IEnumerable<ProductoView> GetProductos(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            var records = ProductoDao.Read(query);  // Leer todos los registros que cumplen la consulta/condición

            return records.Select(producto =>
            {
                var categoria = CategoriaDao.GetById(producto.IdCategoria);  // Obtenemos categoria por el id del producto

                return new ProductoView
                {
                    Id = producto.Id,
                    Nombre = producto.Descripcion,
                    Categoria = categoria.Nombre  // Agregamos el nombre de la categoria al objeto ProductoView
                };
            });
        }

        public Producto GetProduct(int id)
        {
            return ProductoDao.GetById(id);  // Obtenemos un producto por su id
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return CategoriaDao.Read();  // Obtenemos todas las categorias disponibles 
        }

        public Producto SaveProduct(Producto record)
        {
            var isNew = record.Id.Equals(default);
            // Si es nuevo, creamos un registro. Si no, lo actualizamos.
            return isNew ? ProductoDao.Create(record) : ProductoDao.Update(record.Id, record);;
        }

        public Producto DeleteProduct(int id)
        {
            return ProductoDao.Delete(id);  // Eliminamos un producto por su id
        }

        public override void Dispose()
        {
            ProductoDao.Dispose();  // Liberaramos el recurso "ProductoDao"
            CategoriaDao.Dispose();  // Liberaramos el recurso "CategoriaDao"

            Handler.Clear();  // Limpiamos cualquier excepción que haya quedado en el Handler
        }
    }
}

