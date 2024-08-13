using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.Services.Implemetations;
using Entities.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private ICarritoService service;
        public CarritoController(ICarritoService _service)
        {
            this.service = service;
        }

        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<CarritoModel> Get()
        {
            return service.GetAll();
        }

        // GET api/<CarritoController>/5
        [HttpGet("{id}")]
        public CarritoModel Get(int id)
        {
            return service.Get(id);
        }

        // POST api/<CarritoController>
        [HttpPost]
        public CarritoModel Post([FromBody] CarritoModel carrito)
        {
            service.Add(carrito);
            return carrito;
        }

        // PUT api/<CarritoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
