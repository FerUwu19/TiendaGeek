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
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/Producto
        [HttpGet]
        public ActionResult<IEnumerable<ProductoModel>> Get()
        {
            try
            {
                var productos = _productoService.Get();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los datos del servidor.");
            }
        }

        // GET api/Producto/5
        [HttpGet("{id}")]
        public ActionResult<ProductoModel> Get(int id)
        {
            try
            {
                var producto = _productoService.Get(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los datos del servidor.");
            }
        }

        // POST api/Producto
        [HttpPost]
        public ActionResult<ProductoModel> Post([FromBody] ProductoModel producto)
        {
            try
            {
                _productoService.Add(producto);
                return CreatedAtAction(nameof(Get), new { id = producto.CodigoProducto }, producto);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear un nuevo registro.");
            }
        }

        // PUT api/Producto/5
        [HttpPut]
        public ActionResult<ProductoModel> Put([FromBody] ProductoModel producto)
        {
            try
            {
                var existingProduct = _productoService.Get(producto.CodigoProducto);
                if (existingProduct == null)
                {
                    return NotFound();
                }
                _productoService.Update(producto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el registro.");
            }
        }

        // DELETE api/Producto/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var producto = _productoService.Get(id);
                if (producto == null)
                {
                    return NotFound();
                }
                _productoService.Remove(producto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el registro.");
            }
        }

        // GET api/Producto/ByCategory/5
        [HttpGet("ByCategory/{categoryId}")]
        public ActionResult<IEnumerable<ProductoModel>> GetByCategory(int categoryId)
        {
            try
            {
                var productos = _productoService.GetByCategory(categoryId);
                if (!productos.Any())
                {
                    return NotFound("No se encontraron productos para la categoría especificada.");
                }
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los datos del servidor.");
            }
        }
    }
}
