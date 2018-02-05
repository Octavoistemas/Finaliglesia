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
    public class IglesiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Iglesias
        public ActionResult Index()
        {
            return View(db.Iglesias.ToList());
        }

        // GET: Iglesias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesia iglesia = db.Iglesias.Find(id);
            if (iglesia == null)
            {
                return HttpNotFound();
            }
            return View(iglesia);
        }

        // GET: Iglesias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Iglesias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IglesiaID,Nombre,Direccion,TipoIglesiasId")] Iglesia iglesia)
        {
            if (ModelState.IsValid)
            {
                db.Iglesias.Add(iglesia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iglesia);
        }

        // GET: Iglesias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesia iglesia = db.Iglesias.Find(id);
            if (iglesia == null)
            {
                return HttpNotFound();
            }
            return View(iglesia);
        }

        // POST: Iglesias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IglesiaID,Nombre,Direccion,TipoIglesiasId")] Iglesia iglesia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iglesia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iglesia);
        }

        // GET: Iglesias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iglesia iglesia = db.Iglesias.Find(id);
            if (iglesia == null)
            {
                return HttpNotFound();
            }
            return View(iglesia);
        }

        // POST: Iglesias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iglesia iglesia = db.Iglesias.Find(id);
            db.Iglesias.Remove(iglesia);
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
