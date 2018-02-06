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
    public class DirectivasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Directivas
        public ActionResult Index()
        {
            return View(db.Directivas.ToList());
        }

        // GET: Directivas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directiva directiva = db.Directivas.Find(id);
            if (directiva == null)
            {
                return HttpNotFound();
            }
            return View(directiva);
        }

        // GET: Directivas/Create
        public ActionResult Create()
        {
            var iglesia = new SelectList(db.Iglesias.ToList(), "IglesiaID", "Nombre");
            ViewData["iglesiass"] = iglesia;

            var car = new SelectList(db.Cargos.ToList(), "cargoID", "Nombre");
            ViewData["cargos"] = car;
      
            var perio = new SelectList(db.Periodos.ToList(), "PeriodoID", "Detalle");
            ViewData["periodoss"] = perio;
            return View();
        }

        // POST: Directivas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectivaID,Cedula,Nombre,Apellido,Direccion,Telefono,Celular,email,IglesiasId,CargosId,PeriodosId")] Directiva directiva)
        {
            if (ModelState.IsValid)
            {
                db.Directivas.Add(directiva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(directiva);
        }

        // GET: Directivas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directiva directiva = db.Directivas.Find(id);
            var iglesia = new SelectList(db.Iglesias.ToList(), "IglesiaID", "Nombre");
            ViewData["iglesiass"] = iglesia;

            var car = new SelectList(db.Cargos.ToList(), "cargoID", "Nombre");
            ViewData["cargos"] = car;

            var perio = new SelectList(db.Periodos.ToList(), "PeriodoID", "Detalle");
            ViewData["periodoss"] = perio;
            if (directiva == null)
            {
                return HttpNotFound();
            }
            return View(directiva);
        }

        // POST: Directivas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectivaID,Cedula,Nombre,Apellido,Direccion,Telefono,Celular,email,IglesiasId,CargosId,PeriodosId")] Directiva directiva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directiva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(directiva);
        }

        // GET: Directivas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directiva directiva = db.Directivas.Find(id);
            if (directiva == null)
            {
                return HttpNotFound();
            }
            return View(directiva);
        }

        // POST: Directivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Directiva directiva = db.Directivas.Find(id);
            db.Directivas.Remove(directiva);
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
