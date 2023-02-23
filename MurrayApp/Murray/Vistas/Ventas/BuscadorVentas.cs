using Common.Util;
using Murray.Services.Transacctions;
using Murray.ViewModels.Sales;
using Murray.Vistas.Base;
using System;

namespace Murray.Vistas.Ventas
{
    public partial class BuscadorVentas : Buscador
    {
        private readonly ErrorHandler Handler;
        private readonly TransactionService Service;

        public BuscadorVentas()
        {
            Handler = new ErrorHandler();
            Service = new TransactionService(Handler);

            InitializeComponent();
            Reload();

            // Special case
            HideEliminarBtn();
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
            var selected = GetSelected<VentaView>();
            if (selected is null) return;

            ShowEditor(selected.Id);
        }

        protected override void OnEliminarClick(object sender, EventArgs e)
        {
            // Do nothing
        }

        #region Private Methods

        private void Reload()
        {
            LoadDatagrid(Service.GetVentas(LastQuery));
        }

        private void ShowEditor(int id)
        {
            var editor = new EditorVentas();
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
