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
        private readonly IProductoDao ProductoDao;
        private readonly ICategoriaDao CategoriaDao;

        public StockService(ErrorHandler handler) : base(handler)
        {
            ProductoDao = DaoFactory.Get<IProductoDao>(handler);
            CategoriaDao = DaoFactory.Get<ICategoriaDao>(handler);
        }

        public IEnumerable<ProductoView> GetProductos(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            var records = ProductoDao.Read(query);

            return records.Select(producto =>
            {
                var categoria = CategoriaDao.GetById(producto.IdCategoria);

                return new ProductoView
                {
                    Id = producto.Id,
                    Nombre = producto.Descripcion,
                    Categoria = categoria.Nombre
                };
            });
        }

        public Producto GetProduct(int id)
        {
            return ProductoDao.GetById(id);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return CategoriaDao.Read();
        }

        public Producto SaveProduct(Producto record)
        {
            var isNew = record.Id.Equals(default);
            return isNew ? ProductoDao.Create(record) : ProductoDao.Update(record.Id, record);
        }

        public Producto DeleteProduct(int id)
        {
            return ProductoDao.Delete(id);
        }

        public override void Dispose()
        {
            ProductoDao.Dispose();
            CategoriaDao.Dispose();

            Handler.Clear();
        }
    }
}
