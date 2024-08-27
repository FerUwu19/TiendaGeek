using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontEnd.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ICarritoHelper carritoHelper;

        public CarritoController(ICarritoHelper carritoHelper)
        {
            this.carritoHelper = carritoHelper;
        }

        // GET: Carrito
        public ActionResult Index()
        {
            string usuarioId = User.Identity.Name; // Suponiendo que el usuario está autenticado
            var carrito = carritoHelper.GetCarritoByUsuarioId(usuarioId);
            return View(carrito);
        }

        // GET: Carrito/Details/5
        public ActionResult Details(int id)
        {
            var carrito = carritoHelper.GetCarritoById(id);
            return View(carrito);
        }

        // GET: Carrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrito/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarritoViewModel carrito)
        {
            try
            {
                carritoHelper.CreateCarrito(carrito);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int id)
        {
            var carrito = carritoHelper.GetCarritoById(id);
            return View(carrito);
        }

        // POST: Carrito/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarritoViewModel carrito)
        {
            try
            {
                carritoHelper.UpdateCarrito(carrito);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int id)
        {
            var carrito = carritoHelper.GetCarritoById(id);
            return View(carrito);
        }

        // POST: Carrito/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarritoViewModel carrito)
        {
            try
            {
                carritoHelper.DeleteCarrito(carrito.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Completed
        public ActionResult Completed()
        {
            string usuarioId = User.Identity.Name; // Suponiendo que el usuario está autenticado
            var completedCarritos = carritoHelper.GetCompletedCarritos(usuarioId);
            return View(completedCarritos);
        }
    }
}
