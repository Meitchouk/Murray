using Common.Util;
using Murray.Services.Common;
using Murray.ViewModels.Common;
using Murray.Vistas.Base;
using System;

namespace Murray.Vistas.Productos
{
    public partial class BuscadorProductos : Buscador
    {
        private readonly ErrorHandler Handler;
        private readonly StockService Service;

        // Constructor de la clase, crea una instancia de ErrorHandler y StockService.
        public BuscadorProductos()
        {
            Handler = new ErrorHandler();
            Service = new StockService(Handler);

            InitializeComponent();
            Reload();
        }

        // Método que se ejecuta cuando se presiona el botón "Agregar".
        protected override void OnAgregarClick(object sender, EventArgs e)
        {
            ShowEditor(default);
        }

        // Método que se ejecuta cuando cambia el texto del cuadro de búsqueda.
        protected override void OnBuscarTxtChange(string query)
        {
            Reload();
        }

        // Método que se ejecuta cuando se presiona el botón "Editar".
        protected override void OnEditarClick(object sender, EventArgs e)
        {
            var selected = GetSelected<ProductoView>();
            if (selected is null) return;

            ShowEditor(selected.Id);
        }

        // Método que se ejecuta cuando se presiona el botón "Eliminar".
        protected override void OnEliminarClick(object sender, EventArgs e)
        {
            var selected = GetSelected<ProductoView>();
            if (selected is null) return;

            Service.DeleteProduct(selected.Id);
            Reload();
        }

        // Método privado que se encarga de recargar los datos del datagridview.
        private void Reload()
        {
            LoadDatagrid(Service.GetProductos(LastQuery));
        }

        // Método privado que se encarga de mostrar la ventana de edición.
        private void ShowEditor(int id)
        {
            var editor = new EditorProductos();
            editor.FormClosed += Editor_FormClosed;
            editor.LoadRecord(id);
            editor.ShowDialog();
        }        

        // Método privado que se encarga de recargar los datos cuando se cierra la ventana de edición.
        private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Reload();
        }
    }
}
