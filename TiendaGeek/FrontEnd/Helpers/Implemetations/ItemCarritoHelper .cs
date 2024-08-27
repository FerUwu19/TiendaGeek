using FrontEnd.ApiModel;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace FrontEnd.Helpers.Implemetations
{
    public class ItemCarritoHelper : IItemCarritoHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public ItemCarritoHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private ItemCarrito Convertir(ItemCarritoViewModel itemCarrito)
        {
            return new ItemCarrito
            {
                Id = itemCarrito.Id,
                Cantidad = itemCarrito.Cantidad,
                ProductoId = itemCarrito.ProductoId,
                CarritoId = itemCarrito.CarritoId
            };
        }

        private ItemCarritoViewModel Convertir(ItemCarrito itemCarrito)
        {
            return new ItemCarritoViewModel
            {
                Id = itemCarrito.Id,
                Cantidad = itemCarrito.Cantidad,
                ProductoId = itemCarrito.ProductoId,
                CarritoId = itemCarrito.CarritoId
            };
        }
        public bool AddItemToCarrito(ItemCarritoViewModel itemCarrito)
        {
            // Verifica si el carrito ya existe
            var carrito = GetCarrito(itemCarrito.CarritoId);

            // Calcula el monto total para el ítem usando el precio recibido
            decimal montoTotal = itemCarrito.Cantidad * itemCarrito.Precio;

            if (carrito == null)
            {
                // Crea un nuevo carrito si no existe
                carrito = CreateCarrito(montoTotal);
                itemCarrito.CarritoId = carrito.Id;
            }
            else
            {
                // Actualiza el monto total del carrito existente
                carrito.Monto += (double)montoTotal;
                // Envía una solicitud para actualizar el carrito con el nuevo monto
                _serviceRepository.PutResponse("api/Carrito", carrito);
            }

            // Agrega el ítem al carrito
            HttpResponseMessage response = _serviceRepository.PostResponse("api/ItemCarrito", itemCarrito);

            return response.IsSuccessStatusCode;
        }


        private CarritoViewModel GetCarrito(int carritoId)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse($"api/Carrito/{carritoId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<CarritoViewModel>(content);
            }
            return null;
        }

        private CarritoViewModel CreateCarrito(decimal monto)
        {
            var carrito = new CarritoViewModel
            {
                Monto = (double)monto
            };
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Carrito", carrito);

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<CarritoViewModel>(content);
            }

            return null;
        }


        public bool UpdateItemInCarrito(ItemCarritoViewModel itemCarrito)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("api/ItemCarrito", Convertir(itemCarrito));
            return response.IsSuccessStatusCode;
        }

        public bool RemoveItemFromCarrito(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/ItemCarrito/" + id.ToString());
            return responseMessage.IsSuccessStatusCode;
        }

        public ItemCarritoViewModel GetItemById(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/ItemCarrito/" + id.ToString());
            ItemCarrito resultado = new ItemCarrito();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<ItemCarrito>(content);
            }

            return Convertir(resultado);
        }

        public List<ItemCarritoViewModel> GetItemsByCarritoId(int carritoId)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse($"api/ItemCarrito/carrito/{carritoId}");
            List<ItemCarrito> resultado = new List<ItemCarrito>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<ItemCarrito>>(content);
            }

            List<ItemCarritoViewModel> items = new List<ItemCarritoViewModel>();

            foreach (var item in resultado)
            {
                items.Add(Convertir(item));
            }

            return items;
        }
    }
}
