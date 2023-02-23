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

        public BuscadorProductos()
        {
            Handler = new ErrorHandler();
            Service = new StockService(Handler);

            InitializeComponent();
            Reload();
        }

        protected override void OnAgregarClick(object sender, EventArgs e)
        {
            ShowEditor(default);
        }

        protected override void OnBuscarTxtChange(string query)
        {
            Reload();
        }

        protected override void OnEditarClick(object sender, EventArgs e)
        {
            var selected = GetSelected<ProductoView>();
            if (selected is null) return;

            ShowEditor(selected.Id);
        }

        protected override void OnEliminarClick(object sender, EventArgs e)
        {
            var selected = GetSelected<ProductoView>();
            if (selected is null) return;

            Service.DeleteProduct(selected.Id);
            Reload();
        }

        #region Private Methods

        private void Reload()
        {
            LoadDatagrid(Service.GetProductos(LastQuery));
        }

        private void ShowEditor(int id)
        {
            var editor = new EditorProductos();
            editor.FormClosed += Editor_FormClosed;
            editor.LoadRecord(id);
            editor.ShowDialog();
        }

        private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Reload();
        }

        #endregion
    }
}