namespace Murray.ViewModels.Sales
{
    internal class VentaView
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public int Productos { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
    }
}
