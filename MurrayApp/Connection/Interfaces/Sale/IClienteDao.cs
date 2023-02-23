using Connection.Base;
using Models.Sale;

using System.Collections.Generic;

namespace Connection.Interfaces.Sale
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Cliente
    /// </summary>
    public interface IClienteDao : IDao<Cliente>
    {
        /// <summary>
        ///     Busca todos los clientes en la base de datos
        /// </summary>
        /// <param name="estado">
        ///     Filtro para buscar clientes por su estado
        /// </param>
        /// <param name="idContacto">
        ///     Filtro para buscar clientes por el ID de su contacto
        /// </param>
        /// <returns>
        ///     Lista de empleados que coincidan con el filtro
        /// </returns>
        IEnumerable<Cliente> Read(bool estado, int idContacto);

        /// <summary>
        ///     Obtiene cliente por id
        /// </summary>
        /// <param name="id">
        ///     Id del cliente
        /// </param>
        Cliente GetById(int id);
    }
}
