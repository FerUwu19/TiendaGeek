using BackEnd.Model;
using BackEnd.Services.Implemetations;
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

        [HttpGet]
        public ActionResult<IEnumerable<ContactoModel>> Get()
        {
            try
            {
                var contactos = _contactoService.Get();
                return Ok(contactos);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los datos del servidor.");
            }
        }
    }//fn class
}//fn space
