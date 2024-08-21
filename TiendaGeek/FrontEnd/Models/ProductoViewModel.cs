using FrontEnd.ApiModel;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        public int CodigoProducto { get; set; }
        public int? CodigoCategoria { get; set; }
        public IEnumerable<CategoriumViewModel> Categorias { get; set; } = new List<CategoriumViewModel>();
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Unidades { get; set; }
        public string? Estado { get; set; }
        public string? ImagenPrincipal { get; set; }

        // Lista de imágenes
        public List<ImagenProductoViewModel>? Imagenes { get; set; }
    }
}
