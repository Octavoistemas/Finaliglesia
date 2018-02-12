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
    public class TipoceremoniasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tipoceremonias
        public ActionResult Index()
        {
            return View(db.TipoCeremonias.ToList());
        }

        // GET: Tipoceremonias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipoceremonia tipoceremonia = db.TipoCeremonias.Find(id);
            if (tipoceremonia == null)
            {
                return HttpNotFound();
            }
            return View(tipoceremonia);
        }

        // GET: Tipoceremonias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipoceremonias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoceremoniaID,Detalle,Costo")] Tipoceremonia tipoceremonia)
        {
            if (ModelState.IsValid)
            {
                db.TipoCeremonias.Add(tipoceremonia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoceremonia);
        }

        // GET: Tipoceremonias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipoceremonia tipoceremonia = db.TipoCeremonias.Find(id);
            if (tipoceremonia == null)
            {
                return HttpNotFound();
            }
            return View(tipoceremonia);
        }

        // POST: Tipoceremonias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoceremoniaID,Detalle,Costo")] Tipoceremonia tipoceremonia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoceremonia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoceremonia);
        }

        // GET: Tipoceremonias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipoceremonia tipoceremonia = db.TipoCeremonias.Find(id);
            if (tipoceremonia == null)
            {
                return HttpNotFound();
            }
            return View(tipoceremonia);
        }

        // POST: Tipoceremonias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipoceremonia tipoceremonia = db.TipoCeremonias.Find(id);
            db.TipoCeremonias.Remove(tipoceremonia);
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
