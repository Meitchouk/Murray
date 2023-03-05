using Common.Util;
using Models.Interfaces;
using Murray.Services.Common;

using System;
using System.Linq;
using System.Windows.Forms;

namespace Murray.Vistas.Productos
{
    public partial class EditorProductos : Form // Definición de la clase "EditorProductos", hereda de la clase "Form"
        {
            private readonly ErrorHandler Handler; // Instancia de "ErrorHandler" (maneja los errores)
            private readonly StockService Service; // Instancia de "StockService" (proporciona los datos del stock)
    
            /// <summary>
            ///     Registro a interactuar
            /// </summary>
            private Models.Common.Producto Record; // Variable para guardar el registro que se editará o creará
    
            public EditorProductos() // Constructor por defecto de la clase
            {
                Handler = new ErrorHandler(); // Se inicializa la instancia de "ErrorHandler"
                Service = new StockService(Handler); // Se inicializa la instancia de "StockService"
    
                InitializeComponent(); // Método que carga la interfaz gráfica
    
                Categorias.DataSource = Service.GetCategorias().ToArray(); // Se agregan las categorías al control "Categorías"
                Categorias.DisplayMember = nameof(INameable.Nombre); // Se define el campo a mostrar dentro del control "Categorías"
            }
    
            #region Public Methods // Región que contiene métodos públicos
    
            public void LoadRecord(int id) // Método público "LoadRecord" que recibe un "id" como parámetro
            {
                // Se verifica si el "id" es valor por defecto (se creará un nuevo registro)
                var isNew = id.Equals(default);
                // Si es un registro nuevo, se crea una nueva instancia de "Producto"
                Record = isNew ? new Models.Common.Producto() : Service.GetProduct(id);
    
                // Si es registro existente, se busca la lista de "Categorías" y se cargan los datos correspondientes en el formulario
                if (isNew) return;
    
                var categorias = (Models.Common.Categoria[])Categorias.DataSource;
    
                Descripcion.Text = Record.Descripcion; // Se carga la descripción del producto
                Precio.Value = Record.Precio; // Se carga el precio del producto
                Categorias.SelectedItem = categorias.FirstOrDefault(x => x.Id == Record.IdCategoria); // Se selecciona la categoría del producto correspondiente
            }
    
            #endregion
    
            #region Private Methods // Región que contiene métodos privados
    
            private void ApplyChanges() // Método privado "ApplyChanges"
            {
                if (Record is null)
                    Record = new Models.Common.Producto(); // Se crea una nueva instancia de "Producto" si ésta es nula
    
                Record.Descripcion = Descripcion.Text; // Se asigna la descripción del producto
                Record.Precio = Precio.Value; // Se asigna el precio del producto
                Record.Estado = true; // Se asigna el estado del producto
    
                // Si hay una categoría seleccionada y el objeto seleccionado es una instancia de "Categoria", se asigna IdCategoria con su respectivo Id
                if (Categorias.SelectedItem != null && Categorias.SelectedItem is Models.Common.Categoria categoria)
                    Record.IdCategoria = categoria.Id;
            }
    
            #endregion
    
            private void btnGuardar_Click(object sender, EventArgs e) // Cuando se presiona el botón "Guardar"
            {
                ApplyChanges(); // Aplica los cambios realizados en el formulario
                Service.SaveProduct(Record); // Guarda el producto
                Close(); // Cierra el formulario de edición
            }
    
            private void bunifuButton1_Click(object sender, EventArgs e) // Cuando se presiona el botón cerrar (una cruz roja)
            {
                Close(); // Cierra el formulario de edición
            }
    
            private void pnlInfoProducto_Paint(object sender, PaintEventArgs e) // Evento que se lanza cuando se dibuja el "Panel" para la info del producto
            {
    
            }
        }
    
}
