using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialPedidoController : ControllerBase
    {
        private IHistorialPedidoServices services;
        public HistorialPedidoController(IHistorialPedidoServices _serv)
        {
            this.services = _serv;
        }
        // GET: api/<HistorialPedidoController>
        [HttpGet]
        public IEnumerable<HistorialPedidoModel> Get()
        {
            return services.GetAll();
        }

        // GET api/<HistorialPedidoController>/5
        [HttpGet("{id}")]
        public HistorialPedidoModel Get(int id)
        {
            return services.Get(id);
        }

        // POST api/<HistorialPedidoController>
        [HttpPost]
        public HistorialPedidoModel Post([FromBody] HistorialPedidoModel HistorialPedido)
        {
            services.Add(HistorialPedido);
            return HistorialPedido;
        }

        // PUT api/<HistorialPedidoController>/5
        [HttpPut]
        public HistorialPedidoModel Put([FromBody] HistorialPedidoModel HistorialPedido)
        {
            services.Update(HistorialPedido);
            return HistorialPedido;
        }

        // DELETE api/<HistorialPedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            HistorialPedidoModel historialPedido = new HistorialPedidoModel { id = id };
            services.Remove(historialPedido);
        }
    }
}