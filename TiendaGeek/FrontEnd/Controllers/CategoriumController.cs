using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CategoriumController : Controller
    {
        private readonly ICategoriumHelper categoriumHelper;

        public CategoriumController(ICategoriumHelper categoriumHelper)
        {
            this.categoriumHelper = categoriumHelper;
        }

        // GET: Categorium
        public ActionResult Index()
        {
            return View(categoriumHelper.GetCategorias());
        }

        // GET: Categorium/Details/5
        public ActionResult Details(int id)
        {
            CategoriumViewModel categorium = categoriumHelper.GetCategoria(id);
            return View(categorium);
        }

        // GET: Categorium/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorium/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriumViewModel categorium)
        {
            try
            {
                _ = categoriumHelper.Add(categorium);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorium/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriumViewModel categorium = categoriumHelper.GetCategoria(id);
            return View(categorium);
        }

        // POST: Categorium/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriumViewModel categorium)
        {
            try
            {
                _ = categoriumHelper.Update(categorium);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorium/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriumViewModel categorium = categoriumHelper.GetCategoria(id);
            return View(categorium);
        }

        // POST: Categorium/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriumViewModel categorium)
        {
            try
            {
                _ = categoriumHelper.Remove(categorium.CodigoCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}


