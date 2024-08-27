using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontEnd.Controllers
{
    public class ItemCarritoController : Controller
    {
        private readonly IItemCarritoHelper itemCarritoHelper;

        public ItemCarritoController(IItemCarritoHelper itemCarritoHelper)
        {
            this.itemCarritoHelper = itemCarritoHelper;
        }

        // GET: ItemCarrito
        public ActionResult Index(int carritoId)
        {
            List<ItemCarritoViewModel> items = itemCarritoHelper.GetItemsByCarritoId(carritoId);
            return View(items);
        }

        // GET: ItemCarrito/Details/5
        public ActionResult Details(int id)
        {
            ItemCarritoViewModel itemCarrito = itemCarritoHelper.GetItemById(id);
            return View(itemCarrito);
        }

        // POST: ItemCarrito/Create
        [HttpPost]
        public ActionResult Create(ItemCarritoViewModel itemCarrito)
        {
            try
            {
                bool success = itemCarritoHelper.AddItemToCarrito(itemCarrito);
                if (success)
                {
                    return RedirectToAction("Index", "Carrito", new { carritoId = itemCarrito.CarritoId });
                }
                else
                {
                    TempData["Error"] = "Error al agregar el ítem al carrito.";
                    return RedirectToAction("Index", "Carrito");
                }
            }
            catch
            {
                TempData["Error"] = "Ocurrió un error al agregar el ítem al carrito.";
                return RedirectToAction("Index", "Carrito");
            }
        }


        // GET: ItemCarrito/Edit/5
        public ActionResult Edit(int id)
        {
            ItemCarritoViewModel itemCarrito = itemCarritoHelper.GetItemById(id);
            return View(itemCarrito);
        }

        // POST: ItemCarrito/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemCarritoViewModel itemCarrito)
        {
            try
            {
                bool success = itemCarritoHelper.UpdateItemInCarrito(itemCarrito);
                if (success)
                {
                    return RedirectToAction("Index", "Carrito", new { carritoId = itemCarrito.CarritoId });
                }
                else
                {
                    TempData["Error"] = "Error al actualizar el ítem en el carrito.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemCarrito/Delete/5
        public ActionResult Delete(int id)
        {
            ItemCarritoViewModel itemCarrito = itemCarritoHelper.GetItemById(id);
            return View(itemCarrito);
        }

        // POST: ItemCarrito/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ItemCarritoViewModel itemCarrito)
        {
            try
            {
                bool success = itemCarritoHelper.RemoveItemFromCarrito(itemCarrito.Id);
                if (success)
                {
                    return RedirectToAction("Index", "Carrito", new { carritoId = itemCarrito.CarritoId });
                }
                else
                {
                    TempData["Error"] = "Error al eliminar el ítem del carrito.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
