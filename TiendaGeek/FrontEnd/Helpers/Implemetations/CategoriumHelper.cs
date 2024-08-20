using FrontEnd.ApiModel;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace FrontEnd.Helpers.Implemetations
{
    public class CategoriumHelper : ICategoriumHelper
    {
         IServiceRepository _serviceRepository;

        public CategoriumHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private Categorium Convertir(CategoriumViewModel categorium)
        {
            Categorium entity = new Categorium
            {
                CodigoCategoria = categorium.CodigoCategoria,
                Nombre = categorium.Nombre,
                Descripcion = categorium.Descripcion
            };
            return entity;
        }

        private CategoriumViewModel Convertir(Categorium categorium)
        {
            CategoriumViewModel entity = new CategoriumViewModel
            {
                CodigoCategoria = categorium.CodigoCategoria,
                Nombre = categorium.Nombre,
                Descripcion = categorium.Descripcion
            };
            return entity;
        }

        public CategoriumViewModel Add(CategoriumViewModel categorium)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Categorium", Convertir(categorium));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                // Puedes realizar cualquier procesamiento adicional aquí
            }
            return categorium;
        }

        public CategoriumViewModel GetCategoria(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Categorium/" + id.ToString());
            Categorium resultado = new Categorium();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Categorium>(content);
            }

            return Convertir(resultado);
        }

        public List<CategoriumViewModel> GetCategorias()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Categorium");
            List<Categorium> resultado = new List<Categorium>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Categorium>>(content);
            }

            List<CategoriumViewModel> categoriums = new List<CategoriumViewModel>();

            foreach (var item in resultado)
            {
                categoriums.Add(Convertir(item));
            }

            return categoriums;
        }

        public CategoriumViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Categorium/" + id.ToString());
            Categorium resultado = new Categorium();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // Puedes realizar cualquier procesamiento adicional aquí
            }

            return Convertir(resultado);
        }

        public CategoriumViewModel Update(CategoriumViewModel categorium)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("api/Categorium", Convertir(categorium));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                // Puedes realizar cualquier procesamiento adicional aquí
            }
            return categorium;
        }
    }
}


