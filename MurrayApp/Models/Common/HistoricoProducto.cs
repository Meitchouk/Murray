using System;

namespace Models.Common
{
    internal class HistoricoProducto
    {
        public int Id { get; set; }
        public string TituloHistorico { get; set; }
        public string Descripcion  { get; set; }
        public DateTime FechaHistorico { get; set; }
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }   

    }
}
