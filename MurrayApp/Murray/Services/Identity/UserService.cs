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
    ///     Servicio dedicado a interacción con usuario del sistema
    /// </summary>
    internal class UserService : ServiceBase
    {
        private readonly IUsuarioDao UsuarioDao;
        private readonly IEmpleadoDao EmpleadoDao;
        private readonly IContactoDao ContactoDao;

        public UserService(ErrorHandler handler) : base (handler)
        {
            UsuarioDao = DaoFactory.Get<IUsuarioDao>(handler);
            EmpleadoDao = DaoFactory.Get<IEmpleadoDao>(handler);
            ContactoDao = DaoFactory.Get<IContactoDao>(handler);
        }

        public IEnumerable<UsuarioView> GetUsers(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                query = null;

            var records = UsuarioDao.Read(query);

            return records.Select(user =>
            {
                var empleado = EmpleadoDao.GetById(user.IdEmpleado);
                var contacto = ContactoDao.GetById(empleado.IdContacto);

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

        public override void Dispose()
        {
            UsuarioDao.Dispose();
            EmpleadoDao.Dispose();
            ContactoDao.Dispose();

            Handler.Clear();
        }
    }
}
