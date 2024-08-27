using FrontEnd.Models;
using System.Collections.Generic;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICarritoHelper
    {
        CarritoViewModel CreateCarrito(CarritoViewModel carrito);
        CarritoViewModel GetCarritoById(int id);
        List<CarritoViewModel> GetAllCarritos();
        CarritoViewModel GetCarritoByUsuarioId(string usuarioId, string estado = "Incompleto");
        CarritoViewModel UpdateCarrito(CarritoViewModel carrito);
        CarritoViewModel DeleteCarrito(int id);
        bool MergeCarritos(int usuarioCarritoId, int temporalCarritoId);
        List<CarritoViewModel> GetCompletedCarritos(string usuarioId);
        bool AddItemToCarrito(ItemCarritoViewModel itemCarrito);
        bool UpdateItemInCarrito(ItemCarritoViewModel itemCarrito);
        bool RemoveItemFromCarrito(int id);
    }
}
