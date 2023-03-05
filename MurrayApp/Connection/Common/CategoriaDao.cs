using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    // Clase CategoriaDao encargada de manejar la tabla Categoria
    internal class CategoriaDao : BaseDao<Categoria>, ICategoriaDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto que inicializa los atributos de conexion y manejador de errores.
        /// </summary>
        public CategoriaDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {            
        }

        #endregion

        #region Public Methods

        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override Categoria Create(Categoria model)
        {
            // Si el modelo es valido, crear una Categoria vacía
            if (Validate(model, Operation.CREATE))
                return new Categoria();

            // Llamar al metodo Read de la clase padre para realizar una operación de creacion.
            return Read(StoredProcedures.CategoriaCreate, new Dictionary<string, object>
            {
                ["Nombre"] = model.Nombre

            }).FirstOrDefault() ?? new Categoria();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Categoria Delete(int id)
        {
            // Llamar al metodo Read de la clase padre para realizar una operación de eliminacion.
            return Read(StoredProcedures.CategoriaDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Categoria();
        }

        /// <inheritdoc cref="ICategoriaDao.GetById(int)"/>
        public Categoria GetById(int id)
        {
            // Llamar al metodo Read de la clase padre para obtener una categoria por su id.
            return Read(StoredProcedures.CategoriaGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Categoria();
        }

        /// <inheritdoc cref="ICategoriaDao.Read(string)"/>
        public IEnumerable<Categoria> Read(string value)
        {
            // Llamar al metodo Read de la clase padre para obtener todas las categorias o por nombre.
            return Read(StoredProcedures.CategoriaGet, new Dictionary<string, object>
            {
                ["Nombre"] = value
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Categoria> Read()
        {
            // Llamar al metodo Read(string) con un parametro vacio.
            return Read(string.Empty);
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Categoria Update(int id, Categoria model)
        {
            // Si el modelo es valido, actualizar una Categoria vacía.
            if (Validate(model, Operation.UPDATE))
                return new Categoria();

            // Llamar al metodo Read de la clase padre para realizar una operación de actualización.
            return Read(StoredProcedures.CategoriaUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Nombre"] = model.Nombre

            }).FirstOrDefault() ?? new Categoria();
        }

        #endregion

        #region Private Methods

        private bool Validate(Categoria model, Operation operation)
        {   
            // Llamar al metodo Validate de la clase Validations
            if (Validations.Validate(model, Handler, operation))
                return false;

            // Indicar si existen errores
            return Handler.HasError();
        }

        #endregion
    }
}
