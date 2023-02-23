using Models.Interfaces;
using System;

namespace Models.Common
{
    /// <summary>
    ///     Registro de identificacion de una persona dentro del sistema
    /// </summary>
    public class Contacto : IIdentity
    {
        /// <inheritdoc cref="IIdentity.Id"/>
        public int Id { get; set; }

        /// <summary>
        ///     Fecha de nacimiento del contacto
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }

        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }

        //public string RazonSocial { get; set; } // Eliminar Razon Social 

        #region Foreing Key

        /// <summary>
        ///     Id del Municipio
        /// </summary>
        public int IdMunicipio { get; set; }

        #endregion

        #region Extended Fields

        public string NombreCompleto
        {
            get
            {
                //if (!string.IsNullOrEmpty(RazonSocial))
                   //return RazonSocial;

                return $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";
            }
        }

        public int Edad
        {
            get
            {
                if (!FechaNacimiento.HasValue)
                    return default;

                return DateTime.Today.Year - FechaNacimiento.Value.Year;
            }
        }

        #endregion
    }
}
