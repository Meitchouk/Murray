using Common.Util;
using Connection.Interfaces.Common;
using Connection.Interfaces.Identity;
using Murray.Services.Base;
using Murray.ViewModels.Identity;

using System.Collections.Generic;
using System.Linq;

namespace Murray.Services.Identity
{
    /// <summary>
    ///     Servicio dedicado a la interacción con el usuario del sistema
    /// </summary>

    internal class UserService : ServiceBase
    {
        private readonly IUsuarioDao UsuarioDao; // DAO para interactuar con información de los usuarios
        private readonly IEmpleadoDao EmpleadoDao; // DAO para interactuar con información de los empleados
        private readonly IContactoDao ContactoDao; // DAO para interactuar con información de los contactos

        public UserService(ErrorHandler handler) : base (handler)
        {
            UsuarioDao = DaoFactory.Get<IUsuarioDao>(handler); // Objeto DAO para interactuar con usuarios
            EmpleadoDao = DaoFactory.Get<IEmpleadoDao>(handler); // Objeto DAO para interactuar con empleados
            ContactoDao = DaoFactory.Get<IContactoDao>(handler); // Objeto  DAO para interactuar con contactos
        }

        /// <summary>
        ///     Obtiene una lista de usuarios junto a sus datos personales
        /// </summary>
        /// <param name="query">Consulta para buscar usuarios específicos</param>
        // Devuelve una lista de Usuarios con su información para vista 
        public IEnumerable<UsuarioView> GetUsers(string query)
        {
            // Si se recibe una consulta vacía o nula, se asigna null a la variable 'query'
            if (string.IsNullOrWhiteSpace(query))
                query = null;
        
            // Obtiene los registros de usuario que cumplan las condiciones de búsqueda en base de datos
            var records = UsuarioDao.Read(query);
        
            // Por cada registro obtenido, se obtiene el empleado y contacto asociado y se mapean a la entidad UsuarioView
            return records.Select(user =>
            {
                var empleado = EmpleadoDao.GetById(user.IdEmpleado);
                var contacto = ContactoDao.GetById(empleado.IdContacto);
        
                // Retorna un objeto UsuarioView con la información del usuario incluyendo su nombre completo obtenido por medio del objeto contacto
                return new UsuarioView
                {
                    Id = user.Id,
                    Username = user.Username,
                    Nombre = contacto.NombreCompleto,
                    Role = user.Role,
                    IdContacto = contacto.Id
                };
            });
        }
        
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public override void Dispose()
        {
            UsuarioDao.Dispose();
            EmpleadoDao.Dispose();
            ContactoDao.Dispose();

            Handler.Clear();
        }
    }
}

