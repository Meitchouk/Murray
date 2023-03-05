using Common.Util;
using Models.Interfaces;
using Models.Sale;
using Murray.Services.Common;
using Murray.Services.Transacctions;
using Murray.ViewModels.Common;
using Murray.ViewModels.Sales;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Murray.Vistas.Ventas
{
    public partial class EditorVentas : Form
    {
        private readonly ErrorHandler Handler;  // Manejador de errores
        private readonly TransactionService Service;  // Servicio de transacciones
        private readonly StockService Stock;  // Servicio de inventario
        
        private Venta Record;  // Registro de venta
        private DetalleVentaView Current;  // Vista del detalle de venta actual
        private List<DetalleVentaView> Details;  // Lista de detalles de ventas
        private List<DetalleVentaView> ToDelete;  // Lista de detalles de ventas por eliminar
        
        public EditorVentas()
        {
            Handler = new ErrorHandler();  // Inicializar el manejador de errores
            Service = new TransactionService(Handler);  // Inicializar el servicio de transacciones con el manejador de errores
            Stock = new StockService(Handler);  // Inicializar el servicio de inventario con el manejador de errores
        
            InitializeComponent();  // Inicializar los componentes del formulario
        
            // Configurar la fuente de datos para el control 'Clientes'
            Clientes.DataSource = Service.GetClientes().ToArray();
            Clientes.DisplayMember = nameof(INameable.Nombre);
        
            // Configurar la fuente de datos para el control 'Productos'
            Productos.DataSource = Stock.GetProductos(string.Empty).ToArray();
            Productos.DisplayMember = nameof(INameable.Nombre);
        }
        
        #region Public Methods
        
        // Cargar un registro de venta existente
        public void LoadRecord(int id)
        {
            var (venta, detalles) = Service.GetVenta(id);
        
            Record = venta;
            Details = detalles.ToList();
            Detalles.DataSource = detalles;
        
            var isNew = Record.Id.Equals(default);
        
            Empleado.Text = Service.GetNombreEmpleado(isNew ? Session.User.IdEmpleado : Record.IdEmpleado);
        
            // Si es un nuevo registro, no se necesita agregar información adicional
            if (isNew) return;
        
            var clientes = (ContactoSelectorView[])Clientes.DataSource;
            Clientes.SelectedItem = clientes.FirstOrDefault(x => x.IdProveedor == Record.IdCliente);
        }
        
        #endregion
        
        #region Private Methods
        
        // Aplicar cambios realizados en el formulario al registro de venta
        private void ApplyChanges()
        {
            var isNew = Record.Id.Equals(default);
        
            // Si es un nuevo registro, se agregan datos adicionales como la fecha y el empleado responsable
            if (isNew)
            {
                Record.IdEmpleado = Session.User.IdEmpleado;
                Record.Fecha = DateTime.Now;
            }
        
            // Se actualiza el ID del cliente asignado al registro
            if (Clientes.SelectedItem != null && Clientes.SelectedItem is ContactoSelectorView contacto)
                Record.IdCliente = contacto.IdCliente.Value;
        
            // Se actualizan los detalles de venta con los datos del control 'Detalles'
            Details = ((DetalleVentaView[])Detalles.DataSource).ToList();
        }
        
        // Obtener el detalle de venta seleccionado en el control 'Detalles'
        private DetalleVentaView GetSelected()
        {
            if (Detalles.SelectedRows.Count == 0)
                return new DetalleVentaView();
        
            var registros = (DetalleVentaView[])Detalles.DataSource;
            return registros[Detalles.SelectedRows[0].Index];
        }
        
        #endregion
        
        // Guardar los cambios realizados en el registro de venta
        private void btnVender_Click(object sender, System.EventArgs e)
        {
            ApplyChanges();  // Aplicar cambios realizados
            Service.SaveVenta(Record, Details);  // Guardar cambios en el registro de venta
        
            // Si hay detalles de venta pendientes por eliminar, se eliminan del servicio
            if (ToDelete != null && ToDelete.Any())
                Service.DeleteVentaDetail(ToDelete);
        
            Close();  // Cerrar el formulario después de guardar los cambios
        }
        
        // Restaurar los valores iniciales del formulario y cerrarlo
        private void btnLimpiarVenta_Click(object sender, System.EventArgs e)
        {
            Close();  // Cerrar el formulario sin guardar cambios
        }
        
        // Eliminar un detalle de venta del registro actual
        private void btnEliminarProducto_Click(object sender, System.EventArgs e)
        {
            // Si no existe una lista de detalles de venta pendientes por eliminar, se crea una
            if (ToDelete is null)
                ToDelete = new List<DetalleVentaView>();
        
            // Si el detalle de venta seleccionado ya existe, se agrega a la lista de pendientes por eliminar
            if (!Current.Id.Equals(default))
                ToDelete.Add(Current);
        
            // Se elimina el detalle de venta seleccionado del control 'Detalles'
            Details.Remove(Current);
            Detalles.DataSource = Details.ToArray();  
        } 

        // Método que se ejecuta cuando se hace clic en el botón Agregar. Agrega un nuevo registro o actualiza uno existente a la lista de detalles.
        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            // Se verifica si el objeto actual es nulo y se crea una nueva instancia si lo es.
            if (Current is null)
                Current = new DetalleVentaView();
        
            // Si se ha seleccionado un producto de la lista, se establecen sus valores correspondientes en el objeto actual.
            if (Productos.SelectedItem != null && Productos.SelectedItem is ProductoView producto)
            {
                Current.IdProducto = producto.Id;
                Current.Producto = producto.Nombre;
            }
        
            // Se establecen los valores de Precio, Cantidad, Descuento y Subtotal en el objeto actual.
            Current.Precio = (double)Precio.Value;
            Current.Cantidad = (int)Cantidad.Value;
            Current.Descuento = (double)Descuento.Value;
            Current.Subtotal = (Current.Precio * Current.Cantidad) - (Current.Descuento / 100 * (Current.Precio * Current.Cantidad));
        
            // Si el objeto actual ya existe en la lista de detalles, se remueve su referencia anterior.
            if (!Current.Id.Equals(default))
                Details.RemoveAll(x => x.Id == Current.Id);
        
            // Se agrega el objeto actual a la lista de detalles.
            Details.Add(Current);
            Detalles.DataSource = Details.ToArray(); // Se actualiza la fuente de datos del control DataGridView.
        }
        
        // Método que se ejecuta cuando se cambia la selección de una fila en el control DataGridView Detalles. Establece los valores de los controles según los valores del objeto actualmente seleccionado.
        private void Detalles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Se obtiene el objeto actualmente seleccionado en el DataGridView.
            Current = GetSelected();
        
            // Se busca en la lista de productos el elemento con Id igual al del objeto actual y se establece como seleccionado en el control ComboBox Productos.
            var productos = (ProductoView[])Productos.DataSource;
            Productos.SelectedItem = productos.FirstOrDefault(x => x.Id == Current.IdProducto);
        
            // Se establecen los valores de Precio, Cantidad y Descuento en los controles NumericUpDown.
            Precio.Value = (decimal)(Current.Precio < (double)Precio.Minimum ? (double)Precio.Minimum : (double)Current.Precio);
            Cantidad.Value = Current.Cantidad < Cantidad.Minimum ? Cantidad.Minimum : Current.Cantidad;
            Descuento.Value = (decimal)(Current.Descuento < (double)Descuento.Minimum ? (double)Descuento.Minimum : (double)Current.Descuento);
        }
        
    }
}
