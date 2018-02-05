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
    public class MiembroMatriculasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MiembroMatriculas
        public ActionResult Index()
        {
            return View(db.MiembrosMatriculas.ToList());
        }

        // GET: MiembroMatriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroMatricula miembroMatricula = db.MiembrosMatriculas.Find(id);
            if (miembroMatricula == null)
            {
                return HttpNotFound();
            }
            return View(miembroMatricula);
        }

        // GET: MiembroMatriculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiembroMatriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MiembroMatriculaID,MiembrosId,MatriculasId")] MiembroMatricula miembroMatricula)
        {
            if (ModelState.IsValid)
            {
                db.MiembrosMatriculas.Add(miembroMatricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miembroMatricula);
        }

        // GET: MiembroMatriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroMatricula miembroMatricula = db.MiembrosMatriculas.Find(id);
            if (miembroMatricula == null)
            {
                return HttpNotFound();
            }
            return View(miembroMatricula);
        }

        // POST: MiembroMatriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiembroMatriculaID,MiembrosId,MatriculasId")] MiembroMatricula miembroMatricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembroMatricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miembroMatricula);
        }

        // GET: MiembroMatriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroMatricula miembroMatricula = db.MiembrosMatriculas.Find(id);
            if (miembroMatricula == null)
            {
                return HttpNotFound();
            }
            return View(miembroMatricula);
        }

        // POST: MiembroMatriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MiembroMatricula miembroMatricula = db.MiembrosMatriculas.Find(id);
            db.MiembrosMatriculas.Remove(miembroMatricula);
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
