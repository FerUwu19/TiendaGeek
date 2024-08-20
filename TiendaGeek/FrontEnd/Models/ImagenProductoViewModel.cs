namespace FrontEnd.Models
{
    public class ImagenProductoViewModel
    {
        public int CodigoImagen { get; set; }

        public int? CodigoProducto { get; set; }

        public string? NombreProducto { get; set; }
        public IEnumerable<ProductoViewModel> Productos { get; set; } = new List<ProductoViewModel>();

        public string? RutaImagen { get; set; }
    }
}
