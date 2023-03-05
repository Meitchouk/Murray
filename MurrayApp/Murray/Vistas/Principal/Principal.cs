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
            InitializeComponent(); // Inicializa los componentes del formulario principal.
            EstadoInicial(); // Llama al método "EstadoInicial()" para establecer el estado inical del formulario.
        }
        
        private void EstadoInicial()
        {
            pbRestaurar.Visible = false; // Establece la visibilidad del botón "restaurar" en falso.
            pnlIzq.Visible = true; // Establece la visibilidad del panel izquierdo en verdadero.
            pbMaximizar.Visible = false; // Establece la visibilidad del botón "maximizar"en falso.
            pbRestaurar.Visible = true; // Establece la visibilidad del botón "restaurar" en verdadero.
        }
        
        #region Metodos externos
        
        //Importa ReleaseCapture desde el dll user32.
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        
        //Importa SendMessage desde el dll user32.
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWind, int wMsg, int wParam, int lParam);
        
        #endregion
        
        
        #region Funcionalidad personalizada
        
        /// <summary>
        /// Funcion que se encarga de arrastrar la ventana.
        /// </summary>
        private void ArrastrarVentana(object sender, MouseEventArgs args)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        
        /// <summary>
        /// Cierra la aplicacion.
        /// </summary>
        private void Salir(object sender, EventArgs args)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// Maximiza la ventana.
        /// </summary>
        private void Maximizar(object sender, EventArgs args)
        {
            WindowState = FormWindowState.Maximized;
            pbMaximizar.Visible = false;
            pbRestaurar.Visible = true;
        }
        
        /// <summary>
        /// Restaura el tamaño normal de la ventana.
        /// </summary>
        private void Restaurar(object sender, EventArgs args)
        {
            WindowState = FormWindowState.Normal;
            pbRestaurar.Visible = false;
            pbMaximizar.Visible = true;
        }
        
        /// <summary>
        /// Minimiza la ventana.
        /// </summary>
        private void Minimizar(object sender, EventArgs args)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        /// <summary>
        /// Muestra u oculta el panel izquierdo.
        /// </summary>
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
        
        /// <summary>
        /// Cambia el color del fondo cuando el cursor esta sobre un boton.
        /// </summary>
        private void Botones_MouseMove(object sender, MouseEventArgs args)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.Gray;
        }
        
        /// <summary>
        /// Restablece el color del fondo cuando el cursor sale de un botón.
        /// </summary>
        private void Botones_MouseLeave(object sender, EventArgs args)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.FromArgb(30, 30, 46);
        }
        
        #endregion
        
        
        #region Insertar formularios
        
        private Form childForm = null;
        
        /// <summary>
        /// Agrega un nuevo formulario al panel principal. Si ya hay un formulario, se cierra antes de abrir el nuevo.
        /// </summary>
        /// <param name="current"> Formulario a agregar.</param>
        private void AddForm(Form current)
        {
            //Si ya hay un formulario abierto, se cierra antes de abrir el nuevo.
            if (childForm != null)
            {
                childForm.Close();
            }
        
            childForm = current;
        
            //Se configura el formulario para que sea hijo del panel principal.
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
        
            pnlPrincipal.Controls.Add(childForm);
            pnlPrincipal.Tag = childForm;
        
            childForm.BringToFront();
            childForm.Show();
        }
        
        #endregion
        

        /// <summary>
        /// Método que maneja el evento click de los botones del menú
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento</param>
        /// <param name="args">Argumentos del evento</param>
        private void BotonMenu_Click(object sender, EventArgs args)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton boton = (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender;
            // Se obtiene la cadena asociada a la clave
            string clave = boton.Tag.ToString();
        
            // Se utiliza una declaración switch para determinar qué formulario agregar
            switch (clave)
            {
                case "Contactos":
                    // Agrega el formulario de búsqueda de contactos
                    AddForm(new Contactos.BuscadorContactos());
                    break;
                case "Ventas":
                    // Agrega el formulario de búsqueda de ventas
                    AddForm(new Ventas.BuscadorVentas());
                    break;
                case "Compras":
                    // Agrega el formulario de búsqueda de compras
                    AddForm(new Compras.BuscadorCompras());
                    break;
                case "Productos":
                    // Agrega el formulario de búsqueda de productos
                    AddForm(new Productos.BuscadorProductos());
                    break;
                case "Seguridad":
                    // Agrega el formulario de búsqueda de usuarios
                    AddForm(new Usuarios.BuscadorUsuarios());
                    break;
                default:
                    // En caso de ser una clave no válida, muestra un mensaje de error
                    MessageBox.Show(this, "No se encuentra el formulario especificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        
    }
}
