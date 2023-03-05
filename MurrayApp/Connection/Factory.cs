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
    ///     Fabrica de DAO (Data Access Objects)
    /// </summary>
    public static class Factory
    {
        #region Campos Privados

        /// <summary>
        ///     Mapeo de interfaces con la implementación de los DAO's.
        /// </summary>
        private static readonly IDictionary<Type, Type> Dao = new Dictionary<Type, Type>
        {
            // Identidad
            [typeof(IUsuarioDao)] = typeof(UsuarioDao),

            // Común
            [typeof(ICategoriaDao)] = typeof(CategoriaDao),
            [typeof(IContactoDao)] = typeof(ContactoDao),
            [typeof(IDepartamentoDao)] = typeof(DepartamentoDao),
            [typeof(IEmpleadoDao)] = typeof(EmpleadoDao),
            [typeof(IMunicipioDao)] = typeof(MunicipioDao),
            [typeof(IProductoDao)] = typeof(ProductoDao),

            // Venta
            [typeof(IClienteDao)] = typeof(ClienteDao),
            [typeof(IVentaDao)] = typeof(VentaDao),
            [typeof(IDetalleVentaDao)] = typeof(DetalleVentaDao),

            // Compra
            [typeof(IProveedorDao)] = typeof(ProveedorDao),
            [typeof(ICompraDao)] = typeof(CompraDao),
            [typeof(IDetalleCompraDao)] = typeof(DetalleCompraDao)
        };

        #endregion

        /// <summary>
        ///     Realiza la invocación de un DAO en base al mapeo ya configurado.
        /// </summary>
        /// <typeparam name="TDao">
        ///     Tipo del DAO a invocar.
        /// </typeparam>
        /// <param name="connectionString">
        ///     Cadena de conexión para la base de datos.
        /// </param>
        public static TDao Invoke<TDao>(string connectionString, ErrorHandler handler)
        {
            // Verifica si el tipo de DAO se encuentra registrado en el mapeo "Dao"
            if (!Dao.TryGetValue(typeof(TDao), out var daoType))
                throw new ArgumentException("El tipo de DAO a invocar no se encuentra mapeado");
        
            // Obtiene el constructor que recibe como parámetro una cadena de conexión y un manejador de errores
            var constructor = daoType.GetConstructor(new Type[] { typeof(string), typeof(ErrorHandler) });
            // Valida si existe un constructor configurado que considere la cadena de conexión
            if (constructor is null)
                throw new ArgumentNullException("El DAO a invocar no tiene configurado un constructor que considere la cadena de conexión");
        
            // Retorna una nueva instancia del DAO especificado
            return (TDao)constructor.Invoke(new object[] { connectionString, handler });
        }
        
    }
}
