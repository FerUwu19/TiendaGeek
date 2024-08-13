namespace BackEnd.Model
{
    public class CarritoModel
    {
        public int CodigoCarrito { get; set; }
        public int? CodigoUsuario { get; set; }
        public int? CodigoProducto { get; set; }
        public decimal? TotalCompra { get; set; }
    }
}
