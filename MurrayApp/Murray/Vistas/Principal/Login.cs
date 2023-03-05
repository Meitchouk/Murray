using Common.Util;
using Murray.Services.Identity;

using System;
using System.Windows.Forms;

// Namespace que contiene la clase Login
namespace Murray.Vistas
{
    // Clase Login que hereda de Form
    public partial class Login : Form
    {
        #region Dependencies

        // Campo de solo lectura para ErrorHandler, encargado de gestionar errores
        private readonly ErrorHandler Handler;

        // Campo de solo lectura para LoginService, encargado de manejar el inicio de sesión
        private readonly Services.Identity.Login Service;

        #endregion

        // Constructor de la clase Login
        public Login()
        {
            // Se asignan las dependencias por medio del constructor
            Handler = new ErrorHandler();
            Service = new Services.Identity.Login(Handler);

            // Se inicializan los componentes
            InitializeComponent();
        }

        // Evento de click del botón salir
        private void Exit(object sender, EventArgs args)
        {
            // Se finaliza la aplicación
            Application.Exit();
        }

        // Evento de click del botón iniciar sesión
        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Se llama al método DoLogin en el servicio de login y se le pasan las credenciales
            Service.DoLogin(txtUsuario.Text, txtContraseña.Text);

            // Si ocurrió un error en el servicio, se muestra un mensaje de error
            if (Handler.HasError())
            {
                MessageBox.Show(Handler.GetErrorMessage(), "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si no se logró establecer una sesión, se muestra un mensaje de error
            if (!Session.ActiveLogin)
            {
                MessageBox.Show("No se logro establecer inicio de sesion", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se instancia la vista Principal y se muestra
            Principal principal = new Principal();
            principal.Show();

            // Se cierra la vista actual de Login
            Close();
        }
    }
}

