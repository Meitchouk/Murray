using Common.Util;
using Murray.Services.Transacctions;
using Murray.ViewModels.Shopping;
using Murray.Vistas.Base;
using System;

namespace Murray.Vistas.Compras
{
    // Clase BuscadorCompras que hereda de la clase abstracta Buscador.
    public partial class BuscadorCompras : Buscador 
    {
        // Campos privados de la clase.
        private readonly ErrorHandler Handler; // Instancia del manejador de errores.
        private readonly TransactionService Service; // Servicio de Transacción.

        // Constructor de la clase BuscadorCompras que inicializa los campos privados, oculta un botón y carga el componente.
        public BuscadorCompras()
        {
            Handler = new ErrorHandler(); // Se instancia el manejador de errores.
            Service = new TransactionService(Handler); // Se inicializa el servicio de transacción.

            InitializeComponent(); // Se carga el componente.
            Reload(); // Se llama al método para cargar la tabla con los registros de compras correspondientes.

            // Special case
            HideEliminarBtn(); // Se oculta el botón Eliminar. (Caso Especial requerido)
        }

        // Implementación de los métodos abstractos heredados desde la clase Base Buscador. 

        // Método abstracto OnAgregarClick implementado para mostrar la vista EditorCompras a modo de "Nuevo Registro".
        protected override void OnAgregarClick(object sender, EventArgs e)
        {    
            ShowEditor(default); // Llamada al método encargado de mostrar el formulario de registro.
        }

        // Método abstracto OnBuscarTxtChange sobreescrito para llamar al método Reload().
        protected override void OnBuscarTxtChange(string query)
        {    
            Reload(); // Llamada al método encargado de cargar la tabla con los nuevos registros de Compras.
        }

        // Método abstracto OnEditarClick que obtiene el elemento seleccionado y muestra la vista EditorCompras a modo de "Editar Registro".
        protected override void OnEditarClick(object sender, EventArgs e)
        {    
            var selected = GetSelected<CompraView>(); // Obtención del elemento seleccionado.
            if (selected is null) return; // Si no hay un elemento seleccionado, se sale del método.

            ShowEditor(selected.Id); // Mostrar la vista de edición con los valores correspondientes.
        }

        // Método abstracto OnEliminarClick sobreescrito como un caso especial en esta clase.
        // No es necesario implementar nada aquí porque se va a deshabilitar durante la ejecución.
        protected override void OnEliminarClick(object sender, EventArgs e) { /* Do nothing */ }

        #region Private Methods

        // Método para cargar la tabla con los registros de compras.
        private void Reload()
        {
            LoadDatagrid(Service.GetCompras(LastQuery)); // Se cargan los registros de las compras correspondientes.
        }

        // Método que muestra la vista EditorCompras.
        private void ShowEditor(int id)
        {
            var editor = new EditorCompras(); // Se crea una nueva instancia de EditorCompras.
            editor.FormClosed += Editor_FormClosed; // Se agrega el evento FormClosed del editor.
            editor.LoadRecord(id); // Se llama al método para cargar los datos requeridos por el formulario.
            editor.ShowDialog(); // Se muestra la vista de registro.
        }

        // Evento FormClosed del editor.
        private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Reload(); // Se recarga la tabla con los nuevos datos ingresados/actualizados.          
        }
        #endregion
    }
}
