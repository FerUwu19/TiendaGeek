using FrontEnd.ApiModel;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Helpers.Implemetations
{
    public class ImagenProductoHelper : IImagenProductoHelper
    {
        IServiceRepository ServiceRepository;

        public ImagenProductoHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }

        private ImagenProducto Convertir(ImagenProductoViewModel imagen)
        {
            return new ImagenProducto
            {
                CodigoImagen = imagen.CodigoImagen,
                CodigoProducto = imagen.CodigoProducto,
                RutaImagen = imagen.RutaImagen
            };
        }

        private ImagenProductoViewModel Convertir(ImagenProducto imagen)
        {
            return new ImagenProductoViewModel
            {
                CodigoImagen = imagen.CodigoImagen,
                CodigoProducto = imagen.CodigoProducto,
                RutaImagen = imagen.RutaImagen
            };
        }

        public ImagenProductoViewModel Add(ImagenProductoViewModel ImagenProducto)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/ImagenProducto", Convertir(ImagenProducto));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ImagenProductoViewModel { };
        }

        public ImagenProductoViewModel GetImagenProducto(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/ImagenProducto/" + id.ToString());
            ImagenProducto resultado = new ImagenProducto();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<ImagenProducto>(content);
            }

            return Convertir(resultado);
        }

        public List<ImagenProductoViewModel> GetImagenProductos()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/ImagenProducto");
            List<ImagenProducto> resultado = new List<ImagenProducto>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<ImagenProducto>>(content);
            }

            List<ImagenProductoViewModel> ImagenProductos = new List<ImagenProductoViewModel>();

            foreach (var item in resultado)
            {
                ImagenProductos.Add(Convertir(item));
            }

            return ImagenProductos;
        }

        public ImagenProductoViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/ImagenProducto/" + id.ToString());
            ImagenProducto resultado = new ImagenProducto();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return Convertir(resultado);
        }

        public ImagenProductoViewModel Update(ImagenProductoViewModel ImagenProducto)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/ImagenProducto", Convertir(ImagenProducto));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return ImagenProducto;
        }

    }
}
