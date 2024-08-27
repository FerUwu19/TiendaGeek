using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implemetations
{
    public class ImplCarritoService : ICarritoService
    {
        private readonly ICarritoDAL _carritoDAL;
        private readonly IItemCarritoDAL _itemCarritoDAL;

        public ImplCarritoService(ICarritoDAL carritoDAL, IItemCarritoDAL itemCarritoDAL)
        {
            _carritoDAL = carritoDAL;
            _itemCarritoDAL = itemCarritoDAL;
        }

        public bool CreateCarrito(Carrito carrito)
        {
            return _carritoDAL.Add(carrito);
        }

        public Carrito GetCarritoById(int id)
        {
            return _carritoDAL.Get(id);
        }

        public IEnumerable<Carrito> GetAllCarritos()
        {
            return _carritoDAL.GetAll();
        }

        public Carrito GetCarritoByUsuarioId(string usuarioId, string estado = "Incompleto")
        {
            return _carritoDAL.GetCarritoByUsuarioId(usuarioId, estado);
        }

        public Carrito GetCarritoByTemporalId(string carritoTemporalId, string estado = "Incompleto")
        {
            return _carritoDAL.GetCarritoByTemporalId(carritoTemporalId, estado);
        }

        public bool UpdateCarrito(Carrito carrito)
        {
            return _carritoDAL.Update(carrito);
        }

        public bool DeleteCarrito(int id)
        {
            var carrito = _carritoDAL.Get(id);
            return carrito != null && _carritoDAL.Remove(carrito);
        }

        public bool MergeCarritos(int usuarioCarritoId, int temporalCarritoId)
        {
            var usuarioCarrito = _carritoDAL.Get(usuarioCarritoId);
            var temporalCarrito = _carritoDAL.Get(temporalCarritoId);

            if (usuarioCarrito == null || temporalCarrito == null) return false;

            return _carritoDAL.MergeCarritos(usuarioCarrito, temporalCarrito);
        }

        public IEnumerable<Carrito> GetCompletedCarritos(string usuarioId)
        {
            return _carritoDAL.GetCarritosCompletados(usuarioId);
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

        public IEnumerable<ItemCarrito> GetItemsByCarritoId(int carritoId)
        {
            return _itemCarritoDAL.GetItemsByCarritoId(carritoId);
        }
    }
}
