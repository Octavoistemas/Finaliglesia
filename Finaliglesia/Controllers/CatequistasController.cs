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
    public class CatequistasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catequistas
        public ActionResult Index()
        {
            return View(db.Catequistas.ToList());
        }
        public ActionResult ListaCatequistas()
        {
            CatequistasVistaModelo lista = new CatequistasVistaModelo();
            return PartialView("_ListaCatequistas", lista.Catequistas().ToList());
        }
        // GET: Catequistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catequista catequista = db.Catequistas.Find(id);
            if (catequista == null)
            {
                return HttpNotFound();
            }
            return View(catequista);
        }

        // GET: Catequistas/Create
        public ActionResult Create()
        {
            var iglesias = new SelectList(from i in db.Iglesias select i, "IglesiaID", "Nombre");
            ViewData["iglesias"] = iglesias;
            return View();
        }

        // POST: Catequistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatequistaID,Cedula,Nombre,Apellido,Direccion,Telefono,Celular,Email,IglesiasId")] Catequista catequista)
        {
            if (ModelState.IsValid)
            {
                db.Catequistas.Add(catequista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catequista);
        }

        // GET: Catequistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var iglesias = new SelectList(from i in db.Iglesias select i, "IglesiaID", "Nombre");
            ViewData["iglesias"] = iglesias;
            Catequista catequista = db.Catequistas.Find(id);
            
            if (catequista == null)
            {
                return HttpNotFound();
            }
            return View(catequista);
        }

        // POST: Catequistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatequistaID,Cedula,Nombre,Apellido,Direccion,Telefono,Celular,Email,IglesiasId")] Catequista catequista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catequista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catequista);
        }

        // GET: Catequistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catequista catequista = db.Catequistas.Find(id);
            if (catequista == null)
            {
                return HttpNotFound();
            }
            return View(catequista);
        }

        // POST: Catequistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catequista catequista = db.Catequistas.Find(id);
            db.Catequistas.Remove(catequista);
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
