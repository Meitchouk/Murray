using Common.Util;
using Models.Interfaces;
using Models.Shopping;
using Murray.Services.Common;
using Murray.Services.Transacctions;
using Murray.ViewModels.Common;
using Murray.ViewModels.Shopping;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Murray.Vistas.Compras
{
    public partial class EditorCompras : Form
    {
        // Manejador de errores para reportar errores
        private readonly ErrorHandler Handler;
    
        // Servicio que encapsula la lógica de negocio para las transacciones
        private readonly TransactionService Service;
    
        // Servicio que encapsula la lógica de negocio para la administración de stock
        private readonly StockService Stock;
        
        // Objeto para almacenar la compra actualmente en edición
        private Compra Record;
        
        // Objeto para mantener el detalle de la compra en edición
        private DetalleCompraView Current;
        
        // Lista de los detalles de la compra a guardar
        private List<DetalleCompraView> Details;
        
        // Lista de detalles de la compra a eliminar
        private List<DetalleCompraView> ToDelete;
    
        public EditorCompras()
        {
            // Inicialización del manejador de errores
            Handler = new ErrorHandler();
            
            // Inicialización del servicio de transacciones
            Service = new TransactionService(Handler);
            
            // Inicialización del servicio de manejo de stock
            Stock = new StockService(Handler);
    
            InitializeComponent();
    
            // Se carga el combobox con la lista de proveedores
            Proveedores.DataSource = Service.GetProveedores().ToArray();
            Proveedores.DisplayMember = nameof(INameable.Nombre);
    
            //Se carga el combobox con la lista de productos
            Productos.DataSource = Stock.GetProductos(string.Empty).ToArray();
            Productos.DisplayMember = nameof(INameable.Nombre);
        }
    
        #region Public Methods

        public void LoadRecord(int id) 
        {
            // Recuperar la compra y sus detalles por su ID.
            var (compra, detalles) = Service.GetCompra(id);
            
            // Guardar los valores recuperados en variables internas de la clase Controller.
            Record = compra;
            Details = detalles.ToList();
            Detalles.DataSource = detalles;
        
            // Determinar si la Compra es nueva buscando si su ID es igual al valor predeterminado.
            var isNew = Record.Id.Equals(default);
        
            // Si esta Compra es nueva, mostrar el nombre del Empleado que inició sesión.
            Empleado.Text = Service.GetNombreEmpleado(isNew ? Session.User.IdEmpleado : Record.IdEmpleado);
        
            // Si no es una nueva Compra, seleccionar el nombre del proveedor en el combobox que corresponda a la Compra en cuestión.
            if (isNew) return;
        
            var proveedores = (ContactoSelectorView[])Proveedores.DataSource;
            Proveedores.SelectedItem = proveedores.FirstOrDefault(x => x.IdProveedor == Record.IdProveedor); 
        }
        

        #endregion

        #region Private Methods

        private void ApplyChanges()
        {
            var isNew = Record.Id.Equals(default); // Verifica si la compra es nueva
            if (isNew)
            {
                Record.IdEmpleado = Session.User.IdEmpleado; // Si es una nueva compra, se asigna el empleado de la sesión como el nuevo empleado de la compra
                Record.Fecha = DateTime.Now; // Se asigna la fecha actual como la fecha de la compra
            }
        
            if (Proveedores.SelectedItem != null && Proveedores.SelectedItem is ContactoSelectorView contacto) // verifica si un proveedor fue selecionado y cast lo a ContactoSelectorView
                Record.IdProveedor = contacto.IdProveedor.Value; // Asigna el Id del proveedor al registro
        
            Details = ((DetalleCompraView[])Detalles.DataSource).ToList();  // Actualiza la lista de detalles de la compra
        }
        
        private DetalleCompraView GetSelected()
        {
            if (Detalles.SelectedRows.Count == 0) // Verifica si hay filas seleccionadas
                return new DetalleCompraView(); // Si no hay filas seleccionadas devuelve una nueva instancia de DetalleCompraView
        
            var records = (DetalleCompraView[])Detalles.DataSource;
            return records[Detalles.SelectedRows[0].Index]; // Devuelve el item seleccionado en el datagrid
        }

        #endregion
        
        private void btnAgregarProducto_Click(object sender, System.EventArgs e)
        {
            if (Current is null)
                Current = new DetalleCompraView();
        
            if (Productos.SelectedItem != null && Productos.SelectedItem is ProductoView producto) // Verifica si un producto fue seleccionado y cast a ProductoView
            {
                Current.IdProducto = producto.Id; // Asigna el id del producto seleccionado
                Current.Producto = producto.Nombre; // Asigna el nombre del producto seleccionado
            }
        
        // Asigna los valores de precio, cantidad, descuento y subtotal al objeto Current
            Current.Precio = (double)Precio.Value;
            Current.Cantidad = (int)Cantidad.Value;
            Current.Descuento = (double)Descuento.Value;
            Current.Subtotal = (Current.Precio * Current.Cantidad) - (Current.Descuento / 100 * (Current.Precio * Current.Cantidad));
        
        // Si el id existe elimina el detalle con ese Id de la lista Details que contiene los detalles de la compra.
            if (!Current.Id.Equals(default))
                Details.RemoveAll(x => x.Id == Current.Id);
        
            Details.Add(Current);
            Detalles.DataSource = Details.ToArray(); // Asigna los datos de la lista de detalles al DataGridView
        }
        
        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
        // Agrega el item actual a la lista ToDelete para su posterior eliminación
            if (ToDelete is null)
                ToDelete = new List<DetalleCompraView>();
            if (!Current.Id.Equals(default))
                ToDelete.Add(Current);
        
            Details.Remove(Current); // Elimina el item actual de la lista Details
            Detalles.DataSource = Details.ToArray(); // Actualizando el DataGridView
        }
        
        private void btnComprar_Click(object sender, System.EventArgs e)
        {
            ApplyChanges();
            Service.SaveCompra(Record, Details); // Guarda los cambios realizados a la compra con los detalles.
        
        // Se eliminan todos los elementos almacenados en ToDelete.
            if (ToDelete != null && ToDelete.Any())
                Service.DeleteCompraDetail(ToDelete);
        
            Close(); // Cierra la ventana del editor de compras
        }
        

        
        private void btnCancelar_Click(object sender, System.EventArgs e) //Evento Click el botón Cancelar
        {
            Close(); // Cerrar el formulario 
        } 
        
        private void Detalles_RowEnter(object sender, DataGridViewCellEventArgs e) //Evento RowEnter del control DataGridView llamado Detalles 
        {
            Current = GetSelected(); //Obtener el objeto seleccionado en Detalles y guardarlo en la variable Current.
            var productos = (ProductoView[])Productos.DataSource;  
            Productos.SelectedItem = productos.FirstOrDefault(x => x.Id == Current.IdProducto); // Establecer en el combo box el producto correspondiente
        
            Precio.Value = (decimal)(Current.Precio < (double)Precio.Minimum ? (double)Precio.Minimum : (double)Current.Precio); 
            Cantidad.Value = Current.Cantidad < Cantidad.Minimum ? Cantidad.Minimum : Current.Cantidad;  //Asignar los valores de cantidad y descuento en la vista.
            Descuento.Value = (decimal)(Current.Descuento < (double)Descuento.Minimum ? (double)Descuento.Minimum : (double)Current.Descuento);
        }
        
    }
}
