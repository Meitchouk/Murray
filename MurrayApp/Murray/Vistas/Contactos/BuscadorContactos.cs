using Common.Util;
using Murray.Services.Common;
using Murray.ViewModels.Common;
using Murray.Vistas.Base;
using System;

namespace Murray.Vistas.Contactos
{
    public partial class BuscadorContactos : Buscador
    {
        private readonly ErrorHandler Handler; // Manejador de errores
        private readonly ContactosService Service; // Servicio de contactos

        public BuscadorContactos()
        {
            Handler = new ErrorHandler(); // Inicializar manejador de errores
            Service = new ContactosService(Handler); // Inicializar servicio de contactos

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

        #region Métodos privados

        // Método para actualizar la tabla
        private void Reload()
        {
            LoadDatagrid(Service.GetContactos(LastQuery)); // Cargar contactos
        }

        // Método para mostrar el formulario de edición de contactos
        private void ShowEditor(int id)
        {
            var editor = new EditorContactos(); 
            editor.FormClosed += Editor_FormClosed;
            editor.LoadRecord(id);
            editor.ShowDialog();
        }

        // Método que se ejecuta al cerrar el formulario de edición y que actualiza la tabla de contactos
        private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Reload();
        }

        #endregion
    }
}

