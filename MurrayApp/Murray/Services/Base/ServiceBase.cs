using Common.Util;
using System;

namespace Murray.Services.Base
{
    /// <summary>
    ///     Estructura base un servicio
    /// </summary>
    internal abstract class ServiceBase : IDisposable
    {
        #region Protected Fields

        /// <summary>
        ///     Administrador de erroes
        /// </summary>
        protected readonly ErrorHandler Handler;

        #endregion

        /// <summary>
        ///     Constructor
        /// </summary>
        protected ServiceBase(ErrorHandler handler)
        {
            Handler = handler;
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public abstract void Dispose();
    }
}
