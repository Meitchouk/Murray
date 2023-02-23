using Common.Util;
using Models.Interfaces;

namespace Connection.Base
{
    /// <summary>
    ///     Validaciones de datos relacionado a modelos
    /// </summary>
    internal static class Validations
    {
        /// <summary>
        ///     Realiza validaciones genericas con base a el tipo de modelo correspondiente
        /// </summary>
        /// <typeparam name="TModel">
        ///     Modelo a validar
        /// </typeparam>
        /// <param name="model">
        ///     Registro del modelo
        /// </param>
        /// <param name="handler">
        ///     Administrador de errores
        /// </param>
        /// <param name="operation">
        ///     Tipo de operación a realizar
        /// </param>
        public static bool Validate<TModel>(TModel model, ErrorHandler handler, Operation operation = Operation.DEFAULT) where TModel : new()
        {
            if (model == null)
            {
                handler.Add("MODEL_IS_NULL");
                return false;
            }

            if ((operation.Equals(Operation.UPDATE) || operation.Equals(Operation.CREATE)) && model is INameable nameable)
            {
                if (string.IsNullOrEmpty(nameable.Nombre))
                    handler.Add("NOMBRE_IS_EMPTY");
            }

            if (operation.Equals(Operation.DELETE) && model is IActivable activable)
            {
                if (activable.Estado.Equals(false))
                    handler.Add("ESTADO_ALREADY_DELETED");
            }

            if (operation.Equals(Operation.UPDATE) && model is IIdentity identity)
            {
                if (identity.Id.Equals(default))
                    handler.Add("INVALID_ID");
            }

            if ((operation.Equals(Operation.UPDATE) || operation.Equals(Operation.CREATE)) && model is ITransacction transacction)
            {
                if (transacction.Fecha.Equals(default))
                    handler.Add("FECHA_IS_EMPTY");

                if (transacction.IdEmpleado.Equals(default))
                    handler.Add("EMPLEADO_IS_EMPTY");
            }

            if ((operation.Equals(Operation.UPDATE) || operation.Equals(Operation.CREATE)) && model is ITransacctionDetail transacctionDetail)
            {
                if (transacctionDetail.IdProducto.Equals(default))
                    handler.Add("PRODUCTO_IS_EMPTY");
            }

            return handler.HasError();
        }
    }

    /// <summary>
    ///     Tipos de operacion a validar 
    /// </summary>
    internal enum Operation
    {
        DEFAULT = 0,
        CREATE = 1,
        UPDATE = 2,
        DELETE = 3,
    }
}
