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
    
            // Se declara un constructor para la clase 
            public BuscadorUsuarios()
            {
                // Manejador de errores que se utiliza en la aplicación.
                Handler = new ErrorHandler();
                // Servicio que maneja la lógica de los usuarios.
                Service = new UserService(Handler);
    
                InitializeComponent();
                Reload();
    
                // Caso especial 
                HideAgregarBtn();
                HideEliminarBtn();
            }
    
            protected override void OnAgregarClick(object sender, EventArgs e)
            {
                // No hace nada ya que esta funcionalidad no está disponible para este formulario.
            }
    
            protected override void OnBuscarTxtChange(string query)
            {
                // Vuelve a cargar el datagrid con la información actualizada del usuario.
                Reload();
            }
    
            protected override void OnEditarClick(object sender, EventArgs e)
            {
                var selected = GetSelected<UsuarioView>();
                if (selected is null) return;
    
                // Abre el editor de contactos pasando como parámetro el identificador del usuario seleccionado
                ShowEditor(selected.IdContacto);
            }
    
            protected override void OnEliminarClick(object sender, EventArgs e)
            {
                //No hace nada ya que esta funcionalidad no está disponible para este formulario.
            }
    
            #region Private Methods
    
            // Método privado que se encarga de volver a cargar el datagrid
            private void Reload()
            {
                LoadDatagrid(Service.GetUsers(LastQuery));
            }
    
            // Método privado que se encarga de mostrar el editor de contactos
            private void ShowEditor(int id)
            {
                var editor = new EditorContactos();
                editor.FormClosed += Editor_FormClosed;
                editor.LoadRecord(id);
                editor.ShowDialog();
            }
    
            // Manejador para el evento FormClosed del editor de contactos.
            private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
            {
                // Vuelve a cargar el datagrid con la información actualizada del usuario.
                Reload();
            }
    
            #endregion
        }
    
}
