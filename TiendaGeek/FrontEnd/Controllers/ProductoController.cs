using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {

        IProductoHelper ProductoHelper;
        ICategoriumHelper CategoriumHelper;

        public ProductoController(IProductoHelper productoHelper, ICategoriumHelper categoriumHelper)
        {
            this.ProductoHelper = productoHelper;
            this.CategoriumHelper = categoriumHelper;

        }

        public ActionResult Index(string sortOrder, List<int> categorias)
        {
            List<ProductoViewModel> listaProductos;

            if (categorias != null && categorias.Any())
            {
                // Llamar al backend para obtener productos filtrados por categoría
                listaProductos = ProductoHelper.GetProductosByCategories(categorias);
            }
            else
            {
                listaProductos = ProductoHelper.GetProductos();
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

            var todasCategorias = CategoriumHelper.GetCategorias();
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentCategories = categorias;
            ViewBag.CategoriasDisponibles = todasCategorias;

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
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto)
        {
            try
            {
                _ = ProductoHelper.Add(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            producto.Categorias = CategoriumHelper.GetCategorias();
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto)
        {
            try
            {
                _ = ProductoHelper.Update(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoViewModel producto = ProductoHelper.GetProducto(id);
            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoViewModel producto)
        {
            try
            {
                _ = ProductoHelper.Remove(producto.CodigoProducto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
