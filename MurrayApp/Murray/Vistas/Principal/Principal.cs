using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Murray.Vistas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            pbRestaurar.Visible = false;
            pnlIzq.Visible = true;
            pbMaximizar.Visible = false;
            pbRestaurar.Visible = true;
        }

        #region Metodos externos
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWind, int wMsg, int wParam, int lParam);
        #endregion Metodos externos

        #region Funcionalidad personalizada
        private void ArrastrarVentana(object sender, MouseEventArgs args)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Salir(object sender, EventArgs args)
        {
            Application.Exit();
        }

        private void Maximizar(object sender, EventArgs args)
        {
            WindowState = FormWindowState.Maximized;
            pbMaximizar.Visible = false;
            pbRestaurar.Visible = true;
        }

        private void Restaurar(object sender, EventArgs args)
        {
            WindowState = FormWindowState.Normal;
            pbRestaurar.Visible = false;
            pbMaximizar.Visible = true;
        }

        private void Minimizar(object sender, EventArgs args)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ActivarMenu(object sender, EventArgs args)
        {
            if (pnlIzq.Visible)
            {
                pnlIzq.Visible = false;
            }
            else
            {
                menuTransitionMostrar.Show(pnlIzq);
                pnlIzq.Visible = true;
            }
        }

        private void Botones_MouseMove(object sender, MouseEventArgs args)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.Gray;
        }

        private void Botones_MouseLeave(object sender, EventArgs args)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.FromArgb(30, 30, 46);
        }
        #endregion Funcionalidad personalizada

        #region Insertar formularios
        private Form childForm = null;
        private void AddForm(Form current)
        {
            if (childForm != null)
            {
                childForm.Close();
            }

            childForm = current;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlPrincipal.Controls.Add(childForm);
            pnlPrincipal.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
        #endregion Insertar forumlarios

        private void BotonMenu_Click(object sender, EventArgs args)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton boton = (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender;
            string clave = boton.Tag.ToString();

            switch (clave)
            {
                case "Contactos":
                    AddForm(new Contactos.BuscadorContactos());
                    break;
                case "Ventas":
                    AddForm(new Ventas.BuscadorVentas());
                    break;
                case "Compras":
                    AddForm(new Compras.BuscadorCompras());
                    break;
                case "Productos":
                    AddForm(new Productos.BuscadorProductos());
                    break;
                case "Seguridad":
                    AddForm(new Usuarios.BuscadorUsuarios());
                    break;
                default:
                    MessageBox.Show(this, "No se encuentra el formulario especificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
