using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private IProductoService _productoService;


        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<ProductoModel> Get()
        {
            return _productoService.Get();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ProductoModel Get(int id)
        {
            return _productoService.Get(id);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ProductoModel Post([FromBody] ProductoModel producto)
        {
            _productoService.Add(producto);
            return producto;

        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public ProductoModel Put([FromBody] ProductoModel producto)
        {
            _productoService.Update(producto);
            return producto;
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductoModel producto = new ProductoModel { CodigoProducto = id };
            _productoService.Remove(producto);

        }

        //para el filtro de categoria
        [HttpGet("ByCategory/{categoryId}")]
        public IEnumerable<ProductoModel> GetByCategory(int categoryId)
        {
            return _productoService.GetByCategory(categoryId);
        }
        
        // Para el filtro de categoría con método POST
        [HttpPost("ByCategory")]
        public IEnumerable<ProductoModel> GetByCategory([FromBody] List<int> categoryIds)
        {
            return _productoService.GetByCategories(categoryIds);
        }


    }
}
