using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoriumHelper
    {
        CategoriumViewModel Add(CategoriumViewModel categoria);
        List<CategoriumViewModel> GetCategorias();
        CategoriumViewModel GetCategoria(int id);
        CategoriumViewModel Update(CategoriumViewModel categoria);
        CategoriumViewModel Remove(int id);
    }
}
