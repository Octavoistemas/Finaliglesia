using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Finaliglesia.Models;

namespace Finaliglesia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListaIglesias()
        {
            IglesiasVistaModelo lista = new IglesiasVistaModelo();
            return PartialView("_ListaIglesias", lista.Iglesias().ToList());
        }
        public ActionResult ListaDirectivas()
        {
            DirectivasVistaModelo lista = new DirectivasVistaModelo();
            return PartialView("_ListaDirectivas", lista.Directivas().ToList());
        }
        public ActionResult ListaCatequistas()
        {
            CatequistasVistaModelo lista = new CatequistasVistaModelo();
            return PartialView("_ListaCatequistas", lista.Catequistas().ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}