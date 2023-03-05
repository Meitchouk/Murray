using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    //Clase interna que hereda de la clase BaseDao y la interfaz IMunicipioDao.
    internal class MunicipioDao : BaseDao<Municipio>, IMunicipioDao 
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        /// <param name="handler">Manejador de errores personalizado.</param>
        public MunicipioDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        #region Public Methods
        
        //Implementación del método Create definido en la interfaz IDao<T>.
        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>/>
        public override Municipio Create(Municipio model)
        {
            if (Validate(model, Operation.CREATE))
                return new Municipio();

            return Read(StoredProcedures.MunicipioCreate, new Dictionary<string, object>
            {
                ["Nombre"] = model.Nombre,
                ["IdDepartamento"] = model.IdDepartamento

            }).FirstOrDefault() ?? new Municipio();
        }
        
        //Implementación del método Delete definido en la interfaz IDao<T>.
        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Municipio Delete(int id)
        {
            return Read(StoredProcedures.MunicipioDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Municipio();
        }
        
        //Implementación del método GetByDepartamento definido en la interfaz IMunicipioDao.
        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public IEnumerable<Municipio> GetByDepartamento(int departamento)
        {
            return GetByDepartamento(departamento, string.Empty);
        }

        //Implementación del método GetByDepartamento definido en la interfaz IMunicipioDao.
        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public IEnumerable<Municipio> GetByDepartamento(int departamento, string value)
        {
            return Read(StoredProcedures.MunicipioGet, new Dictionary<string, object>
            {
                ["IdDepartamento"] = departamento,
                ["Nombre"] = value
            });
        }
       
        //Implementación del método GetById definido en la interfaz IMunicipioDao.
        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public Municipio GetById(int id)
        {
            return Read(StoredProcedures.MunicipioGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Municipio();
        }
       
        //Implementación del método Read definido en la interfaz IMunicipioDao.
        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public IEnumerable<Municipio> Read(string value)
        {
            return Read(StoredProcedures.MunicipioGet, new Dictionary<string, object>
            {
                ["Nombre"] = value
            });
        }
        
        //Implementación del método Read definido en la interfaz IDao<T>.
        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Municipio> Read()
        {
            return Read(string.Empty);
        }
        
        //Implementación del método Update definido en la interfaz IDao<T>.
        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Municipio Update(int id, Municipio model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Municipio();

            return Read(StoredProcedures.MunicipioCreate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Nombre"] = model.Nombre,
                ["IdDepartamento"] = model.IdDepartamento

            }).FirstOrDefault() ?? new Municipio();
        }
        #endregion

        #region Private Methods

        //Valida si el modelo es válido y no contiene errores.
        private bool Validate(Municipio model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            if (model.IdDepartamento.Equals(default))
                Handler.Add("ID_MUNICIPIO_NOT_EXISTS");

            return Handler.HasError();
        }

        #endregion
    }
}

