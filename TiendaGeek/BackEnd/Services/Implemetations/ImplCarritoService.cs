using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Security.Cryptography;

namespace BackEnd.Services.Implemetations
{
    public class ImplCarritoService : ICarritoService
    {
        public ICarritoDAL carrito;
        public ImplCarritoService(ICarritoDAL _carrito)
        {
            this.carrito = _carrito;
        }

        public bool Add(CarritoModel carrito)
        {
            return this.carrito.Add(Convertir(carrito));
        }

        public CarritoModel Get(int _id)
        {
            return Convertir(this.carrito.Get(_id));
        }

        public IEnumerable<CarritoModel> GetAll()
        {
            var list = this.carrito.GetAll();
            var carrito = new List<CarritoModel>();
            foreach (var item in list)
            {
                carrito.Add(Convertir(item));
            }
            return carrito;
        }

        private Carrito Convertir(CarritoModel _carrito)
        {
            Carrito carrito = new Carrito()
            {
                CodigoCarrito = _carrito.CodigoCarrito,
                CodigoProducto = _carrito.CodigoProducto,
                CodigoUsuario = _carrito.CodigoUsuario,
                TotalCompra = _carrito.TotalCompra
            };
            return carrito;
        }

        private CarritoModel Convertir(Carrito _carrito)
        {
            CarritoModel carrito = new CarritoModel()
            {
                CodigoCarrito = _carrito.CodigoCarrito,
                CodigoProducto = _carrito.CodigoProducto,
                CodigoUsuario = _carrito.CodigoUsuario,
                TotalCompra = _carrito.TotalCompra
            };
            return carrito;

        }
    }
}
