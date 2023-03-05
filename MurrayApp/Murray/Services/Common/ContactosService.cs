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
    // Esta clase interna ContactosService extiende la estructura ServiceBase,  e implementa las diferentes funcionalidades 
    // para el manejo y obtención de contactos.
    internal class ContactosService : ServiceBase
    {
        // Campos que almacenan instancias de objetos para acceder a los diferentes DAO's necesarios.  
        private readonly IContactoDao ContactoDao;
        private readonly IEmpleadoDao EmpleadoDao;
        private readonly IProveedorDao ProveedorDao;
        private readonly IClienteDao ClienteDao;
        private readonly IMunicipioDao MunicipioDao;

        // Constructor que inicializa los campos de la clase ContactosService y recibe una instancia del manejador de errores.
        public ContactosService(ErrorHandler handler) : base(handler)
        {
            ContactoDao = DaoFactory.Get<IContactoDao>(handler); // Accede al DAO para la entidad Contacto
            EmpleadoDao = DaoFactory.Get<IEmpleadoDao>(handler); // Accede al DAO para la entidad Empleado 
            ProveedorDao = DaoFactory.Get<IProveedorDao>(handler); // Accede al DAO para la entidad Proveedor
            ClienteDao = DaoFactory.Get<IClienteDao>(handler); // Accede al DAO para la entidad Cliente
            MunicipioDao = DaoFactory.Get<IMunicipioDao>(handler); // Accede al DAO para la entidad municipios
        }

        // Método que obtiene una lista de ContactoView a través de una consulta previa en la BD, aplicando un filtro
        // opcional. Retorna una lista de objetos ContactoView construidos por cada registro obtenido, con información específica
        // del contacto y sus roles asociados.
        public IEnumerable<ContactoView> GetContactos(string query)
        {
            // Si el query es nulo o solo contiene espacios en blanco se asigna un valor nulo para omitir el filtro
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            var records = ContactoDao.Read(query);

        return records.Select(contacto =>

            // Para cada registro obtenido se construye un objeto ContactoView con datos específicos del contacto
            // y se determina sus roles asociados mediante consultas adicionales al objeto Dao respectivo
            {
                // Se obtiene el municipio correspondiente al ID del registro actual
                var municipio = MunicipioDao.GetById(contacto.IdMunicipio);

                // Consulta los roles de cliente, proveedor y empleado asociados al contacto actual
                var cliente = ClienteDao.Read(true, contacto.Id).FirstOrDefault();
                var proveedor = ProveedorDao.Read(true, contacto.Id).FirstOrDefault();
                var empleado = EmpleadoDao.Read(true, contacto.Id).FirstOrDefault();

                // Se crea una lista de roles y se agregan los valores correspondientes a los roles encontrados
                var roles = new List<string>();
                if (cliente != null) roles.Add("Cliente");
                if (proveedor != null) roles.Add("Proveedor");
                if (empleado != null) roles.Add("Empleado");

                // Retorna un objeto ContactoView construido a partir de los datos obtenidos en las consultas,
                // incluyendo campos como: Id, Nombre, Municipio, Direccion, FechaNacimiento y Roles
                return new ContactoView
                {
                    Id = contacto.Id,
                    Nombre = contacto.NombreCompleto,

                    Municipio = municipio?.Nombre ?? string.Empty,
                    // Si el municipio existe (no es nulo), asigna su nombre a la propiedad "Municipio".
                    // De lo contrario, si es nulo (municipio no existe), asigna un string vacío a "Municipio".
                    // El operador "?." verifica si "municipio" es nulo o no antes de acceder a su propiedad "Nombre", mientras que
                    // El operador "??" devuelve el segundo operando si el primero es null.

                    Direccion = contacto.Direccion,

                    Nacimiento = contacto.FechaNacimiento.HasValue ? contacto.FechaNacimiento.Value.ToShortDateString() : string.Empty,
                    // Se convierte la propiedad de Fecha de Nacimiento de un objeto Contacto en una cadena de fecha corta 
                    // o una cadena vacía si es nula. Si el valor no es nulo, se devuelve la representación de cadena formateada y legible 
                    // para humanos del valor de fecha proporcionado en el objeto contacto, usando ToShortDateString() . Si el valor es nulo, 
                    // entonces se devuelve una cadena vacía.

                    Roles = string.Join(",", roles),
                    // Se crea una cadena a partir de los elementos almacenados en la lista 'roles'
                    // separados por coma. Esta cadena será asignada al campo 'Roles' del objeto ContactoView a retornar.
                };
            });
    }

        // Método que obtiene un contacto específico según su id.
        public Contacto GetContact(int id)
        {
            return ContactoDao.GetById(id);
        }

        // Método que obtiene una lista de municipios desde la BD.
        public IEnumerable<Municipio> GetMunicipios()
        {
            return MunicipioDao.Read();
        }

        // Método que guarda un nuevo registro de contacto o actualiza uno existente.
        public Contacto SaveContact(Contacto record)
        {
            var isNew = record.Id.Equals(default);
            return isNew ? ContactoDao.Create(record) : ContactoDao.Update(record.Id, record);
        }

        // Método que elimina un registro de contacto según su id.
        public Contacto DeleteContact(int id)
        {
            return ContactoDao.Delete(id);
        }

        // Implementación del método Dispose para liberar recursos no administrados utilizados por un objeto ContactosService.
        public override void Dispose()
        {
            MunicipioDao.Dispose();
            ContactoDao.Dispose();
            EmpleadoDao.Dispose();
            ClienteDao.Dispose();
            ProveedorDao.Dispose();

            Handler.Clear(); // Elimina cualquier error almacenado en la instancia de ErrorHandler.
        }
    }
}

