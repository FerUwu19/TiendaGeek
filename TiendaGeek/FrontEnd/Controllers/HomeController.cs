using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductoHelper ProductoHelper;
        private readonly IImagenProductoHelper ImagenProductoHelper;

        public HomeController(IProductoHelper productoHelper, ILogger<HomeController> logger, IImagenProductoHelper imagenProductoHelper)
        {
            this.ProductoHelper = productoHelper;
            _logger = logger;
            this.ImagenProductoHelper = imagenProductoHelper;
        }

        public IActionResult Index()
        {

            List<ProductoViewModel> listaProductos;

            listaProductos = ProductoHelper.GetProductos();

            // Obtener la primera imagen de cada producto o una imagen por defecto
            foreach (var producto in listaProductos)
            {
                var imagenes = ImagenProductoHelper.GetImagenesPorProducto(producto.CodigoProducto);
                if (imagenes != null && imagenes.Any())
                {
                    producto.ImagenPrincipal = imagenes.First().RutaImagen; // Asignar la primera imagen como principal
                }
                else
                {
                    // Asignar una imagen por defecto si no hay imágenes
                    producto.ImagenPrincipal = "~/images/imgNotFound.png";
                }
            }
            return View(listaProductos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
