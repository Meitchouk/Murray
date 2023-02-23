using Common.Util;
using Murray.Services.Identity;
using Murray.ViewModels.Identity;
using Murray.Vistas.Base;
using Murray.Vistas.Contactos;
using System;

namespace Murray.Vistas.Usuarios
{
    public partial class BuscadorUsuarios : Buscador
    {
        private readonly ErrorHandler Handler;
        private readonly UserService Service;

        public BuscadorUsuarios()
        {
            Handler = new ErrorHandler();
            Service = new UserService(Handler);

            InitializeComponent();
            Reload();

            // Special case
            HideAgregarBtn();
            HideEliminarBtn();
        }

        protected override void OnAgregarClick(object sender, EventArgs e)
        {
            // Do nothing
        }

        protected override void OnBuscarTxtChange(string query)
        {
            Reload();
        }

        protected override void OnEditarClick(object sender, EventArgs e)
        {
            var selected = GetSelected<UsuarioView>();
            if (selected is null) return;

            ShowEditor(selected.IdContacto);
        }

        protected override void OnEliminarClick(object sender, EventArgs e)
        {
            // Do nothing
        }

        #region Private Methods

        private void Reload()
        {
            LoadDatagrid(Service.GetUsers(LastQuery));
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
