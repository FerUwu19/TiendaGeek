using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class HistorialPedidosController : Controller
    {

        IHistorialPedidoHelper historialPedidoHelper;
        public HistorialPedidosController(IHistorialPedidoHelper _historialPedidoHelper)
        {
            this.historialPedidoHelper = _historialPedidoHelper;
        }

        // GET: HistorialPedidos
        public ActionResult Index()
        {
            return View(historialPedidoHelper.GetHistorialPedidos());
        }

        // GET: HistorialPedidos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistorialPedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialPedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialPedidos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialPedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialPedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorialPedidos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
