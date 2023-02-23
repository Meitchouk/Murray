using Common.Util;
using Connection.Base;
using Connection.Constants;
using Connection.Interfaces.Common;
using Models.Common;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Common
{
        
    /// <inheritdoc cref="IDepartamentoDao"/>
    internal class DepartamentoDao : BaseDao<Departamento>, IDepartamentoDao
    {
        #region Constructors

        /// <summary>
        ///     Constructor base
        /// </summary>
        public DepartamentoDao(string connectionString, ErrorHandler handler) : base(connectionString, handler)
        {

        }

        #endregion

        #region Public Methods


        /// <inheritdoc cref="IDao{TModel}.Create(TModel)"/>
        public override Departamento Create(Departamento model)
        {
            if (Validate(model, Operation.CREATE))
                return new Departamento();

            return Read(StoredProcedures.DepartamentoCreate, new Dictionary<string, object>
            {
                ["Nombre"] = model.Nombre
            })
            .FirstOrDefault() ?? new Departamento();
        }

        /// <inheritdoc cref="IDao{TModel}.Delete(int)"/>
        public override Departamento Delete(int id)
        {
            return Read(StoredProcedures.DepartamentoDelete, new Dictionary<string, object>
            {
                ["Id"] = id
            })
            .FirstOrDefault() ?? new Departamento();
        }

        /// <inheritdoc cref="IDao{TModel}.Read()"/>
        public override IEnumerable<Departamento> Read()
        {
            return Read(string.Empty);
        }

        /// <inheritdoc cref="IDepartamentoDao.Read(string)"/>
        public IEnumerable<Departamento> Read(string nombre)
        {
            return Read(StoredProcedures.DepartamentoGet, new Dictionary<string, object>
            {
                ["Nombre"] = nombre
            });
        }

        /// <inheritdoc cref="IDao{TModel}.Update(int, TModel)"/>
        public override Departamento Update(int id, Departamento model)
        {
            if (Validate(model, Operation.UPDATE))
                return new Departamento();

            return Read(StoredProcedures.DepartamentoUpdate, new Dictionary<string, object>
            {
                ["Id"] = id,
                ["Nombre"] = model.Nombre
            })
            .FirstOrDefault() ?? new Departamento();
        }
        #endregion

        #region Private Methods

        /// <summary>
        ///     Validaciones propias de un depatamento
        /// </summary>
        private bool Validate(Departamento model, Operation operation)
        {
            if (Validations.Validate(model, Handler, operation))
                return false;

            if (model.Nombre.Length > 50)
                Handler.Add("NOMBRE_LENGTH_EXCEED");

            return Handler.HasError();
        }

        #endregion
    }
}