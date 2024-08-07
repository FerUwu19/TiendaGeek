using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProductoHelper
    {
        ProductoViewModel Add(ProductoViewModel producto);
        List<ProductoViewModel> GetProductos();
        ProductoViewModel GetProducto(int id);
        ProductoViewModel Update(ProductoViewModel producto);
        ProductoViewModel Remove(int id);

        // Método para filtrar productos por categorías
        List<ProductoViewModel> GetProductosByCategories(List<int> categoryIds);
    }
}
