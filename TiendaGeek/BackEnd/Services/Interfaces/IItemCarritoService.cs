using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IItemCarritoService
    {
        bool AddItemToCarrito(ItemCarrito itemCarrito);
        bool UpdateItemInCarrito(ItemCarrito itemCarrito);
        bool RemoveItemFromCarrito(int id);
        ItemCarrito GetItemById(int id);
        IEnumerable<ItemCarrito> GetItemsByCarritoId(int carritoId);
    }
}
