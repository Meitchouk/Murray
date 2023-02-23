using System;
using System.Resources;
using System.Collections.Generic;
using System.Text;

namespace Common.Util
{
    /// <summary>
    ///     Clase de administracion de errores
    /// </summary>
    public class ErrorHandler : List<string>
    {
        /// <summary>
        ///     Anexa mensaje de excepcion
        /// </summary>
        public void Add(Exception exception)
        {
            if (exception is null)
                return;

            if (exception.InnerException != null)
            {
                Add(exception.InnerException);
                return;
            }

            Add(exception.Message);
        }

        /// <summary>
        ///     Indica si existen errores almacenados
        /// </summary>
        public bool HasError()
        {
            return Count > 0;
        }

        /// <summary>
        ///     Obtiene el mensaje de error
        /// </summary>
        public string GetErrorMessage()
        {
            if (Count == 0)
                return string.Empty;

            var builder = new StringBuilder();
            var manager = new ResourceManager(typeof(Resources.Messages));

            foreach (var code in this)
            {
                var message = manager.GetString(code);
                if (message is null)
                    message = $"_{code}";

                builder.AppendLine(message);
            }

            Clear();
            return builder.ToString();
        }
    }
}
