using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    /// <summary>
    /// Clase que implementa la interfaz IEmpleadoDao y hereda de BaseDao,
    /// la cual representa datos en la tabla Empleado de la base de datos
    /// </summary>
    internal class EmpleadoDao : BaseDao<Empleado>, IEmpleadoDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor que recibe una cadena de conexión y un manejador de errores
        /// </summary>
        /// <param name="connectionString">
        ///     La cadena de conexión a la base de datos
        /// </param>
        /// <param name="handler">
        ///     El objeto ErrorHandler responsable del manejo de errores
        /// </param>
        public EmpleadoDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {

        }

        #endregion Constructor

        #region Public Methods

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>
        /// <summary>
        /// Crea un nuevo registro en la tabla Empleado usando el procedimiento almacenado EmpleadoCreate.
        /// </summary>
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
        /// <summary>
        /// Borra un registro de la tabla empleados mediante el uso del procedimiento almacenado EmpledaoDelete.
        /// </summary>
        public override Empleado Delete(int id)
        {
            if (Handler.HasError())
                return new Empleado();

            return Read(StoredProcedures.EmpledaoDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Empleado();
        }

        /// <summary>
        /// Obtiene un registro de la tabla Empleado con el id especificado, 
        /// mediante el uso del procedimiento almacenado EmpleadoGet.
        /// </summary>
        /// <param name="id">El id del registro deseado</param>
        public Empleado GetById(int id)
        {
            return Read(StoredProcedures.EmpleadoGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Empleado();
        }

        /// <inheritdoc cref="IDao{TModel}.Read()"/>
        /// <summary>
        /// Obtiene todos los registros de la tabla Empleado mediante el uso del procedimiento almacenado EmpleadoGet.
        /// </summary>
        public override IEnumerable<Empleado> Read()
        {
            return Read(StoredProcedures.EmpleadoGet);
        }

        /// <summary>
        /// Obtiene los registros de la tabla Empleado en los que el campo Estado es igual al valor dado y IdContacto es igual al valor dado, 
        /// mediante el uso del procedimiento almacenado EmpleadoGet.
        /// </summary>
        /// <param name="estado">Valor usado para buscar en el campo Estado</param>
        /// <param name="idContacto">Valor usado para buscar en el campo IdContacto</param>
        public IEnumerable<Empleado> Read(bool estado, int idContacto)
        {
            return Read(StoredProcedures.EmpleadoGet, new Dictionary<string, object>
            {
                ["Estado"] = estado,
                ["IdContacto"] = idContacto
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        /// <summary>
        /// Actualiza los datos de un registro en la tabla Empleado con el id dado mediante el uso del procedimiento almacenado EmpleadoUpdate.
        /// </summary>
        /// <param name="id">Id del registro que será modificado</param>
        /// <param name="model">Los nuevos datos que reemplazarán los antiguos</param>
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

