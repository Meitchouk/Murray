﻿namespace Murray.ViewModels.Sales
{
    internal class DetalleVentaView
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public double Subtotal { get; set; }
    }
}
