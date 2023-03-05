using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    /// <inheritdoc cref="IContactoDao"/>
    internal class ContactoDao : BaseDao<Contacto>, IContactoDao
    {
        #region Constructor

        /// <summary>
        ///     Contructor por defecto
        /// </summary>
        public ContactoDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        // Método para crear un nuevo contacto en la base de datos. Recibe como parámetro el modelo de Contacto a crear.
        // Devuelve el objeto creado o una instancia vacía si falla la consulta.
        public override Contacto Create(Contacto model)
        {
            return Read(StoredProcedures.ContactoCreate, new Dictionary<string, object>
            {
                ["PrimerNombre"] = model.PrimerNombre,
                ["SegundoNombre"] = model.SegundoNombre,
                ["PrimerApellido"] = model.PrimerApellido,
                ["SegundoApellido"] = model.SegundoApellido,
                ["FechaNacimiento"] = model.FechaNacimiento,
                ["Direccion"] = model.Direccion,
                ["IdMunicipio"] = model.IdMunicipio
                //["RazonSocial"] = model.RazonSocial,

            }).FirstOrDefault() ?? new Contacto();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        // Método para eliminar un contacto de la base de datos. Recibe como parámetro el ID del contacto a eliminar.
        // Devuelve el objeto eliminado o una instancia vacía si falla la consulta.
        public override Contacto Delete(int id)
        {
            return Read(StoredProcedures.ContactoDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Contacto();
        }

        /// <inheritdoc cref="IContactoDao.GetById(int)"/>
        // Método para obtener un contacto por su ID de la base de datos. Recibe como parámetro el ID del contacto que desea obtener.
        // Devuelve el objeto obtenido o una instancia vacía si no se encuentra el objeto en la consulta.
        public Contacto GetById(int id)
        {
            return Read(StoredProcedures.ContactoGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Contacto();
        }

        /// <inheritdoc cref="IContactoDao.Read(string)"/>
        // Método para leer todos los contactos que coinciden con el valor dado desde la base de datos.
        // Recibe como parámetro un string con el valor a buscar, sea en PrimerNombre, SegundoNombre, PrimerApellido, 
        // SegundoApellido y Direccion. Devuelve una lista de objetos Contacto.
        public IEnumerable<Contacto> Read(string value)
        {
            return Read(StoredProcedures.ContactoGet, new Dictionary<string, object>
            {
                ["PrimerNombre"] = value,
                ["SegundoNombre"] = value,
                ["PrimerApellido"] = value,
                ["SegundoApellido"] = value,
                ["Direccion"] = value
                //["RazonSocial"] = value
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        // Método para leer todos los contactos de la base de datos.
        // No recibe parámetros. Devuelve una lista de objetos Contacto.
        public override IEnumerable<Contacto> Read()
        {
            return Read(string.Empty);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        // Método para actualizar un contacto de la base de datos. Recibe como parámetros el Id del uso a cambiar y el modelo 
        // con la información para actualizar. Devuelve el objeto actualizado o una instancia vacía si falla la consulta.
        public override Contacto Update(int id, Contacto model)
        {
            return Read(StoredProcedures.ContactoUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["PrimerNombre"] = model.PrimerNombre,
                ["SegundoNombre"] = model.SegundoNombre,
                ["PrimerApellido"] = model.PrimerApellido,
                ["SegundoApellido"] = model.SegundoApellido,
                ["FechaNacimiento"] = model.FechaNacimiento,
                ["Direccion"] = model.Direccion,
                ["IdMunicipio"] = model.IdMunicipio
                //["RazonSocial"] = model.RazonSocial,

            }).FirstOrDefault() ?? new Contacto();
        }
    }
}
