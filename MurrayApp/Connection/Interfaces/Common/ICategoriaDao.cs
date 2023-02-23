using Connection.Base;
using Models.Common;

using System.Collections.Generic;

namespace Connection.Interfaces.Common
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Categoria
    /// </summary>
    public interface ICategoriaDao : IDao<Categoria>
    {
        /// <summary>
        ///     Busca todos las categorias en la base de datos
        /// </summary>
        /// <param name="value">
        ///     Busca categorias con el valor como filtro
        /// </param>
        /// <returns>
        ///     Lista de categorias con coincidencia en el filtro
        /// </returns>
        IEnumerable<Categoria> Read(string value);

        /// <summary>
        ///     Obtiene categoria por id
        /// </summary>
        /// <param name="id">
        ///     Id de la categoria
        /// </param>=
        Categoria GetById(int id);
    }
}
