using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Murray.Vistas;

namespace Murray
{
    static class Program
    {
        /// <summary>
        /// El método Main es el punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilita los estilos visuales para la aplicación
            Application.SetCompatibleTextRenderingDefault(false); // Establece la representación de texto predeterminada como no compatible con versiones anteriores de Windows
            Login login = new Login(); // Crea una nueva instancia de la clase Login
            login.Show(); // Muestra el formulario de inicio de sesión
            Application.Run(); // Inicia el bucle de mensajes de la aplicación y agrega un formulario sin propietario a la cola de mensajes
        }
    }
}
