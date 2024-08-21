using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IImagenProductoHelper
    {
        ImagenProductoViewModel Add(ImagenProductoViewModel ImagenProducto);
        List<ImagenProductoViewModel> GetImagenProductos();
        ImagenProductoViewModel GetImagenProducto(int id);
        ImagenProductoViewModel Update(ImagenProductoViewModel ImagenProducto);
        ImagenProductoViewModel Remove(int id);

        List<ImagenProductoViewModel> GetImagenesPorProducto(int productoId);
    }
}
