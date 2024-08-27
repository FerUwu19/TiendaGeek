using Entities.Entities;
using System.Collections.Generic;

namespace BackEnd.Services.Interfaces
{
    public interface ICarritoService
    {
        bool CreateCarrito(Carrito carrito);
        Carrito GetCarritoById(int id);
        IEnumerable<Carrito> GetAllCarritos();
        Carrito GetCarritoByUsuarioId(string usuarioId, string estado = "Incompleto");
        Carrito GetCarritoByTemporalId(string carritoTemporalId, string estado = "Incompleto");
        bool UpdateCarrito(Carrito carrito);
        bool DeleteCarrito(int id);
        bool MergeCarritos(int usuarioCarritoId, int temporalCarritoId);
        IEnumerable<Carrito> GetCompletedCarritos(string usuarioId);

        bool AddItemToCarrito(ItemCarrito itemCarrito);
        bool UpdateItemInCarrito(ItemCarrito itemCarrito);
        bool RemoveItemFromCarrito(int id);
        IEnumerable<ItemCarrito> GetItemsByCarritoId(int carritoId);
    }
}
