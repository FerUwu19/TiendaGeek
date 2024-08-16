using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IProductoService
    {
        bool Add(ProductoModel Producto);
        bool Remove(ProductoModel Producto);
        bool Update(ProductoModel Producto);

        ProductoModel Get(int id);
        IEnumerable<ProductoModel> Get();

        //método para filtrar por categoría
        IEnumerable<ProductoModel> GetByCategory(int categoryId);
    }
}
