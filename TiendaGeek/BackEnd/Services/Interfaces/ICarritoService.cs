using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICarritoService
    {
        IEnumerable<CarritoModel> GetAll();
        bool Add(CarritoModel carrito);
        CarritoModel Get(int id);
    }
}
