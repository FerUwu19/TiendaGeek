using FrontEnd.ApiModel;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;

namespace FrontEnd.Helpers.Implemetations
{
    public class ContactoHelper : IContactoHelper
    {
        IServiceRepository _serviceRepository;

        public ContactoHelper (IServiceRepository serviceRepository) //constructor
        {
            _serviceRepository = serviceRepository;
        }

        private Contacto Convertir(ContactoViewModel contacto)
        {
            Contacto entity = new Contacto
            {
                Id = contacto.Id,
                IdUser = contacto.IdUser,
                Name = contacto.Name,
                Email = contacto.Email,
                Message = contacto.Message,
            };
            return entity;
        }


        private ContactoViewModel Convertir(Contacto contacto)
        {
            ContactoViewModel entity = new ContactoViewModel
            {
                Id = contacto.Id,
                IdUser = contacto.IdUser,
                Name = contacto.Name,
                Email = contacto.Email,
                Message = contacto.Message,
            };
            return entity;
        }
        public ContactoViewModel Add(ContactoViewModel contacto)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Contacto",contacto);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }

            return contacto;
        }

        public List<ContactoViewModel> GetContactos()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Contacto");
            List<Contacto> resultado = new List<Contacto>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Contacto>>(content);
            }

            List<ContactoViewModel> Contactos = new List<ContactoViewModel>();

            foreach (var item in resultado)
            {
                Contactos.Add(Convertir(item));
            }

            return Contactos;
        }
    }//fn class
}//fn space
