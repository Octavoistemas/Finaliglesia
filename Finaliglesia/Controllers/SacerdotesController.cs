using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finaliglesia.Models;

namespace Finaliglesia.Controllers
{
    public class SacerdotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sacerdotes
        public ActionResult Index()
        {
            return View(db.Sacerdotes.ToList());
        }
        public ActionResult Buscar()
        {
            BuscarSacerdote busca = new BuscarSacerdote();

            return View(busca);
        }
        public ActionResult BuscaCedula(BuscarSacerdote model)
        {
            if (ModelState.IsValid)
            {
                BusquedaSacerdoteModeloVista Cedula = new BusquedaSacerdoteModeloVista();
                Cedula.SacerdoteConsultas(model.Fecha);
                return PartialView("_SacerdotesBuscar", Cedula.SacerdoteLista);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View("Buscar", model);
            }


        }
        // GET: Sacerdotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sacerdote sacerdote = db.Sacerdotes.Find(id);
            if (sacerdote == null)
            {
                return HttpNotFound();
            }
            return View(sacerdote);
        }

        // GET: Sacerdotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sacerdotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SacerdoteID,Cedula,NombreSacerdote,ApellidoSacerdote,Telefono,Celular,Direccion,email")] Sacerdote sacerdote)
        {
            if (ModelState.IsValid)
            {
                db.Sacerdotes.Add(sacerdote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sacerdote);
        }

        // GET: Sacerdotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sacerdote sacerdote = db.Sacerdotes.Find(id);
            if (sacerdote == null)
            {
                return HttpNotFound();
            }
            return View(sacerdote);
        }

        // POST: Sacerdotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SacerdoteID,Cedula,NombreSacerdote,ApellidoSacerdote,Telefono,Celular,Direccion,email")] Sacerdote sacerdote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sacerdote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sacerdote);
        }

        // GET: Sacerdotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sacerdote sacerdote = db.Sacerdotes.Find(id);
            if (sacerdote == null)
            {
                return HttpNotFound();
            }
            return View(sacerdote);
        }

        // POST: Sacerdotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sacerdote sacerdote = db.Sacerdotes.Find(id);
            db.Sacerdotes.Remove(sacerdote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
