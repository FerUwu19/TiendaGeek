using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IContactoHelper
    {
        ContactoViewModel Add(ContactoViewModel contacto);
        List<ContactoViewModel> GetContactos();
    }//fn interface
}//fin space
