using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoriumService
    {
        bool Add(CategoriumModel Categorium);
        bool Remove(CategoriumModel Categorium);
        bool Update(CategoriumModel Categorium);

        CategoriumModel Get(int id);
        IEnumerable<CategoriumModel> Get();
    }
}