using Common.Util;
using Models.Interfaces;

namespace Connection.Base
{
    /// <summary>
    ///     Validaciones de datos relacionado a modelos // Clase que contine funciones de validacion para los modelos.
    /// </summary>
    internal static class Validations
    {
        /// <summary>
        ///     Realiza validaciones genericas con base a el tipo de modelo correspondiente // Funcion que valida un modelo recibido, en funcion  de su tipo realiza diferentes validaciones y hace uso del objeto handler para guardar los errores encontrados.
        /// </summary>
        /// <typeparam name="TModel">
        ///     Modelo a validar
        /// </typeparam>
        /// <param name="model">
        ///     Registro del modelo 
        /// </param>
        /// <param name="handler">
        ///     Administrador de errores  // Referencia al objeto Handler donde se almacenaran los errores encontrados.
        /// </param>
        /// <param name="operation">
        ///     Tipo de operación a realizar // Parametro opcional para informar el tipo de operacion a realizar (por defecto DEFAULT)
        /// </param>
        public static bool Validate<TModel>(TModel model, ErrorHandler handler, Operation operation = Operation.DEFAULT) where TModel : new()
        {
            if (model == null) // Si el modelo es nulo, agregar mensaje de error "MODEL_IS_NULL".
            {
                handler.Add("MODEL_IS_NULL");
                return false; // retornar falso para indicar que hubo errores.
            }

            if ((operation.Equals(Operation.UPDATE) || operation.Equals(Operation.CREATE)) && model is INameable nameable) // Si la operacion quiere hacer UPDATE o CREATE y el modelo implementa el interfaz INameable, valida si tiene un nombre vacio y agrega el mensaje de error "NOMBRE_IS_EMPTY".
            {
                if (string.IsNullOrEmpty(nameable.Nombre))
                    handler.Add("NOMBRE_IS_EMPTY");
            }

            if (operation.Equals(Operation.DELETE) && model is IActivable activable) // Si la operacion es DELETE y el modelo implementa el interfaz IActivable, valida si el estado ya fue eliminado previamente y agrega el mensaje de error "ESTADO_ALREADY_DELETED".
            {
                if (activable.Estado.Equals(false))
                    handler.Add("ESTADO_ALREADY_DELETED");
            }

            if (operation.Equals(Operation.UPDATE) && model is IIdentity identity) // Si la operacion es UPDATEy el modelo implementa el interfaz IIdentity, valida si el identificador id es invalido (valor default) y agrega el mensjae de error "INVALID_ID".
            {
                if (identity.Id.Equals(default))
                    handler.Add("INVALID_ID");
            }

            if ((operation.Equals(Operation.UPDATE) || operation.Equals(Operation.CREATE)) && model is ITransacction transacction) // Si la operacion es UPDATE o CREATE y el modelo implementa el interfaz ITransacction, valida si la fecha y el empleado son invalidos y agrega los mensajes de error respectivos: "FECHA_IS_EMPTY" y "EMPLEADO_IS_EMPTY".
            {
                if (transacction.Fecha.Equals(default))
                    handler.Add("FECHA_IS_EMPTY");

                if (transacction.IdEmpleado.Equals(default))
                    handler.Add("EMPLEADO_IS_EMPTY");
            }

            if ((operation.Equals(Operation.UPDATE) || operation.Equals(Operation.CREATE)) && model is ITransacctionDetail transacctionDetail) // Si la operacion es UPDATE o CREATE y el modelo implementa el interfaz ITransacctionDetail, valida si el producto es invalido (valor por defecto) y agrega el mensaje de error "PRODUCTO_IS_EMPTY".
            {
                if (transacctionDetail.IdProducto.Equals(default))
                    handler.Add("PRODUCTO_IS_EMPTY");
            }

            return handler.HasError(); // Retorna verdadero si encuentra errores, sino retorna false.
        }
    }

    /// <summary>
    ///     Tipos de operacion a validar  // Enumeracion que contiene los diferentes Operaciones disponibles para la validacion. Esta enumeracion no esta siendo usada actualmente.
    /// </summary>
    internal enum Operation
    {
        DEFAULT = 0,
        CREATE = 1,
        UPDATE = 2,
        DELETE = 3,
    }
}
