using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    /// <inheritdoc cref="IEmpleadoDao">
    internal class EmpleadoDao : BaseDao<Empleado>, IEmpleadoDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor base
        /// </summary>
        /// <param name="connectionString">
        ///     Cadena de conexión con la base de datos
        /// </param>
        /// <param name="handler">
        ///     Administrador de errores
        /// </param>
        public EmpleadoDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {

        }

        #endregion Constructor

        #region Public Methods
        /// <inheritdoc cref="IDao{TModel}.Create(TModel)">
        public override Empleado Create(Empleado model)
        {
            if (Handler.HasError())
                return new Empleado();

            return Read(StoredProcedures.EmpleadoCreate, new Dictionary<string, object>
            {
                ["IdContacto"] = model.IdContacto

            }).FirstOrDefault() ?? new Empleado();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Empleado Delete(int id)
        {
            if (Handler.HasError())
                return new Empleado();

            return Read(StoredProcedures.EmpledaoDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Empleado();
        }

        /// <inheritdoc cref="IEmpleadoDao.GetById(int)"/>
        public Empleado GetById(int id)
        {
            return Read(StoredProcedures.EmpleadoGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Empleado();
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Empleado> Read()
        {
            return Read(StoredProcedures.EmpleadoGet);
        }

        /// <inheritdoc cref="IEmpleadoDao.Read(bool, int)"/>
        public IEnumerable<Empleado> Read(bool estado, int idContacto)
        {
            return Read(StoredProcedures.EmpleadoGet, new Dictionary<string, object>
            {
                ["Estado"] = estado,
                ["IdContacto"] = idContacto
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Empleado Update(int id, Empleado model)
        {
            return Read(StoredProcedures.EmpleadoUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["IdContacto"] = model.IdContacto

            }).FirstOrDefault() ?? new Empleado();
        }
        #endregion

    }
}
