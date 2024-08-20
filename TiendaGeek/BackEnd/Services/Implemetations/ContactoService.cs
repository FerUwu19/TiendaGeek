using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implemetations
{
    public class ContactoService : IContactoService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IContactoDAL ContactoDAL;

        public ContactoService(IUnidadDeTrabajo unidadDeTrabajo, IContactoDAL contactoDAL)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
            this.ContactoDAL = contactoDAL;
        }

        private Contacto Convertir(ContactoModel contacto)
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
        public bool Add(ContactoModel contacto)
        {
            _unidadDeTrabajo.ContactoDAL.Add(Convertir(contacto));
            return _unidadDeTrabajo.Complete();
        }
    }//fn class
}//fn space
