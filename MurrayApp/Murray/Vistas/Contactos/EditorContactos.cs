using Common.Util;
using Models.Interfaces;
using Murray.Services.Common;

using System;
using System.Linq;
using System.Windows.Forms;

namespace Murray.Vistas.Contactos
{
    public partial class EditorContactos : Form
    {
        private readonly ErrorHandler Handler;
        private readonly ContactosService Service;

        /// <summary>
        ///     Registro a interactuar
        /// </summary>
        private Models.Common.Contacto Record;

        public EditorContactos()
        {
            Handler = new ErrorHandler();
            Service = new ContactosService(Handler);

            InitializeComponent();

            cmbMunicipios.DataSource = Service.GetMunicipios().ToArray();
            cmbMunicipios.DisplayMember = nameof(INameable.Nombre);
        }

        #region Public Methods
        
        /// <summary>
        ///     Carga un registro determinado en el formulario de edición
        /// </summary>
        /// <param name="id">Id del contacto</param>
        public void LoadRecord(int id)
        {
            var isNew = id.Equals(default);
            Record = id.Equals(default) ? new Models.Common.Contacto() : Service.GetContact(id);
            if (isNew) return;

            var municipios = (Models.Common.Municipio[])cmbMunicipios.DataSource;

            txtPrimerNombre.Text = Record.PrimerNombre;
            txtSegundoNombre.Text = Record.SegundoNombre;
            txtPrimerApellido.Text = Record.PrimerApellido;
            txtSegundoApellido.Text = Record.SegundoApellido;
            txtDireccion.Text = Record.Direccion;

            if (Record.FechaNacimiento.HasValue)
                dtpFechaNacimiento.Value = Record.FechaNacimiento.Value;

            cmbMunicipios.SelectedItem = municipios.FirstOrDefault(x => x.Id == Record.IdMunicipio);
        }

        #endregion

        #region Private Methods
        
        /// <summary>
        ///     Actualiza el objeto Record con los valores ingresados por el usuario
        /// </summary>
        private void ApplyChanges()
        {
            if (Record is null)
                Record = new Models.Common.Contacto();

            if (cmbMunicipios.SelectedItem != null && cmbMunicipios.SelectedItem is Models.Common.Municipio municipio)
                Record.IdMunicipio = municipio.Id;

            Record.PrimerNombre = txtPrimerNombre.Text;
            Record.SegundoNombre = txtSegundoNombre.Text;
            Record.PrimerApellido = txtPrimerApellido.Text;
            Record.SegundoApellido = txtSegundoApellido.Text;
            Record.Direccion = txtDireccion.Text;
            Record.FechaNacimiento = dtpFechaNacimiento.Value;
        }

        #endregion

        /// <summary>
        ///     Acción output de cerrar ventana.
        /// </summary>
        private void Salir(object sender, EventArgs args)
        {
            Close();
        }

        /// <summary>
        ///     Acción output del botón Agregar. Guarda el registro creado o editado y cierra la ventana
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            Service.SaveContact(Record);
            Close();
        }
    }
}
