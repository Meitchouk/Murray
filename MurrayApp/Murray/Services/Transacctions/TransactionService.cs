using Common.Util;
using Connection.Interfaces.Common;
using Connection.Interfaces.Sale;
using Connection.Interfaces.Shopping;

using Models.Sale;
using Models.Shopping;
using Murray.Services.Base;
using Murray.ViewModels.Common;
using Murray.ViewModels.Sales;
using Murray.ViewModels.Shopping;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Murray.Services.Transacctions
{
    internal class TransactionService : ServiceBase
    {
        private readonly IVentaDao VentaDao;
        private readonly IDetalleVentaDao DetalleVentaDao;
        private readonly ICompraDao CompraDao;
        private readonly IDetalleCompraDao DetalleCompraDao;
        private readonly IEmpleadoDao EmpleadoDao;
        private readonly IProveedorDao ProveedorDao;
        private readonly IClienteDao ClienteDao;
        private readonly IContactoDao ContactoDao;
        private readonly IProductoDao ProductoDao;

        public TransactionService(ErrorHandler handler) : base(handler)
        {
            VentaDao = DaoFactory.Get<IVentaDao>(handler);
            DetalleVentaDao = DaoFactory.Get<IDetalleVentaDao>(handler);
            CompraDao = DaoFactory.Get<ICompraDao>(handler);
            DetalleCompraDao = DaoFactory.Get<IDetalleCompraDao>(handler);
            ContactoDao = DaoFactory.Get<IContactoDao>(handler);
            EmpleadoDao = DaoFactory.Get<IEmpleadoDao>(handler);
            ProveedorDao = DaoFactory.Get<IProveedorDao>(handler);
            ClienteDao = DaoFactory.Get<IClienteDao>(handler);
            ProductoDao = DaoFactory.Get<IProductoDao>(handler);
        }

        #region Compras

        public IEnumerable<CompraView> GetCompras(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            return CompraDao.Read(query).Select(compra =>
            {
                var detalles = DetalleCompraDao.GetByCompraId(compra.Id).ToList();
                var subtotal = detalles.Sum(x => x.Subtotal);

                var proveedor = ProveedorDao.GetById(compra.IdProveedor);
                var empleado = EmpleadoDao.GetById(compra.IdEmpleado);

                var cproveedor = ContactoDao.GetById(proveedor.IdContactoJur);
                var cempleado = ContactoDao.GetById(empleado.IdContacto);

                return new CompraView
                {
                    Id = compra.Id,
                    Fecha = compra.Fecha.ToShortDateString(),
                    Productos = detalles.Count,
                    Cantidad = detalles.Sum(x => x.Cantidad),
                    Subtotal = subtotal,
                    Total = Math.Round(subtotal * 1.15D, 2),
                    Proveedor = cproveedor.NombreCompleto,
                    Empleado = cempleado.NombreCompleto
                };
            });
        }

        internal void SaveCompra(Compra record, List<DetalleCompraView> details)
        {
            var saved = record.Id.Equals(default) ? CompraDao.Create(record) : CompraDao.Update(record.Id, record);
            if (Handler.HasError())
                return;

            details.Select(detalle => new DetalleCompra
            {
                Id = detalle.Id,
                Cantidad = detalle.Cantidad,
                Descuento = detalle.Descuento,
                IdProducto = detalle.IdProducto,
                Precio = detalle.Precio,
                IdCompra = saved.Id
            })
            .ToList()
            .ForEach(detalle =>
            {
                if (Handler.HasError())
                    return;

                var dsaved = detalle.Id.Equals(default) ? DetalleCompraDao.Create(detalle) : DetalleCompraDao.Update(detalle.Id, detalle);
            });
        }

        internal void DeleteCompraDetail(List<DetalleCompraView> toDelete)
        {
            toDelete.ForEach(x => DetalleCompraDao.Delete(x.Id));
        }

        public (Compra compra, DetalleCompraView[] detalles) GetCompra(int id)
        {
            if (id.Equals(default))
                return (new Compra(), new DetalleCompraView[0]);

            var compra = CompraDao.GetById(id);
            if (compra is null || compra.Id.Equals(default))
                return (new Compra(), new DetalleCompraView[0]);

            var detalles = DetalleCompraDao.GetByCompraId(id);
            if (detalles is null) detalles = new DetalleCompra[0];

            return (compra, detalles.Select(detalle =>
            {
                var producto = ProductoDao.GetById(detalle.IdProducto);

                return new DetalleCompraView
                {
                    Id = detalle.Id,
                    Cantidad = detalle.Cantidad,
                    Descuento = detalle.Descuento,
                    Precio = detalle.Precio,
                    Subtotal = detalle.Subtotal,
                    IdProducto = producto.Id,
                    Producto = producto.Descripcion
                };

            }).ToArray());
        }

        #endregion

        #region Ventas

        public IEnumerable<VentaView> GetVentas(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            return VentaDao.Read(query).Select(venta =>
            {
                var detalles = DetalleVentaDao.GetByVentaId(venta.Id).ToList();
                var subtotal = detalles.Sum(x => x.Subtotal);

                var cliente = ClienteDao.GetById(venta.IdCliente);
                var empleado = EmpleadoDao.GetById(venta.IdEmpleado);

                var ccliente = ContactoDao.GetById(cliente.IdContacto);
                var cempleado = ContactoDao.GetById(empleado.IdContacto);

                return new VentaView
                {
                    Id = venta.Id,
                    Fecha = venta.Fecha.ToShortDateString(),
                    Productos = detalles.Count,
                    Cantidad = detalles.Sum(x => x.Cantidad),
                    Subtotal = subtotal,
                    Total = Math.Round(subtotal * 1.15),
                    Cliente = ccliente.NombreCompleto,
                    Empleado = cempleado.NombreCompleto
                };
            });
        }

        internal void SaveVenta(Venta record, List<DetalleVentaView> details)
        {
            var saved = record.Id.Equals(default) ? VentaDao.Create(record) : VentaDao.Update(record.Id, record);
            if (Handler.HasError())
                return;

            details.Select(detalle => new DetalleVenta
            {
                Id = detalle.Id,
                Cantidad = detalle.Cantidad,
                Descuento = detalle.Descuento,
                IdProducto = detalle.IdProducto,
                Precio = detalle.Precio,
                IdVenta = saved.Id
            })
            .ToList()
            .ForEach(detalle =>
            {
                if (Handler.HasError())
                    return;

                var dsaved = DetalleVentaDao.Update(detalle.Id, detalle);
            });
        }

        internal void DeleteVentaDetail(List<DetalleVentaView> toDelete)
        {
            toDelete.ForEach(x => DetalleVentaDao.Delete(x.Id));
        }

        public (Venta compra, DetalleVentaView[] detalles) GetVenta(int id)
        {
            if (id.Equals(default))
                return (new Venta(), new DetalleVentaView[0]);

            var venta = VentaDao.GetById(id);
            if (venta is null || venta.Id.Equals(default))
                return (new Venta(), new DetalleVentaView[0]);

            var detalles = DetalleVentaDao.GetByVentaId(id);
            if (detalles is null) detalles = new DetalleVenta[0];

            return (venta, detalles.Select(detalle =>
            {
                var producto = ProductoDao.GetById(detalle.IdProducto);

                return new DetalleVentaView
                {
                    Id = detalle.Id,
                    Cantidad = detalle.Cantidad,
                    Descuento = detalle.Descuento,
                    Precio = detalle.Precio,
                    Subtotal = detalle.Subtotal,
                    IdProducto = producto.Id,
                    Producto = producto.Descripcion
                };

            }).ToArray());
        }

        #endregion

        public string GetNombreEmpleado(int id)
        {
            var empleado = EmpleadoDao.GetById(id);
            if (empleado is null) return string.Empty;

            return ContactoDao.GetById(empleado.IdContacto)?.NombreCompleto ?? string.Empty;
        }

        public IEnumerable<ContactoSelectorView> GetProveedores()
        {
            return ProveedorDao.Read().Select(proveedor =>
            {
                var contacto = ContactoDao.GetById(proveedor.IdContactoJur);

                return new ContactoSelectorView
                {
                    Id = contacto.Id,
                    Nombre = contacto.NombreCompleto,
                    IdProveedor = proveedor.Id
                };
            });
        }

        public IEnumerable<ContactoSelectorView> GetClientes()
        {
            return ClienteDao.Read().Select(cliente =>
            {
                var contacto = ContactoDao.GetById(cliente.IdContacto);

                return new ContactoSelectorView
                {
                    Id = contacto.Id,
                    Nombre = contacto.NombreCompleto,
                    IdCliente = cliente.Id
                };
            });
        }

        public override void Dispose()
        {
            VentaDao.Dispose();
            DetalleVentaDao.Dispose();
            CompraDao.Dispose();
            DetalleCompraDao.Dispose();
            ContactoDao.Dispose();
            EmpleadoDao.Dispose();
            ClienteDao.Dispose();
            ProveedorDao.Dispose();

            Handler.Clear();
        }
    }
}
