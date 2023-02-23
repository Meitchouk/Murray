using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Identity;
using Models.Identity;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Identity
{
    /// <inheritdoc cref="IUsuarioDao"/>
    internal class UsuarioDao : BaseDao<Usuario>, IUsuarioDao
    {
        #region Constructors

        /// <summary>
        ///     Constructor base
        /// </summary>
        public UsuarioDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {

        }

        #endregion

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>
        public override Usuario Create(Usuario model)
        {
            return Read(StoredProcedures.UsuarioCreate, new Dictionary<string, object>
            {
                ["UserName"] = model.Username,
                ["Password"] = "123456",
                ["Role"] = model.Role,
                ["IdEmpleado"] = model.IdEmpleado

            }).FirstOrDefault() ?? new Usuario();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Usuario Delete(int id)
        {
            return Read(StoredProcedures.UsuarioDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Usuario();
        }

        /// <inheritdoc cref="IDao{TModel}.Read()"/>
        public override IEnumerable<Usuario> Read()
        {
            return Read(string.Empty);
        }

        /// <inheritdoc cref="IUsuarioDao.Read(string)"/>
        public IEnumerable<Usuario> Read(string username)
        {
            return Read(StoredProcedures.UsuarioGet, new Dictionary<string, object>
            {
                ["Username"] = username
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Usuario Update(int id, Usuario model)
        {
            return Read(StoredProcedures.UsuarioCreate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Username"] = model.Username,
                ["Role"] = model.Role,
                ["IdEmpleado"] = model.IdEmpleado

            }).FirstOrDefault() ?? new Usuario();
        }

        /// <inheritdoc cref="IUsuarioDao.Login(string, string)"/>
        public Usuario Login(string username, string password)
        {
            if (username.Length > 50)
                Handler.Add("USERNAME_LENGTH_EXCEED");

            if (Handler.HasError())
                return new Usuario();

            return Read(StoredProcedures.UsuarioLogin, new Dictionary<string, object>
            {
                ["username"] = username,
                ["password"] = password

            }).FirstOrDefault() ?? new Usuario();
        }  
    }
}
