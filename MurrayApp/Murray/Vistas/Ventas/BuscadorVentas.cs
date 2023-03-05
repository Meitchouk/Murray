using Common.Util;
using Murray.Services.Transacctions;
using Murray.ViewModels.Sales;
using Murray.Vistas.Base;
using System;

namespace Murray.Vistas.Ventas
{
    public partial class BuscadorVentas : Buscador
        {
            private readonly ErrorHandler Handler; // Manejador de errores
            private readonly TransactionService Service; // Servicio de transacciones
    
            public BuscadorVentas()
            {
                Handler = new ErrorHandler(); // Instanciar manejador de errores
                Service = new TransactionService(Handler); // Instanciar servicio de transacciones
    
                InitializeComponent(); // Inicializar componentes del formulario
                Reload(); // Cargar datos iniciales en el datagridview
    
                // Special case (Caso especial)
                HideEliminarBtn(); // Ocultar botón Eliminar
            }
    
            protected override void OnAgregarClick(object sender, EventArgs e)
            {
                ShowEditor(default); // Mostrar el editor de ventas para agregar una nueva venta
            }
    
            protected override void OnBuscarTxtChange(string query)
            {
                Reload(); // Recargar los datos dependiendo del criterio de búsqueda especificado
            }
    
            protected override void OnEditarClick(object sender, EventArgs e)
            {
                var selected = GetSelected<VentaView>(); // Obtener la venta seleccionada en el datagridview
                if (selected is null) return; // Si no hay ninguna venta seleccionada, no hacer nada
    
                ShowEditor(selected.Id); // Mostrar el editor de ventas para editar la venta seleccionada
            }
    
            protected override void OnEliminarClick(object sender, EventArgs e)
            {
                // Do nothing (No hacer nada)
            }
    
            #region Private Methods
    
            private void Reload()
            {
                LoadDatagrid(Service.GetVentas(LastQuery)); // Cargar las ventas en el datagridview
            }
    
            private void ShowEditor(int id)
            {
                var editor = new EditorVentas(); // Instanciar el editor de ventas
                editor.FormClosed += Editor_FormClosed; // Agregar un evento que se ejecute cuando el editor se cierre
                editor.LoadRecord(id); // Cargar la información de la venta en caso de que se esté editando una existente
                editor.ShowDialog(); // Mostrar el editor de ventas como un diálogo modal
            }
    
            private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
            {
                Reload(); // Recargar los datos después de cerrarse el editor
            }
    
            #endregion
        }
    
}
