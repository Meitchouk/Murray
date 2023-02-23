using Common.Util;
using Murray.Services.Transacctions;
using Murray.ViewModels.Shopping;
using Murray.Vistas.Base;
using System;

namespace Murray.Vistas.Compras
{
    public partial class BuscadorCompras : Buscador
    {
        private readonly ErrorHandler Handler;
        private readonly TransactionService Service;

        public BuscadorCompras()
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
            var selected = GetSelected<CompraView>();
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
            LoadDatagrid(Service.GetCompras(LastQuery));
        }

        private void ShowEditor(int id)
        {
            var editor = new EditorCompras();
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
