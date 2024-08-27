using FrontEnd.Models;
using System.Collections.Generic;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IItemCarritoHelper
    {
        bool AddItemToCarrito(ItemCarritoViewModel itemCarrito);
        bool UpdateItemInCarrito(ItemCarritoViewModel itemCarrito);
        bool RemoveItemFromCarrito(int id);
        ItemCarritoViewModel GetItemById(int id);
        List<ItemCarritoViewModel> GetItemsByCarritoId(int carritoId);
    }
}
