using BackEnd.Model;

namespace BackEnd.Services.Interfaces
{
    public interface IContactoService
    {
        public bool Add(ContactoModel contacto);

        IEnumerable<ContactoModel> Get();
    }//fn class
}//fn space
