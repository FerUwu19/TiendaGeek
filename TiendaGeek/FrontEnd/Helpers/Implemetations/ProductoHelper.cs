using FrontEnd.ApiModel;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Helpers.Implemetations
{
    public class ProductoHelper : IProductoHelper
    {
        IServiceRepository ServiceRepository;

        public ProductoHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }

        private Producto Convertir(ProductoViewModel producto)
        {
            return new Producto
            {
                CodigoProducto = producto.CodigoProducto,
                CodigoCategoria = producto.CodigoCategoria,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Unidades = producto.Unidades,
                Estado = producto.Estado
            };
        }

        private ProductoViewModel Convertir(Producto producto)
        {
            return new ProductoViewModel
            {
                CodigoProducto = producto.CodigoProducto,
                CodigoCategoria = producto.CodigoCategoria,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Unidades = producto.Unidades,
                Estado = producto.Estado
            };
        }

        public ProductoViewModel Add(ProductoViewModel producto)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/Producto", Convertir(producto));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ProductoViewModel { };
        }

        public ProductoViewModel GetProducto(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Producto/" + id.ToString());
            Producto resultado = new Producto();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Producto>(content);
            }

            return Convertir(resultado);
        }

        public List<ProductoViewModel> GetProductos()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Producto");
            List<Producto> resultado = new List<Producto>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Producto>>(content);
            }

            List<ProductoViewModel> productos = new List<ProductoViewModel>();

            foreach (var item in resultado)
            {
                productos.Add(Convertir(item));
            }

            return productos;
        }

        public ProductoViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Producto/" + id.ToString());
            Producto resultado = new Producto();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public ProductoViewModel Update(ProductoViewModel producto)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/Producto", Convertir(producto));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return producto;
        }

        //metodo para filtrar productos por categoria 
        public List<ProductoViewModel> GetProductosByCategory(int categoryId)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/Producto/ByCategory/{categoryId}");
            List<Producto> resultado = new List<Producto>();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Producto>>(content);
            }

            List<ProductoViewModel> productos = new List<ProductoViewModel>();

            foreach (var item in resultado)
            {
                productos.Add(Convertir(item));
            }

            return productos; 
        }

    }
}
