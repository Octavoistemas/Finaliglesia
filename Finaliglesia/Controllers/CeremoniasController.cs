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
    public class CeremoniasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ceremonias
        public ActionResult Index()
        {
            var curas = new SelectList(from s in db.Sacerdotes
                                       select new {
                                           Nombre = s.NombreSacerdote + " "+ s.ApellidoSacerdote,
                                           s.SacerdoteID
                                       }
                                       , "SacerdoteID", "Nombre");
            ViewBag.SacerdoteID = curas.ToList();
            return View(db.Ceremonias.ToList());
        }
        public JsonResult SacertodesDisponibles(DateTime fecha, string hora)
        {

            var SacerdotesId = from c in db.Ceremonias
                           where c.Fecha.Equals(fecha)
                           select new
                           {
                               Nombre = (from s in c.Sacerdotes select s.NombreSacerdote + " " + s.ApellidoSacerdote),
                               SacerdoteId = (from s in c.Sacerdotes select s.SacerdoteID)
                           };
            return Json(new SelectList(SacerdotesId, "SacerdoteID", "Nombre"));
        }
        // GET: Ceremonias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ceremonia ceremonia = db.Ceremonias.Find(id);
            if (ceremonia == null)
            {
                return HttpNotFound();
            }
            return View(ceremonia);
        }

        // GET: Ceremonias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ceremonias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CeremoniaID,Fecha,Hora,SacramentosId,SacerdotesId,MiembroCeremoniaId")] Ceremonia ceremonia)
        {
            if (ModelState.IsValid)
            {
                db.Ceremonias.Add(ceremonia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ceremonia);
        }

        // GET: Ceremonias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ceremonia ceremonia = db.Ceremonias.Find(id);
            if (ceremonia == null)
            {
                return HttpNotFound();
            }
            return View(ceremonia);
        }

        // POST: Ceremonias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CeremoniaID,Fecha,Hora,SacramentosId,SacerdotesId,MiembroCeremoniaId")] Ceremonia ceremonia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ceremonia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ceremonia);
        }

        // GET: Ceremonias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ceremonia ceremonia = db.Ceremonias.Find(id);
            if (ceremonia == null)
            {
                return HttpNotFound();
            }
            return View(ceremonia);
        }

        // POST: Ceremonias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ceremonia ceremonia = db.Ceremonias.Find(id);
            db.Ceremonias.Remove(ceremonia);
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
