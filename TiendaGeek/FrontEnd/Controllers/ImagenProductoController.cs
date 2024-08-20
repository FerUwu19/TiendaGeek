using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ImagenProductoController : Controller
    {

        private readonly IImagenProductoHelper ImagenProductoHelper;

        public ImagenProductoController(IImagenProductoHelper ImagenProductoHelper)
        {
            this.ImagenProductoHelper = ImagenProductoHelper;
        }

        // GET: ImagenProducto
        public ActionResult Index()
        {
            return View(ImagenProductoHelper.GetImagenProductos());
        }


        // GET: ImagenProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImagenProducto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImagenProductoViewModel ImagenProducto)
        {
            try
            {
                _ = ImagenProductoHelper.Add(ImagenProducto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImagenProducto/Edit/5
        public ActionResult Edit(int id)
        {
            ImagenProductoViewModel ImagenProducto = ImagenProductoHelper.GetImagenProducto(id);
            return View(ImagenProducto);
        }

        // POST: ImagenProducto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImagenProductoViewModel ImagenProducto)
        {
            try
            {
                _ = ImagenProductoHelper.Update(ImagenProducto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImagenProducto/Delete/5
        public ActionResult Delete(int id)
        {
            ImagenProductoViewModel ImagenProducto = ImagenProductoHelper.GetImagenProducto(id);
            return View(ImagenProducto);
        }

        // POST: ImagenProducto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ImagenProductoViewModel ImagenProducto)
        {
            try
            {
                _ = ImagenProductoHelper.Remove(ImagenProducto.CodigoImagen);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
