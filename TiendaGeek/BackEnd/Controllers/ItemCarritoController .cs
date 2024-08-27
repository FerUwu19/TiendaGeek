using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCarritoController : ControllerBase
    {
        private readonly IItemCarritoService _itemCarritoService;

        public ItemCarritoController(IItemCarritoService itemCarritoService)
        {
            _itemCarritoService = itemCarritoService;
        }

        // POST api/itemcarrito
        [HttpPost]
        public IActionResult AddItemToCarrito([FromBody] ItemCarrito itemCarrito)
        {
            if (_itemCarritoService.AddItemToCarrito(itemCarrito))
            {
                return Ok();
            }
            return BadRequest("Failed to add item to carrito.");
        }

        // PUT api/itemcarrito
        [HttpPut]
        public IActionResult UpdateItemInCarrito([FromBody] ItemCarrito itemCarrito)
        {
            if (_itemCarritoService.UpdateItemInCarrito(itemCarrito))
            {
                return Ok();
            }
            return BadRequest("Failed to update item in carrito.");
        }

        // DELETE api/itemcarrito/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveItemFromCarrito(int id)
        {
            if (_itemCarritoService.RemoveItemFromCarrito(id))
            {
                return Ok();
            }
            return BadRequest("Failed to remove item from carrito.");
        }

        // GET api/itemcarrito/{id}
        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _itemCarritoService.GetItemById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // GET api/itemcarrito/carrito/{carritoId}
        [HttpGet("carrito/{carritoId}")]
        public IActionResult GetItemsByCarritoId(int carritoId)
        {
            var items = _itemCarritoService.GetItemsByCarritoId(carritoId);
            return Ok(items);
        }
    }
}
