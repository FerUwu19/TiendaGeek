using Entities.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IItemCarritoDAL
    {
        bool Add(ItemCarrito item);  // Añadir un nuevo ItemCarrito
        bool Update(ItemCarrito item);  // Actualizar un ItemCarrito existente
        bool Delete(int id);  // Eliminar un ItemCarrito por su ID
        ItemCarrito Get(int id);  // Obtener un ItemCarrito por su ID
        IEnumerable<ItemCarrito> GetAll();  // Obtener todos los ItemCarrito
        IEnumerable<ItemCarrito> GetItemsByCarritoId(int carritoId);  // Obtener todos los ItemCarrito asociados a un Carrito específico
    }
}
