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
        public ActionResult ListaMiemboCeremonia()
        {
            MiembroCeremoniaVistaModelo lista = new MiembroCeremoniaVistaModelo();
            return PartialView("_ListaMiembrosCeremonia", lista.MienbroCeremonias().ToList());
        }        // GET: MiembroCeremonias/Details/5
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
        public ActionResult Create(int id)
        {
            string Cer = Request.Form["id"];
            var miembros = new SelectList(db.Miembros.ToList(), "MiembroID", "Nombre");
            ViewData["tipo"] = miembros;
            var tipoRol = new SelectList(new[] {
                new { ID="Sacramentado", Name="Sacramentado"},
                new { ID="Padre", Name="Padre"},
                new { ID="Madre", Name="Madre"},
                new { ID="Padrino", Name="Padrino"},
                new { ID="Madrina", Name="Madrina"},
            }, "ID", "Name");
            ViewData["tipoRol"] = tipoRol;

            var ceremonia = new SelectList(from c in db.Ceremonias
                            where c.CeremoniaID.Equals(id)
                            select new
                            {
                               c.CeremoniaID,
                               Dato = c.Fecha + " "+ c.Hora 
                            }, "CeremoniaID", "Dato");

            ViewData["ceremonia"] = ceremonia;
            return View();
        }
        public ActionResult ListaCeremonias()
        {
            CeremoniasVistaModelo lista = new CeremoniasVistaModelo();
            return PartialView("_ListaCeremonias", lista.Ceremonias().ToList());
        }
        // POST: MiembroCeremonias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(MiembroCeremonia miembroCeremonia)
        {

            if (ModelState.IsValid)
            {
                //foreach (var item in miembroCeremonia.Miembros)
                //{
                //    var consulta = (from m in db.Miembros
                //                    where m.Cedula.Contains(item.Cedula)
                //                    select m.Cedula).FirstOrDefault();
                //    if (consulta.ToString() != "")
                //    {
                //        ModelState.AddModelError("Cedula", "La cedula ya existe");
                //    }
                //}

                db.MiembrosCeremonias.Add(miembroCeremonia);
                    
                    db.SaveChanges();
               


                return Json(true);
            }

            return Json(false);
        }
       
        // GET: MiembroCeremonias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroCeremonia miembroCeremonia = db.MiembrosCeremonias.Find(id);
            //var miembros = new SelectList(db.Miembros.ToList(), "MiembroID", "Nombre");
            //ViewData["miembro"] = miembros;

            //var cere = new SelectList(db.Ceremonias.ToList(), "CeremoniaID");
            //ViewData["ceremo"] = cere;
            return View();
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
        public ActionResult Edit([Bind(Include = "MiembroCeremoniaID,MiembrosId,CeremoniasId")] MiembroCeremonia miembroCeremonia)
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
