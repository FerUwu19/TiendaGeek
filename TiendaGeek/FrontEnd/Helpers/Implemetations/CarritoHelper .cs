using FrontEnd.ApiModel;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace FrontEnd.Helpers.Implemetations
{
    public class CarritoHelper : ICarritoHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public CarritoHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private Carrito Convertir(CarritoViewModel carrito)
        {
            return new Carrito
            {
                Id = carrito.Id,
                Monto = carrito.Monto,
                UsuarioId = carrito.UsuarioId,
                CarritoTemporalId = carrito.CarritoTemporalId,
                Estado = carrito.Estado
            };
        }

        private CarritoViewModel Convertir(Carrito carrito)
        {
            return new CarritoViewModel
            {
                Id = carrito.Id,
                Monto = carrito.Monto,
                UsuarioId = carrito.UsuarioId,
                CarritoTemporalId = carrito.CarritoTemporalId,
                Estado = carrito.Estado
            };
        }

        public CarritoViewModel CreateCarrito(CarritoViewModel carrito)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Carrito", Convertir(carrito));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return carrito;
        }

        public CarritoViewModel GetCarritoById(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Carrito/" + id.ToString());
            Carrito resultado = new Carrito();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Carrito>(content);
            }

            return Convertir(resultado);
        }

        public List<CarritoViewModel> GetAllCarritos()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Carrito");
            List<Carrito> resultado = new List<Carrito>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Carrito>>(content);
            }

            List<CarritoViewModel> carritos = new List<CarritoViewModel>();

            foreach (var item in resultado)
            {
                carritos.Add(Convertir(item));
            }

            return carritos;
        }

        public CarritoViewModel GetCarritoByUsuarioId(string usuarioId, string estado = "Incompleto")
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse($"api/Carrito/usuario/{usuarioId}?estado={estado}");
            Carrito resultado = new Carrito();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Carrito>(content);
            }

            return Convertir(resultado);
        }

        public CarritoViewModel UpdateCarrito(CarritoViewModel carrito)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("api/Carrito", Convertir(carrito));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return carrito;
        }

        public CarritoViewModel DeleteCarrito(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Carrito/" + id.ToString());
            Carrito resultado = new Carrito();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public bool MergeCarritos(int usuarioCarritoId, int temporalCarritoId)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse($"api/Carrito/merge?usuarioCarritoId={usuarioCarritoId}&temporalCarritoId={temporalCarritoId}", null);
            return response.IsSuccessStatusCode;
        }

        public List<CarritoViewModel> GetCompletedCarritos(string usuarioId)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse($"api/Carrito/completed/usuario/{usuarioId}");
            List<Carrito> resultado = new List<Carrito>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Carrito>>(content);
            }

            List<CarritoViewModel> carritos = new List<CarritoViewModel>();

            foreach (var item in resultado)
            {
                carritos.Add(Convertir(item));
            }

            return carritos;
        }

        public bool AddItemToCarrito(ItemCarritoViewModel itemCarrito)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Carrito/item", itemCarrito);
            return response.IsSuccessStatusCode;
        }

        public bool UpdateItemInCarrito(ItemCarritoViewModel itemCarrito)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("api/Carrito/item", itemCarrito);
            return response.IsSuccessStatusCode;
        }

        public bool RemoveItemFromCarrito(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Carrito/item/" + id.ToString());
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
