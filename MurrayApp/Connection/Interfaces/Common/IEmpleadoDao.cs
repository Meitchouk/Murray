using Connection.Base;
using Models.Common;

using System.Collections.Generic;

namespace Connection.Interfaces.Common
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Empleado
    /// </summary>
    public interface IEmpleadoDao : IDao<Empleado>
    {
        /// <summary>
        ///     Busca todos los empleados en la base de datos
        /// </summary>
        /// <param name="estado">
        ///     Filtro para buscar empleados por su estado
        /// </param>
        /// <param name="idContacto">
        ///     Filtro para buscar empleados por el ID de su contacto
        /// </param>
        /// <returns>
        ///     Lista de empleados que coincidan con el filtro
        /// </returns>
        IEnumerable<Empleado> Read(bool estado, int idContacto);

        /// <summary>
        ///     Obtiene empleado por id
        /// </summary>
        /// <param name="id">
        ///     Id del empleado a obtener
        /// </param>=
        Empleado GetById(int id);
    }
}
