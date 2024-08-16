using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoHelper ProductoHelper;
        private readonly ICategoriumHelper CategoriumHelper;

        public ProductoController(IProductoHelper productoHelper, ICategoriumHelper categoriumHelper)
        {
            this.ProductoHelper = productoHelper;
            this.CategoriumHelper = categoriumHelper;
        }

        public ActionResult Index(string sortOrder, int? categoria)
        {
            List<ProductoViewModel> listaProductos;

            if (categoria.HasValue && categoria.Value > 0)
            {
                // Llamar al backend para obtener productos filtrados por categoría
                listaProductos = ProductoHelper.GetProductosByCategory(categoria.Value);
                ViewBag.CurrentCategoria = categoria.Value; // Guardar la categoría seleccionada
            }
            else
            {
                listaProductos = ProductoHelper.GetProductos();
                ViewBag.CurrentCategoria = null; // No hay categoría seleccionada
            }

            // Ordenar por precio
            switch (sortOrder)
            {
                case "price_asc":
                    listaProductos = listaProductos.OrderBy(p => p.Precio).ToList();
                    break;
                case "price_desc":
                    listaProductos = listaProductos.OrderByDescending(p => p.Precio).ToList();
                    break;
                default:
                    listaProductos = listaProductos.OrderBy(p => p.Nombre).ToList();
                    break;
            }

            ViewBag.CurrentSortOrder = sortOrder;

            // Cargar la lista de categorías disponibles para el dropdown en la vista
            ViewBag.CategoriasDisponibles = CategoriumHelper.GetCategorias();

            return View(listaProductos);
        }


        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            ProductoViewModel producto = new ProductoViewModel();
            producto.Categorias = CategoriumHelper.GetCategorias();
            return View(producto);
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductoHelper.Add(producto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al crear el producto: {ex.Message}");
                }
            }
            producto.Categorias = CategoriumHelper.GetCategorias();
            return View(producto);
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            producto.Categorias = CategoriumHelper.GetCategorias();
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductoHelper.Update(producto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al editar el producto: {ex.Message}");
                }
            }
            producto.Categorias = CategoriumHelper.GetCategorias();
            return View(producto);
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductoViewModel producto)
        {
            try
            {
                ProductoHelper.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar el producto: {ex.Message}");
            }
            return View(producto);
        }
    }
}
