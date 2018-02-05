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
    public class MiembrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Miembros
        public ActionResult Index()
        {
            return View(db.Miembros.ToList());
        }

        // GET: Miembros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembros.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // GET: Miembros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Miembros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MiembroID,Cedula,Nombre,Apellido,Direccion,Celular,Telefono,genero,FechaNacimiento,email")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                db.Miembros.Add(miembro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miembro);
        }

        // GET: Miembros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembros.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // POST: Miembros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiembroID,Cedula,Nombre,Apellido,Direccion,Celular,Telefono,genero,FechaNacimiento,email")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miembro);
        }

        // GET: Miembros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembros.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // POST: Miembros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembro miembro = db.Miembros.Find(id);
            db.Miembros.Remove(miembro);
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
