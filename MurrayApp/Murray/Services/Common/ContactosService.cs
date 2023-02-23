using Common.Util;
using Connection.Interfaces.Common;
using Connection.Interfaces.Sale;
using Connection.Interfaces.Shopping;
using Models.Common;
using Murray.Services.Base;
using Murray.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;

namespace Murray.Services.Common
{
    internal class ContactosService : ServiceBase
    {
        private readonly IContactoDao ContactoDao;
        private readonly IEmpleadoDao EmpleadoDao;
        private readonly IProveedorDao ProveedorDao;
        private readonly IClienteDao ClienteDao;
        private readonly IMunicipioDao MunicipioDao;

        public ContactosService(ErrorHandler handler) : base(handler)
        {
            ContactoDao = DaoFactory.Get<IContactoDao>(handler);
            EmpleadoDao = DaoFactory.Get<IEmpleadoDao>(handler);
            ProveedorDao = DaoFactory.Get<IProveedorDao>(handler);
            ClienteDao = DaoFactory.Get<IClienteDao>(handler);
            MunicipioDao = DaoFactory.Get<IMunicipioDao>(handler);
        }

        public IEnumerable<ContactoView> GetContactos(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            var records = ContactoDao.Read(query);

            return records.Select(contacto =>
            {
                var municipio = MunicipioDao.GetById(contacto.IdMunicipio);

                var cliente = ClienteDao.Read(true, contacto.Id).FirstOrDefault();
                var proveedor = ProveedorDao.Read(true, contacto.Id).FirstOrDefault();
                var empleado = EmpleadoDao.Read(true, contacto.Id).FirstOrDefault();

                var roles = new List<string>();
                if (cliente != null) roles.Add("Cliente");
                if (proveedor != null) roles.Add("Proveedor");
                if (empleado != null) roles.Add("Empleado");

                return new ContactoView
                {
                    Id = contacto.Id,
                    Nombre = contacto.NombreCompleto,
                    Municipio = municipio?.Nombre ?? string.Empty,
                    Direccion = contacto.Direccion,
                    Nacimiento = contacto.FechaNacimiento.HasValue ? contacto.FechaNacimiento.Value.ToShortDateString() : string.Empty,
                    Roles = string.Join(",", roles),
                };
            });
        }

        public Contacto GetContact(int id)
        {
            return ContactoDao.GetById(id);
        }

        public IEnumerable<Municipio> GetMunicipios()
        {
            return MunicipioDao.Read();
        }

        public Contacto SaveContact(Contacto record)
        {
            var isNew = record.Id.Equals(default);
            return isNew ? ContactoDao.Create(record) : ContactoDao.Update(record.Id, record);
        }

        public Contacto DeleteContact(int id)
        {
            return ContactoDao.Delete(id);
        }

        public override void Dispose()
        {
            MunicipioDao.Dispose();
            ContactoDao.Dispose();
            EmpleadoDao.Dispose();
            ClienteDao.Dispose();
            ProveedorDao.Dispose();

            Handler.Clear();
        }
    }
}
