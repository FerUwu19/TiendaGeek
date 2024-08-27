using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;
        private readonly IItemCarritoService _itemCarritoService;

        public CarritoController(ICarritoService carritoService, IItemCarritoService itemCarritoService)
        {
            _carritoService = carritoService;
            _itemCarritoService = itemCarritoService;
        }

        // POST api/carrito
        [HttpPost]
        public IActionResult CreateCarrito([FromBody] Carrito carrito)
        {
            if (_carritoService.CreateCarrito(carrito))
            {
                return Ok();
            }
            return BadRequest("Failed to create carrito.");
        }

        // GET api/carrito/{id}
        [HttpGet("{id}")]
        public IActionResult GetCarritoById(int id)
        {
            var carrito = _carritoService.GetCarritoById(id);
            if (carrito != null)
            {
                return Ok(carrito);
            }
            return NotFound();
        }

        // GET api/carrito
        [HttpGet]
        public IActionResult GetAllCarritos()
        {
            var carritos = _carritoService.GetAllCarritos();
            return Ok(carritos);
        }

        // GET api/carrito/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public IActionResult GetCarritoByUsuarioId(string usuarioId, string estado = "Incompleto")
        {
            var carrito = _carritoService.GetCarritoByUsuarioId(usuarioId, estado);
            if (carrito != null)
            {
                return Ok(carrito);
            }
            return NotFound();
        }

        // PUT api/carrito
        [HttpPut]
        public IActionResult UpdateCarrito([FromBody] Carrito carrito)
        {
            if (_carritoService.UpdateCarrito(carrito))
            {
                return Ok();
            }
            return BadRequest("Failed to update carrito.");
        }

        // DELETE api/carrito/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCarrito(int id)
        {
            if (_carritoService.DeleteCarrito(id))
            {
                return Ok();
            }
            return BadRequest("Failed to delete carrito.");
        }

        // POST api/carrito/merge
        [HttpPost("merge")]
        public IActionResult MergeCarritos(int usuarioCarritoId, int temporalCarritoId)
        {
            if (_carritoService.MergeCarritos(usuarioCarritoId, temporalCarritoId))
            {
                return Ok();
            }
            return BadRequest("Failed to merge carritos.");
        }

        // GET api/carrito/completed/usuario/{usuarioId}
        [HttpGet("completed/usuario/{usuarioId}")]
        public IActionResult GetCompletedCarritos(string usuarioId)
        {
            var carritos = _carritoService.GetCompletedCarritos(usuarioId);
            return Ok(carritos);
        }

        // POST api/carrito/item
        [HttpPost("item")]
        public IActionResult AddItemToCarrito([FromBody] ItemCarrito itemCarrito)
        {
            if (_carritoService.AddItemToCarrito(itemCarrito))
            {
                return Ok();
            }
            return BadRequest("Failed to add item to carrito.");
        }

        // PUT api/carrito/item
        [HttpPut("item")]
        public IActionResult UpdateItemInCarrito([FromBody] ItemCarrito itemCarrito)
        {
            if (_carritoService.UpdateItemInCarrito(itemCarrito))
            {
                return Ok();
            }
            return BadRequest("Failed to update item in carrito.");
        }

        // DELETE api/carrito/item/{id}
        [HttpDelete("item/{id}")]
        public IActionResult RemoveItemFromCarrito(int id)
        {
            if (_carritoService.RemoveItemFromCarrito(id))
            {
                return Ok();
            }
            return BadRequest("Failed to remove item from carrito.");
        }
    }
}
