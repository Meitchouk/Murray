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
        private readonly ErrorHandler Handler;
        private readonly TransactionService Service;
        private readonly StockService Stock;

        private Venta Record;
        private DetalleVentaView Current;
        private List<DetalleVentaView> Details;
        private List<DetalleVentaView> ToDelete;

        public EditorVentas()
        {
            Handler = new ErrorHandler();
            Service = new TransactionService(Handler);
            Stock = new StockService(Handler);

            InitializeComponent();

            Clientes.DataSource = Service.GetClientes().ToArray();
            Clientes.DisplayMember = nameof(INameable.Nombre);

            Productos.DataSource = Stock.GetProductos(string.Empty).ToArray();
            Productos.DisplayMember = nameof(INameable.Nombre);
        }

        #region Public Methods

        public void LoadRecord(int id)
        {
            var (venta, detalles) = Service.GetVenta(id);

            Record = venta;
            Details = detalles.ToList();
            Detalles.DataSource = detalles;

            var isNew = Record.Id.Equals(default);

            Empleado.Text = Service.GetNombreEmpleado(isNew ? Session.User.IdEmpleado : Record.IdEmpleado);
            if (isNew) return;

            var proveedores = (ContactoSelectorView[])Clientes.DataSource;
            Clientes.SelectedItem = proveedores.FirstOrDefault(x => x.IdProveedor == Record.IdCliente);
        }

        #endregion

        #region Private Methods

        private void ApplyChanges()
        {
            var isNew = Record.Id.Equals(default);
            if (isNew)
            {
                Record.IdEmpleado = Session.User.IdEmpleado;
                Record.Fecha = DateTime.Now;
            }

            if (Clientes.SelectedItem != null && Clientes.SelectedItem is ContactoSelectorView contacto)
                Record.IdCliente = contacto.IdCliente.Value;

            Details = ((DetalleVentaView[])Detalles.DataSource).ToList();
        }

        private DetalleVentaView GetSelected()
        {
            if (Detalles.SelectedRows.Count == 0)
                return new DetalleVentaView();

            var records = (DetalleVentaView[])Detalles.DataSource;
            return records[Detalles.SelectedRows[0].Index];
        }

        #endregion
        private void btnVender_Click(object sender, System.EventArgs e)
        {
            ApplyChanges();
            Service.SaveVenta(Record, Details);

            if (ToDelete != null && ToDelete.Any())
                Service.DeleteVentaDetail(ToDelete);

            Close();  
        }

        private void btnLimpiarVenta_Click(object sender, System.EventArgs e)
        {
            Close();         
        }

        private void btnEliminarProducto_Click(object sender, System.EventArgs e)
        {
            if (ToDelete is null)
                ToDelete = new List<DetalleVentaView>();

            if (!Current.Id.Equals(default))
                ToDelete.Add(Current);

            Details.Remove(Current);
            Detalles.DataSource = Details.ToArray();  
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            if (Current is null)
                Current = new DetalleVentaView();

            if (Productos.SelectedItem != null && Productos.SelectedItem is ProductoView producto)
            {
                Current.IdProducto = producto.Id;
                Current.Producto = producto.Nombre;
            }

            Current.Precio = (double)Precio.Value;
            Current.Cantidad = (int)Cantidad.Value;
            Current.Descuento = (double)Descuento.Value;
            Current.Subtotal = (Current.Precio * Current.Cantidad) - (Current.Descuento / 100 * (Current.Precio * Current.Cantidad));

            if (!Current.Id.Equals(default))
                Details.RemoveAll(x => x.Id == Current.Id);

            Details.Add(Current);
            Detalles.DataSource = Details.ToArray();
        }

        private void Detalles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Current = GetSelected();
            var productos = (ProductoView[])Productos.DataSource;
            Productos.SelectedItem = productos.FirstOrDefault(x => x.Id == Current.IdProducto);

            Precio.Value = (decimal)(Current.Precio < (double)Precio.Minimum ? (double)Precio.Minimum : (double)Current.Precio);
            Cantidad.Value = Current.Cantidad < Cantidad.Minimum ? Cantidad.Minimum : Current.Cantidad;
            Descuento.Value = (decimal)(Current.Descuento < (double)Descuento.Minimum ? (double)Descuento.Minimum : (double)Current.Descuento);
        }
    }
}
