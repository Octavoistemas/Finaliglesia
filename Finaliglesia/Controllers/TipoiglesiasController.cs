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
    public class TipoiglesiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tipoiglesias
        public ActionResult Index()
        {
            return View(db.TipoIglesias.ToList());
        }

        // GET: Tipoiglesias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipoiglesia tipoiglesia = db.TipoIglesias.Find(id);
            if (tipoiglesia == null)
            {
                return HttpNotFound();
            }
            return View(tipoiglesia);
        }

        // GET: Tipoiglesias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipoiglesias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoiglesiaID,Detalle")] Tipoiglesia tipoiglesia)
        {
            if (ModelState.IsValid)
            {
                db.TipoIglesias.Add(tipoiglesia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoiglesia);
        }

        // GET: Tipoiglesias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipoiglesia tipoiglesia = db.TipoIglesias.Find(id);
            if (tipoiglesia == null)
            {
                return HttpNotFound();
            }
            return View(tipoiglesia);
        }

        // POST: Tipoiglesias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoiglesiaID,Detalle")] Tipoiglesia tipoiglesia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoiglesia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoiglesia);
        }

        // GET: Tipoiglesias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipoiglesia tipoiglesia = db.TipoIglesias.Find(id);
            if (tipoiglesia == null)
            {
                return HttpNotFound();
            }
            return View(tipoiglesia);
        }

        // POST: Tipoiglesias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipoiglesia tipoiglesia = db.TipoIglesias.Find(id);
            db.TipoIglesias.Remove(tipoiglesia);
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
