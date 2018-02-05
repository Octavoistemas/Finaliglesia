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
    public class MiembroCeremoniasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MiembroCeremonias
        public ActionResult Index()
        {
            return View(db.MiembrosCeremonias.ToList());
        }

        // GET: MiembroCeremonias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroCeremonia miembroCeremonia = db.MiembrosCeremonias.Find(id);
            if (miembroCeremonia == null)
            {
                return HttpNotFound();
            }
            return View(miembroCeremonia);
        }

        // GET: MiembroCeremonias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiembroCeremonias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MiembroCeremoniaID,Rol,MiembrosId,CeremoniasId")] MiembroCeremonia miembroCeremonia)
        {
            if (ModelState.IsValid)
            {
                db.MiembrosCeremonias.Add(miembroCeremonia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miembroCeremonia);
        }

        // GET: MiembroCeremonias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroCeremonia miembroCeremonia = db.MiembrosCeremonias.Find(id);
            if (miembroCeremonia == null)
            {
                return HttpNotFound();
            }
            return View(miembroCeremonia);
        }

        // POST: MiembroCeremonias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiembroCeremoniaID,Rol,MiembrosId,CeremoniasId")] MiembroCeremonia miembroCeremonia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembroCeremonia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miembroCeremonia);
        }

        // GET: MiembroCeremonias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroCeremonia miembroCeremonia = db.MiembrosCeremonias.Find(id);
            if (miembroCeremonia == null)
            {
                return HttpNotFound();
            }
            return View(miembroCeremonia);
        }

        // POST: MiembroCeremonias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MiembroCeremonia miembroCeremonia = db.MiembrosCeremonias.Find(id);
            db.MiembrosCeremonias.Remove(miembroCeremonia);
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
