using FrontEnd.ApiModel;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class ProductoHelper : IProductoHelper
    {
        IServiceRepository ServiceRepository;

        public ProductoHelper (IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }

        private Producto Convertir(ProductoViewModel producto)
        {
            Producto entity = new Producto
            {
                CodigoProducto = producto.CodigoProducto,
                CodigoCategoria = producto.CodigoCategoria,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Unidades = producto.Unidades,
                Estado = producto.Estado

            };
            return entity;
        }


        private ProductoViewModel Convertir(Producto producto)
        {
            ProductoViewModel entity = new ProductoViewModel
            {
                CodigoProducto = producto.CodigoProducto,
                CodigoCategoria = producto.CodigoCategoria,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Unidades = producto.Unidades,
                Estado = producto.Estado

            };
            return entity;
        }

        public ProductoViewModel Add(ProductoViewModel producto)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/Producto", Convertir(producto));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return producto;
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
            List<ProductoViewModel> Productos = new List<ProductoViewModel>();

            foreach (var item in resultado)
            {
                Productos.Add(Convertir(item));
            }

            return Productos;
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
    }
}
