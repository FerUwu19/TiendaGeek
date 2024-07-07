using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProductoHelper
    {
        ProductoViewModel Add(ProductoViewModel distrito);
        List<ProductoViewModel> GetProductos();
        ProductoViewModel GetProducto(int id);
        ProductoViewModel Update(ProductoViewModel distrito);
        ProductoViewModel Remove(int id);
    }
}
