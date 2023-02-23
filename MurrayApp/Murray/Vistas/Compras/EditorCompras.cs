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
        private readonly ErrorHandler Handler;
        private readonly TransactionService Service;
        private readonly StockService Stock;

        private Compra Record;
        private DetalleCompraView Current;
        private List<DetalleCompraView> Details;
        private List<DetalleCompraView> ToDelete;

        public EditorCompras()
        {
            Handler = new ErrorHandler();
            Service = new TransactionService(Handler);
            Stock = new StockService(Handler);

            InitializeComponent();

            Proveedores.DataSource = Service.GetProveedores().ToArray();
            Proveedores.DisplayMember = nameof(INameable.Nombre);

            Productos.DataSource = Stock.GetProductos(string.Empty).ToArray();
            Productos.DisplayMember = nameof(INameable.Nombre);
        }

        #region Public Methods

        public void LoadRecord(int id)
        {
            var (compra, detalles) = Service.GetCompra(id);
            
            Record = compra;
            Details = detalles.ToList();
            Detalles.DataSource = detalles;

            var isNew = Record.Id.Equals(default);

            Empleado.Text = Service.GetNombreEmpleado(isNew ? Session.User.IdEmpleado : Record.IdEmpleado);
            if (isNew) return;

            var proveedores = (ContactoSelectorView[])Proveedores.DataSource;
            Proveedores.SelectedItem = proveedores.FirstOrDefault(x => x.IdProveedor == Record.IdProveedor); 
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

            if (Proveedores.SelectedItem != null && Proveedores.SelectedItem is ContactoSelectorView contacto)
                Record.IdProveedor = contacto.IdProveedor.Value;

            Details = ((DetalleCompraView[])Detalles.DataSource).ToList();
        }

        private DetalleCompraView GetSelected()
        {
            if (Detalles.SelectedRows.Count == 0)
                return new DetalleCompraView();

            var records = (DetalleCompraView[])Detalles.DataSource;
            return records[Detalles.SelectedRows[0].Index];
        }

        #endregion

        private void btnAgregarProducto_Click(object sender, System.EventArgs e)
        {
            if (Current is null)
                Current = new DetalleCompraView();

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

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (ToDelete is null)
                ToDelete = new List<DetalleCompraView>();

            if (!Current.Id.Equals(default))
                ToDelete.Add(Current);

            Details.Remove(Current);
            Detalles.DataSource = Details.ToArray();
        }

        private void btnComprar_Click(object sender, System.EventArgs e)
        {
            ApplyChanges();
            Service.SaveCompra(Record, Details);

            if (ToDelete != null && ToDelete.Any())
                Service.DeleteCompraDetail(ToDelete);

            Close();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
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
