using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenProductoController : ControllerBase
    {
        private IImagenProductoServices services;
        public ImagenProductoController(IImagenProductoServices _img)
        {
            this.services = _img;
        }
        // GET: api/<ImagenProductoController>
        [HttpGet]
        public IEnumerable<ImagenProductoModel> Get()
        {
            return services.GetAll();
        }

        // GET api/<ImagenProductoController>/5
        [HttpGet("{id}")]
        public ImagenProductoModel Get(int id)
        {
            return services.Get(id);
        }

        // POST api/<ImagenProductoController>
        [HttpPost]
        public ImagenProductoModel Post([FromBody] ImagenProductoModel imagenProducto)
        {
            services.Add(imagenProducto);
            return imagenProducto;
        }

        // PUT api/<ImagenProductoController>/5
        [HttpPut]
        public ImagenProductoModel Put([FromBody] ImagenProductoModel imagenProducto)
        {
            services.Update(imagenProducto);
            return imagenProducto;
        }

        // DELETE api/<ImagenProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ImagenProductoModel imagenProducto = new ImagenProductoModel { CodigoImagen = id };
            services.Remove(imagenProducto);
        }
    }
}
