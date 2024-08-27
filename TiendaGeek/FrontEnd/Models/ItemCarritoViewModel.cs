namespace FrontEnd.Models
{
  public class ItemCarritoViewModel
    {

        public int Id { get; set; }

        public int Cantidad { get; set; }

        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public int CarritoId { get; set; }

        public virtual CarritoViewModel Carrito { get; set; } = null!;

        public virtual ProductoViewModel Producto { get; set; } = null!;
    }
}
