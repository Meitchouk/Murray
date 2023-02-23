using Connection.Base;
using Models.Shopping;

using System.Collections.Generic;

namespace Connection.Interfaces.Shopping
{
    /// <summary>
    ///     Conexion a la base de datos con el objeto Proveedor
    /// </summary>
    public interface IProveedorDao : IDao<Proveedor>
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
        IEnumerable<Proveedor> Read(bool estado, int idContacto);

        /// <summary>
        ///     Obtiene proveedor por id
        /// </summary>
        /// <param name="id">
        ///     Id del proveedor
        /// </param>
        Proveedor GetById(int id);
    }
}
