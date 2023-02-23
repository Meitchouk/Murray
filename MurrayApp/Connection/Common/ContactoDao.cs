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
        public override Contacto Delete(int id)
        {
            return Read(StoredProcedures.ContactoDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Contacto();
        }

        /// <inheritdoc cref="IContactoDao.GetById(int)"/>
        public Contacto GetById(int id)
        {
            return Read(StoredProcedures.ContactoGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Contacto();
        }

        /// <inheritdoc cref="IContactoDao.Read(string)"/>
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
        public override IEnumerable<Contacto> Read()
        {
            return Read(string.Empty);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
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
