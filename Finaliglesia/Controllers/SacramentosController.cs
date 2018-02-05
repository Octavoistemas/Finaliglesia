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
    public class SacramentosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sacramentos
        public ActionResult Index()
        {
            return View(db.Sacramentos.ToList());
        }

        // GET: Sacramentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sacramento sacramento = db.Sacramentos.Find(id);
            if (sacramento == null)
            {
                return HttpNotFound();
            }
            return View(sacramento);
        }

        // GET: Sacramentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sacramentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SacramentoID,DetalleSacramento")] Sacramento sacramento)
        {
            if (ModelState.IsValid)
            {
                db.Sacramentos.Add(sacramento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sacramento);
        }

        // GET: Sacramentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sacramento sacramento = db.Sacramentos.Find(id);
            if (sacramento == null)
            {
                return HttpNotFound();
            }
            return View(sacramento);
        }

        // POST: Sacramentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SacramentoID,DetalleSacramento")] Sacramento sacramento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sacramento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sacramento);
        }

        // GET: Sacramentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sacramento sacramento = db.Sacramentos.Find(id);
            if (sacramento == null)
            {
                return HttpNotFound();
            }
            return View(sacramento);
        }

        // POST: Sacramentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sacramento sacramento = db.Sacramentos.Find(id);
            db.Sacramentos.Remove(sacramento);
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
