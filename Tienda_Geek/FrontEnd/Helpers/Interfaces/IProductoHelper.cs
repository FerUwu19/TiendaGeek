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
    }
}
