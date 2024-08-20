using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Implemetations
{
    public class ContactoHelper : IContactoHelper
    {
        IServiceRepository _serviceRepository;

        public ContactoHelper (IServiceRepository serviceRepository) //constructor
        {
            _serviceRepository = serviceRepository;
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
    }//fn class
}//fn space
