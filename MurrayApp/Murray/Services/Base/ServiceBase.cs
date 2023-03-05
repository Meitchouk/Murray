using Common.Util;
using System;

namespace Murray.Services.Base
{
    // Clase interna abstracta que representa la estructura base de un servicio
    internal abstract class ServiceBase : IDisposable
    {
        #region Campos Protegidos

        // Campo protegido que almacena una instancia de la clase ErrorHandler, 
        // la cual sirve como administrador de errores.
        protected readonly ErrorHandler Handler;

        #endregion

        /// <summary>
        ///     Constructor que recibe una instancia de la clase ErrorHandler y establece el valor del campo Handler.
        /// </summary>
        protected ServiceBase(ErrorHandler handler)
        {
            Handler = handler;
        }

        // Método abstracto que implementa la interfaz IDisposable y se encarga de liberar los recursos no 
        // administrados utilizados por un objeto ServiceBase.
        public abstract void Dispose();
    }
}