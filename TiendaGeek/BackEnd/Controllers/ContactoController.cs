using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : Controller
    {
        private IContactoService _contactoService;


        public ContactoController (IContactoService contactoService)
        {
            _contactoService = contactoService;
        }


        [HttpPost]
        public ContactoModel Post([FromBody] ContactoModel contacto)
        {
            _contactoService.Add(contacto);
            return contacto;
        }
    }//fn class
}//fn space
