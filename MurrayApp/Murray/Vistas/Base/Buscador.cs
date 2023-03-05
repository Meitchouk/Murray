using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Murray.Vistas.Base
{
    public abstract partial class Buscador : Form
    {
        //Variable que guarda la última consulta realizada.
        protected string LastQuery = string.Empty;

        public Buscador()
        {
            InitializeComponent();
        }

        #region Protected Methods
        //Método protegido que se llama cada vez que cambia el texto contenido en el cuadro de búsqueda.
        protected abstract void OnBuscarTxtChange(string query);

        //Método protegido que se llama cuando se hace clic en el botón Agregar.
        protected abstract void OnAgregarClick(object sender, EventArgs e);

        //Método protegido que se llama cuando se hace clic en el botón Eliminar.
        protected abstract void OnEliminarClick(object sender, EventArgs e);

        //Método protegido que se llama cuando se hace clic en el botón Editar.
        protected abstract void OnEditarClick(object sender, EventArgs e);

        //Método protegido que devuelve el elemento seleccionado del tipo especificado.
        protected TModel GetSelected<TModel>()
        {
            if (DataGrid.SelectedRows.Count == 0)
                return default;

            var records = (TModel[])DataGrid.DataSource;
            return records[DataGrid.SelectedRows[0].Index];
        }

        //Método protegido que carga los registros en el DataGridView.
        protected void LoadDatagrid<TModel>(IEnumerable<TModel> records)
        {
            DataGrid.DataSource = records.ToArray();
        }

        //Método protegido que oculta el botón Agregar.
        protected void HideAgregarBtn() => btnAgregar.Hide();

        //Método protegido que oculta el botón Eliminar.
        protected void HideEliminarBtn() => btnEliminar.Hide();
        #endregion

        //Método que se llama cada vez que cambia el contenido del cuadro de búsqueda.
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Se actualiza la variable de la última consulta realizada.
            LastQuery = txtBuscar.Text;
            //Se ejecuta el método de búsqueda que debe implementarse en clases hijas de Buscador.
            OnBuscarTxtChange(LastQuery);
        }

        //Método que se llama cuando se hace clic en el botón Eliminar.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Se ejecuta el método de eliminación que debe implementarse en clases hijas de Buscador.
            OnEliminarClick(sender, e);
        }

        //Método que se llama cuando se hace clic en el botón Modificar.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Se ejecuta el método de edición que debe implementarse en clases hijas de Buscador.
            OnEditarClick(sender, e);
        }

        //Método que se llama cuando se hace clic en el botón Agregar.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Se ejecuta el método de agregar que debe implementarse en clases hijas de Buscador.
            OnAgregarClick(sender, e);
        }
    }
}

