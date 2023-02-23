using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
    internal class MunicipioDao : BaseDao<Municipio>, IMunicipioDao
    {
        #region Constructor

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        public MunicipioDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {
        }

        #endregion

        #region Public Methods
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

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Municipio Delete(int id)
        {
            return Read(StoredProcedures.MunicipioDelete, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Municipio();
        }

        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public IEnumerable<Municipio> GetByDepartamento(int departamento)
        {
            return GetByDepartamento(departamento, string.Empty);
        }

        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public IEnumerable<Municipio> GetByDepartamento(int departamento, string value)
        {
            return Read(StoredProcedures.MunicipioGet, new Dictionary<string, object>
            {
                ["IdDepartamento"] = departamento,
                ["Nombre"] = value
            });
        }

        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public Municipio GetById(int id)
        {
            return Read(StoredProcedures.MunicipioGet, new Dictionary<string, object>
            {
                ["Id"] = id

            }).FirstOrDefault() ?? new Municipio();
        }

        /// <inheritdoc cref="IMunicipioDao.Read(string)"/>
        public IEnumerable<Municipio> Read(string value)
        {
            return Read(StoredProcedures.MunicipioGet, new Dictionary<string, object>
            {
                ["Nombre"] = value
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Read"/>
        public override IEnumerable<Municipio> Read()
        {
            return Read(string.Empty);
        }

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
