using System;

namespace Models.Common
{
    internal class Garantias
    {
        public int Id { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool Estado { get; set; }
    }
}
