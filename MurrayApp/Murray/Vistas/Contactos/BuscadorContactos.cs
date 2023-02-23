using Common.Util;
using Murray.Services.Common;
using Murray.ViewModels.Common;
using Murray.Vistas.Base;
using System;

namespace Murray.Vistas.Contactos
{
    public partial class BuscadorContactos : Buscador
    {
        private readonly ErrorHandler Handler;
        private readonly ContactosService Service;

        public BuscadorContactos()
        {
            Handler = new ErrorHandler();
            Service = new ContactosService(Handler);

            InitializeComponent();
            LoadDatagrid(Service.GetContactos(string.Empty));
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
            var selected = GetSelected<ContactoView>();
            if (selected is null) return;

            ShowEditor(selected.Id);
        }

        protected override void OnEliminarClick(object sender, EventArgs e)
        {
            var selected = GetSelected<ContactoView>();
            if (selected is null) return;

            Service.DeleteContact(selected.Id);
            Reload();
        }

        #region Private Methods

        private void Reload()
        {
            LoadDatagrid(Service.GetContactos(LastQuery));
        }

        private void ShowEditor(int id)
        {
            var editor = new EditorContactos();
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
