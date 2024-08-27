using Entities.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ICarritoDAL
    {
        IEnumerable<Carrito> GetAll();
        bool Add(Carrito carrito);
        Carrito Get(int id);

        Carrito GetCarritoByUsuarioId(string usuarioId, string estado = "Incompleto");
        Carrito GetCarritoByTemporalId(string carritoTemporalId, string estado = "Incompleto");
        bool Update(Carrito carrito);
        bool Remove(Carrito carrito);
        bool MergeCarritos(Carrito usuarioCarrito, Carrito temporalCarrito);
        IEnumerable<Carrito> GetCarritosCompletados(string usuarioId);
    }
}
