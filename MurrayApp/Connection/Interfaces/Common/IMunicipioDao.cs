using Connection.Base;
using Models.Common;

using System.Collections.Generic;

namespace Connection.Interfaces.Common
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Municipio
    /// </summary>
    public interface IMunicipioDao : IDao<Municipio>
    {
        /// <summary>
        ///     Obtiene municipio por id
        /// </summary>
        /// <param name="id">
        ///     Id del municipio
        /// </param>=
        Municipio GetById(int id);

        /// <summary>
        ///     Obtiene municipios de un departamento
        /// </summary>
        /// <param name="departamento">
        ///     Id del departamento
        /// </param>
        IEnumerable<Municipio> GetByDepartamento(int departamento);

        /// <summary>
        ///     Obtiene municipios de un departamento
        /// </summary>
        /// <param name="departamento">
        ///     Id del departamento
        /// </param>
        /// <param name="value">
        ///     Filtro de nombre
        /// </param>=
        IEnumerable<Municipio> GetByDepartamento(int departamento, string value);

        /// <summary>
        ///     Busca todos los municipios en la base de datos
        /// </summary>
        /// <param name="value">
        ///     Busca municipios con el valor como filtro
        /// </param>
        /// <returns>
        ///     Lista de municipios con coincidencia en el filtro
        /// </returns>
        IEnumerable<Municipio> Read(string value);
    }
}
