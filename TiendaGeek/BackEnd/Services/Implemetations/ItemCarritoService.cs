using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;

public class ItemCarritoService : IItemCarritoService
{
    private readonly IItemCarritoDAL _itemCarritoDAL;

    public ItemCarritoService(IItemCarritoDAL itemCarritoDAL)
    {
        _itemCarritoDAL = itemCarritoDAL;
    }

    public bool AddItemToCarrito(ItemCarrito itemCarrito)
    {
        return _itemCarritoDAL.Add(itemCarrito);
    }

    public bool UpdateItemInCarrito(ItemCarrito itemCarrito)
    {
        return _itemCarritoDAL.Update(itemCarrito);
    }

    public bool RemoveItemFromCarrito(int id)
    {
        return _itemCarritoDAL.Delete(id);
    }

    public ItemCarrito GetItemById(int id)
    {
        return _itemCarritoDAL.Get(id);
    }

    public IEnumerable<ItemCarrito> GetItemsByCarritoId(int carritoId)
    {
        return _itemCarritoDAL.GetItemsByCarritoId(carritoId);
    }
}
