using System;
using System.Resources;
using System.Collections.Generic;
using System.Text;

namespace Common.Util
{
    /// <summary>
    /// Clase de administracion de errores
    /// </summary>

    public class ErrorHandler : List<string>
    {
        /// <summary>
        /// Anexa mensaje de excepcion
        /// </summary>
        public void Add(Exception exception)
        {

            if (exception is null) // Verifica si la excepción es nula
                return;

            if (exception.InnerException != null) //Verifica si existe una InnerException 
            {
                Add(exception.InnerException); //Recursivamente llama a si mismo para agregar la inner Exception 
                return;
            }

            Add(exception.Message); //Si no hay InnerException, agrega el mensaje de  la excepción.
        }

        /// <summary>
        /// Indica si existen errores almacenados
        /// </summary>
        public bool HasError()
        {
            return Count > 0; //Devuelve verdadero si tiene un error almacenado en la lista.
        }

        /// <summary>
        /// Obtiene el mensaje de error
        /// </summary>
        public string GetErrorMessage()
        {
            if (Count == 0)
                return string.Empty; //Retorna una cadena vacía si no hay mensajes

            //Crea un StringBuilder donde se almacenaran los mensajes.
            var builder = new StringBuilder();

            //Crea un nuevo ResourceManager para obtener los mensajes del recurso Messages.
            var manager = new ResourceManager(typeof(Resources.Messages));

            foreach (var code in this) //Itera a través de cada código de error en esta lista de Handler y obtiene el mensaje correspondiente.
            {
                var message = manager.GetString(code); 

                if (message is null) //Si el mensaje es nulo, entonces crea uno nuevo usando el código como prefijo en Guion Bajo (_).
                    message = $"_{code}";
                /*
                El prefijo de guion bajo se utiliza como una convención para indicar que el mensaje correspondiente no se encontró en el objeto 
                ResourceManager y que se está utilizando un mensaje predeterminado en su lugar. 
                */

                builder.AppendLine(message); //Agrega el mensaje al StringBuilder usando la operación AppendLine()
            }

            Clear(); //Limpia Lista actual
            return builder.ToString(); //Retorna el mensaje completo con todos los mensajes de error concatenados.
        }
    }
}
