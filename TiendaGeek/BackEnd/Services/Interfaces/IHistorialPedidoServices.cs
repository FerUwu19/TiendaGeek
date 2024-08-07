using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IHistorialPedidoServices
    {
        IEnumerable<HistorialPedidoModel> GetAll();
        bool Add(HistorialPedidoModel _hist);
        HistorialPedidoModel Get(int _id);
        bool Update(HistorialPedidoModel _hist);
        bool Remove(HistorialPedidoModel _hist);
    }
}