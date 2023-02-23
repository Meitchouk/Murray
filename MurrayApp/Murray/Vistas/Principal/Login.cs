using Common.Util;
using Murray.Services.Identity;

using System;
using System.Windows.Forms;

namespace Murray.Vistas
{
    public partial class Login : Form
    {
        #region Dependencies

        /// <summary>
        ///     Administración de errores
        /// </summary>
        private readonly ErrorHandler Handler;

        /// <summary>
        ///     Servicio de inicio de sesion
        /// </summary>
        private readonly Services.Identity.Login Service;

        #endregion

        public Login()
        {
            Handler = new ErrorHandler();
            Service = new Services.Identity.Login(Handler);

            InitializeComponent();
        }

        private void Exit(object sender, EventArgs args)
        {
            Application.Exit();
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            Service.DoLogin(txtUsuario.Text, txtContraseña.Text);

            if (Handler.HasError())
            {
                MessageBox.Show(Handler.GetErrorMessage(), "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Session.ActiveLogin)
            {
                MessageBox.Show("No se logro establecer inicio de sesion", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Principal principal = new Principal();
            principal.Show();

            Close();
        }
    }
}
