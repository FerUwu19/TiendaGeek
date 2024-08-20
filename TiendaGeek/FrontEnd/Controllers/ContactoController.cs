using FrontEnd.ApiModel;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ContactoController : Controller
    {
        //objeto Helper
        private readonly IContactoHelper contactoHelper;

        //constructor
        public ContactoController(IContactoHelper contactoHelper)
        {
            this.contactoHelper = contactoHelper;
        }

        //vista antes de enviar
        public IActionResult Contacto()
        {
            return View();
        }

        //captura datos del form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contacto(ContactoViewModel contacto)
        {
            try
            {
                contacto.IdUser = 1; // cambiar cuando funcione el login

                _ = contactoHelper.Add(contacto);


                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacto
        public ActionResult Index()
        {
            return View(contactoHelper.GetContactos());
        }
    }//fn class
}//fn space
