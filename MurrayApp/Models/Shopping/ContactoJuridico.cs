using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Shopping
{
    internal class ContactoJuridico
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; } 
        public int IdMunicipio { get; set; }
        public bool Estado { get; set; }


    }
}
