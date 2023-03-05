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
        // Declaramos todos los campos privados que ocuparemos con formato de readonly para que su valor no pueda ser modificado 
        // y asi tener una mejor encapsulacion
        private readonly IVentaDao VentaDao;
        private readonly IDetalleVentaDao DetalleVentaDao;
        private readonly ICompraDao CompraDao;
        private readonly IDetalleCompraDao DetalleCompraDao;
        private readonly IEmpleadoDao EmpleadoDao;
        private readonly IProveedorDao ProveedorDao;
        private readonly IClienteDao ClienteDao;
        private readonly IContactoDao ContactoDao;
        private readonly IProductoDao ProductoDao;

        // La clase TransactionService hereda propiedades de la clase ServiceBase que contiene el ErrorHandler
        // Creamos la clase TransactionService con parametro 'handler' tipo ErrorHandler en su constructor
        public TransactionService(ErrorHandler handler) : base(handler)
        {
            // Obtenemos los DAO correspondientes y los inicializamos con los errores manejados por 'handler'
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
            // Chequea si la consulta está en blanco o es nula
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            // Llama a la función Read del objeto CompraDao y devuelve una lista de compras y luego las transforma usando 
            // la funcion Select para formatear cada compra con una vista personalizada
            return CompraDao.Read(query).Select(compra =>
            {
                // Obtiene los detalles de cada compra usando el DetalleCompraDao, los convierte en una lista y calcula su 
                // subtotal usando la función .Sum().
                var detalles = DetalleCompraDao.GetByCompraId(compra.Id).ToList();
                var subtotal = detalles.Sum(x => x.Subtotal);

                // Obtiene los datos del proveedor y empleado de esta compra
                var proveedor = ProveedorDao.GetById(compra.IdProveedor);
                var empleado = EmpleadoDao.GetById(compra.IdEmpleado);

                //Obtiene los datos de contacto del proveedor y empleado respectivamente.
                var cproveedor = ContactoDao.GetById(proveedor.IdContactoJur);
                var cempleado = ContactoDao.GetById(empleado.IdContacto);

                // Devuelve un nuevo objeto CompraView con los datos de la compra formateados segun los requerimientos.
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
            // Verifica si la compra ya existe o es una nueva; crea o actualiza según corresponda.
            var saved = record.Id.Equals(default) ? CompraDao.Create(record) : CompraDao.Update(record.Id, record);
            
            // Retorna si ocurre un error durante la creación o actualización de la compra.
            if (Handler.HasError())
                return;
        
            // Convierte de DetalleCompraView a DetalleCompra y les asigna el id de la compra guardada.
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
            // Itera por cada detalle y verifica si es necesario crear o actualizar.
            .ForEach(detalle =>
            {
                // Retorna si ocurre un error durante la creación o actualización del detalle.
                if (Handler.HasError())
                    return;
        
                var dsaved = detalle.Id.Equals(default) ? DetalleCompraDao.Create(detalle) : DetalleCompraDao.Update(detalle.Id, detalle);
            });
        }
        
        internal void DeleteCompraDetail(List<DetalleCompraView> toDelete)
        {
            // Eliminamos los detalles de compra recibidos en la lista "toDelete" uno por uno usando el metodo "Delete" 
            // del objeto DetalleCompraDao
            toDelete.ForEach(x => DetalleCompraDao.Delete(x.Id));
        }
        
        public (Compra compra, DetalleCompraView[] detalles) GetCompra(int id)
        {
            // Si no se ha especificado un ID, devolvemos dos listas vacias.
            if (id.Equals(default))
                return (new Compra(), new DetalleCompraView[0]);
        
            // Obtenemos la compra y los detalles correspondientes al ID proporcionado
            var compra = CompraDao.GetById(id);
            if (compra is null || compra.Id.Equals(default))
                return (new Compra(), new DetalleCompraView[0]);
        
            var detalles = DetalleCompraDao.GetByCompraId(id);
            if (detalles is null) detalles = new DetalleCompra[0];
        
            // mappea cada objeto detalle obtenido en una vista simplificada llamada DetalleCompraView 
            // retorna la tupla que contiene la información de la compra y los detalles obtenidos
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
            // verificación si la variable 'query' es nula, vacía o constituida solo por espacios en blanco. Si esto es cierto, se asgina valor nulo a 'query'
            if (string.IsNullOrWhiteSpace(query))
                query = null;
        
            // Se realiza una lectura de las ventas desde el Dao y se selecciona cada una junto con sus detalles de venta correspondientes.
            return VentaDao.Read(query).Select(venta =>
            {
                var detalles = DetalleVentaDao.GetByVentaId(venta.Id).ToList(); // obtiene los detalles de la venta para el id especificado y los convierte en una lista
                var subtotal = detalles.Sum(x => x.Subtotal); //suma el total de todos los subtotales de cada detalle obtenido.
        
                //Se obtiene el empleado y el cliente correspondiente a esta venta y se convierten sus identificadores en datos legibles
                var cliente = ClienteDao.GetById(venta.IdCliente);
                var empleado = EmpleadoDao.GetById(venta.IdEmpleado);
        
                //Detalles de contacto tanto del cliente como del empleado al que se le asignó la venta. 
                var ccliente = ContactoDao.GetById(cliente.IdContacto);
                var cempleado = ContactoDao.GetById(empleado.IdContacto);
        
                //se retorna un nuevo objeto de VentaView con las propidades correspondientes que serán asignadas de acuerdo a lo que fue recuperado de la base de datos.
                return new VentaView
                {
                    Id = venta.Id,
                    Fecha = venta.Fecha.ToShortDateString(),
                    Productos = detalles.Count,
                    Cantidad = detalles.Sum(x => x.Cantidad),
                    Subtotal = subtotal,
                    Total = Math.Round(subtotal * 1.15), //Se determina el precio total (subtotales y tasas de impuesto incluidas), en este caso se establece un IVA del 15%
                    Cliente = ccliente.NombreCompleto,
                    Empleado = cempleado.NombreCompleto
                };
            });
        }
        

        internal void SaveVenta(Venta record, List<DetalleVentaView> details)
        {
            // Se verifica si el ID del registro es nulo (default),
            // si es así, se crea un nuevo registro, de lo contrario 
            // se actualiza el existente
            var saved = record.Id.Equals(default) ? VentaDao.Create(record) : VentaDao.Update(record.Id, record);
        
            // Si se produce un error, se termina la ejecución de la función
            if (Handler.HasError())
                return;
        
             // Se itera cada objeto "DetalleVentaView" de la lista "details",
             // generando un objeto "DetalleVenta" y se le asigna el ID de
             // la venta guardada previamente.
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
                // Si se produce un error, se termina la iteración
                // y no se guarda el registro actual
                if (Handler.HasError())
                    return;
        
                 // Se verifica si el ID del registro es nulo (default),
                 // si es así, se crea un nuevo registro, de lo contrario 
                 // se actualiza el existente
                var dsaved = DetalleVentaDao.Update(detalle.Id, detalle);
            });
        }
        

       internal void DeleteVentaDetail(List<DetalleVentaView> toDelete)
       {
           // Itera sobre la lista 'toDelete' eliminando cada detalle de venta utilizando su ID.
           toDelete.ForEach(x => DetalleVentaDao.Delete(x.Id));
       }
       
       public (Venta compra, DetalleVentaView[] detalles) GetVenta(int id)
       {
           // Si el ID es null o vacío, retorna una nueva Venta y un array vacío de DetalleVentaView.
           if (id.Equals(default))
               return (new Venta(), new DetalleVentaView[0]);
       
           // Busca una venta por su ID.
           var venta = VentaDao.GetById(id);
           
           // Si la venta no existe o su ID es null, retorna una nueva Venta y un array vacío de DetalleVentaView.
           if (venta is null || venta.Id.Equals(default))
               return (new Venta(), new DetalleVentaView[0]);
       
           // Busca los detalles de la venta por su ID.
           var detalles = DetalleVentaDao.GetByVentaId(id);
       
           // Si los detalles de la venta son null, crea un array vacío de DetalleVenta.
           if (detalles is null) detalles = new DetalleVenta[0];
       
           // Retorna la venta y sus detalles llevados a DetalleVentaView usando Linq.
           return (
               venta,
               detalles.Select(detalle =>
               {
                   var producto = ProductoDao.GetById(detalle.IdProducto);
       
                   // Crea y retorna una instancia de DetalleVentaView utilizando el DetalleVenta actual y el Producto asociado.
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
               }).ToArray()
           );
       }
       

        #endregion

       public string GetNombreEmpleado(int id)
       {
           // Obtiene el empleado correspondiente al ID proporcionado
           var empleado = EmpleadoDao.GetById(id);
       
           // Si no se encuentra un empleado con el ID proporcionado, regresa cadena vacía
           if (empleado is null) return string.Empty;
       
           // Retorna el nombre completo del contacto correspondiente al empleado,
           // si no se encuentra dicho contacto, regresa cadena vacía
           return ContactoDao.GetById(empleado.IdContacto)?.NombreCompleto ?? string.Empty;
       }
       
       public IEnumerable<ContactoSelectorView> GetProveedores()
       {
           // Obtiene todos los proveedores almacenados y por cada uno de ellos
           // obtiene la información del contacto correspondiente
           return ProveedorDao.Read().Select(proveedor =>
           {
               var contacto = ContactoDao.GetById(proveedor.IdContactoJur);
       
               // Crea un objeto de vista de selector para el contacto obtenido
               return new ContactoSelectorView
               {
                   Id = contacto.Id,
                   Nombre = contacto.NombreCompleto,
                   IdProveedor = proveedor.Id
               };
           });
       }
       

        // Retorna una lista de ContactoSelectorView presentando información acerca de todos los clientes disponibles utilizando la tabla ClienteDao
        public IEnumerable<ContactoSelectorView> GetClientes()
        {
            return ClienteDao.Read().Select(cliente =>
            {
                // Se obtiene el contacto correspondiente al cliente actual en el loop utilizando su id obtenido desde la tabla cliente
                var contacto = ContactoDao.GetById(cliente.IdContacto);
        
                // Se crea una nueva instancia del modelo ContactoSelectorView para almacenar y presentar los datos necesarios
                return new ContactoSelectorView
                {
                    Id = contacto.Id,
                    Nombre = contacto.NombreCompleto,
                    IdCliente = cliente.Id
                };
            });
        }
        
        // Método que libera los recursos no administrados utilizados por la clase actual mediante la implementación de IDisposable.
        // Limpia el Handler y dispone de cada Dao presente en esta clase.
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
