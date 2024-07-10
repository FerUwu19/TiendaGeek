namespace FrontEnd.Models
{
    public class ProductoViewModel
    {

        public int CodigoProducto { get; set; }

        public int? CodigoCategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public int? Unidades { get; set; }

        public string? Estado { get; set; }
        /*
        public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

        public virtual Categorium? CodigoCategoriaNavigation { get; set; }

        public virtual ICollection<ImagenProducto> ImagenProductos { get; set; } = new List<ImagenProducto>();
        */
    }
}
