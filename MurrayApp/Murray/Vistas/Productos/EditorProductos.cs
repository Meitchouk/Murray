using Common.Util;
using Models.Interfaces;
using Murray.Services.Common;

using System;
using System.Linq;
using System.Windows.Forms;

namespace Murray.Vistas.Productos
{
    public partial class EditorProductos : Form
    {
        private readonly ErrorHandler Handler;
        private readonly StockService Service;

        /// <summary>
        ///     Registro a interactuar
        /// </summary>
        private Models.Common.Producto Record;

        public EditorProductos()
        {
            Handler = new ErrorHandler();
            Service = new StockService(Handler);

            InitializeComponent();

            Categorias.DataSource = Service.GetCategorias().ToArray();
            Categorias.DisplayMember = nameof(INameable.Nombre);
        }

        #region Public Methods

        public void LoadRecord(int id)
        {
            var isNew = id.Equals(default);
            Record = isNew ? new Models.Common.Producto() : Service.GetProduct(id);
            if (isNew) return;

            var categorias = (Models.Common.Categoria[])Categorias.DataSource;

            Descripcion.Text = Record.Descripcion;
            Precio.Value = Record.Precio;
            Categorias.SelectedItem = categorias.FirstOrDefault(x => x.Id == Record.IdCategoria);
        }

        #endregion

        #region Private Methods

        private void ApplyChanges()
        {
            if (Record is null)
                Record = new Models.Common.Producto();

            Record.Descripcion = Descripcion.Text;
            Record.Precio = Precio.Value;
            Record.Estado = true;

            if (Categorias.SelectedItem != null && Categorias.SelectedItem is Models.Common.Categoria categoria)
                Record.IdCategoria = categoria.Id;
        }

        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            Service.SaveProduct(Record);
            Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlInfoProducto_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
