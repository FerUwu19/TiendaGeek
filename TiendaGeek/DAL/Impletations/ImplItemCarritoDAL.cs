using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Impletations
{
    public class ImplItemCarritoDAL : IItemCarritoDAL
    {
        private readonly TiendaGeekContext context;

        public ImplItemCarritoDAL(TiendaGeekContext _context)
        {
            this.context = _context;
        }

        public bool Add(ItemCarrito item)
        {
            try
            {
                context.ItemCarritos.Add(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ItemCarrito item)
        {
            try
            {
                context.ItemCarritos.Update(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var item = context.ItemCarritos.Find(id);
                if (item != null)
                {
                    context.ItemCarritos.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public ItemCarrito Get(int id)
        {
            return context.ItemCarritos.Find(id) ?? new ItemCarrito();
        }

        public IEnumerable<ItemCarrito> GetAll()
        {
            return context.ItemCarritos.ToList();
        }

        public IEnumerable<ItemCarrito> GetItemsByCarritoId(int carritoId)
        {
            return context.ItemCarritos.Where(item => item.Id == carritoId).ToList();
        }
    }
}
