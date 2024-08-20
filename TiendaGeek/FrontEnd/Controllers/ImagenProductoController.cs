using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ImagenProductoController : Controller
    {

        private readonly IImagenProductoHelper ImagenProductoHelper;
        private readonly IProductoHelper ProductoHelper;

        public ImagenProductoController(IImagenProductoHelper ImagenProductoHelper, IProductoHelper productoHelper)
        {
            this.ImagenProductoHelper = ImagenProductoHelper;
            this.ProductoHelper = productoHelper;
        }

        // GET: ImagenProducto
        public ActionResult Index()
        {
            var imagenesProductos = ImagenProductoHelper.GetImagenProductos();

            foreach (var imagen in imagenesProductos)
            {
                var producto = ProductoHelper.GetProducto(imagen.CodigoProducto.Value);
                imagen.NombreProducto = producto.Nombre; // Asigna el nombre del producto
            }

            return View(imagenesProductos);
        }

        // GET: ImagenProducto/Create
        public ActionResult Create()
        {

            ImagenProductoViewModel imagen = new ImagenProductoViewModel();
            imagen.Productos = ProductoHelper.GetProductos();
            return View(imagen);
        }

        // POST: ImagenProducto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImagenProductoViewModel ImagenProducto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ = ImagenProductoHelper.Add(ImagenProducto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al editar el producto: {ex.Message}");
                }
            }
            ImagenProducto.Productos = ProductoHelper.GetProductos();
            return View(ImagenProducto);
        }

        // GET: ImagenProducto/Edit/5
        public ActionResult Edit(int id)
        {
            ImagenProductoViewModel ImagenProducto = ImagenProductoHelper.GetImagenProducto(id);
            ImagenProducto.Productos = ProductoHelper.GetProductos();
            return View(ImagenProducto);
        }

        // POST: ImagenProducto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImagenProductoViewModel ImagenProducto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ = ImagenProductoHelper.Update(ImagenProducto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al editar el producto: {ex.Message}");
                }
            }
            ImagenProducto.Productos = ProductoHelper.GetProductos();
            return View(ImagenProducto);
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
