using Common.Util;

using Connection.Common;
using Connection.Identity;
using Connection.Sale;
using Connection.Shopping;

using Connection.Interfaces.Identity;
using Connection.Interfaces.Common;
using Connection.Interfaces.Sale;
using Connection.Interfaces.Shopping;

using System;
using System.Collections.Generic;

namespace Connection
{
    /// <summary>
    ///     Fabrica de DAO
    /// </summary>
    public static class Factory
    {
        #region Private Fields

        /// <summary>
        ///     Mapping de interfaces con las implementaciones de los DAO's
        /// </summary>
        private static readonly IDictionary<Type, Type> Dao = new Dictionary<Type, Type>
        {
            // Identity
            [typeof(IUsuarioDao)] = typeof(UsuarioDao),

            // Common
            [typeof(ICategoriaDao)] = typeof(CategoriaDao),
            [typeof(IContactoDao)] = typeof(ContactoDao),
            [typeof(IDepartamentoDao)] = typeof(DepartamentoDao),
            [typeof(IEmpleadoDao)] = typeof(EmpleadoDao),
            [typeof(IMunicipioDao)] = typeof(MunicipioDao),
            [typeof(IProductoDao)] = typeof(ProductoDao),

            // Sale
            [typeof(IClienteDao)] = typeof(ClienteDao),
            [typeof(IVentaDao)] = typeof(VentaDao),
            [typeof(IDetalleVentaDao)] = typeof(DetalleVentaDao),

            // Shopping
            [typeof(IProveedorDao)] = typeof(ProveedorDao),
            [typeof(ICompraDao)] = typeof(CompraDao),
            [typeof(IDetalleCompraDao)] = typeof(DetalleCompraDao)
        };

        #endregion

        /// <summary>
        ///     Realiza la invocacion de un DAO con base al mapping ya configurado
        /// </summary>
        /// <typeparam name="TDao">
        ///     Tipo del DAO a invocar
        /// </typeparam>
        /// <param name="connectionString">
        ///     Cadena de conexion a la base de datos
        /// </param>
        public static TDao Invoke<TDao>(string connectionString, ErrorHandler handler)
        {
            if (!Dao.TryGetValue(typeof(TDao), out var daoType))
                throw new ArgumentException("El tipo de DAO a invocar no se encuentra mapeado");

            var constructor = daoType.GetConstructor(new Type[] { typeof(string), typeof(ErrorHandler) });
            if (constructor is null)
                throw new ArgumentNullException("El DAO a invocar no tiene configurado un constuctor que considere la cadena de conexion");

            return (TDao)constructor.Invoke(new object[] { connectionString, handler });
        }
    }
}
