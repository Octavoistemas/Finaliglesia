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

            return View(db.Ceremonias.ToList());
        }
        public ActionResult ListaCeremonias()
        {
            CeremoniasVistaModelo lista = new CeremoniasVistaModelo();
            return PartialView("_ListaCeremonias", lista.Ceremonias().ToList());
        }
        public JsonResult SacertodesDisponibles(DateTime fecha, string hora) //, string hora
        {

            var SacerdotesId = from Sacerdotes in db.Sacerdotes
                               where
                                     (from Ceremonias in db.Ceremonias
                                      where
                                             Sacerdotes.SacerdoteID == Ceremonias.SacerdotesId &&
                                             Ceremonias.Fecha == fecha &&
                                             Ceremonias.Hora == hora
                                      select new
                                      {
                                          Column1 = 1
                                      }).FirstOrDefault() == null
                               select new
                               {
                                   SacerdoteID = Sacerdotes.SacerdoteID,
                                   Nombre = Sacerdotes.NombreSacerdote+" "+ Sacerdotes.ApellidoSacerdote
                               };
            return Json(new SelectList(SacerdotesId, "SacerdoteID", "Nombre"), JsonRequestBehavior.AllowGet);
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
            var iglesia = new SelectList(db.Iglesias.ToList(), "IglesiaID", "Nombre");
            var tipoceremonia = new SelectList(db.TipoCeremonias.ToList(), "TipoceremoniaID", "Detalle");

            var horas = new SelectList(new[] {
                new { ID="06:00", Name="06:00"},
                new { ID="07:00", Name="07:00"},
                new { ID="08:00", Name="08:00"},
                new { ID="09:00", Name="09:00"},
                new { ID="10:00", Name="10:00"},
                new { ID="11:00", Name="11:00"},
                new { ID="12:00", Name="12:00"},
                new { ID="13:00", Name="13:00"},
                new { ID="14:00", Name="14:00"},
                new { ID="15:00", Name="15:00"},
                new { ID="16:00", Name="16:00"},
                new { ID="17:00", Name="17:00"},
                new { ID="18:00", Name="18:00"},
                new { ID="19:00", Name="09:00"},
                new { ID="20:00", Name="20:00"},
                new { ID="21:00", Name="21:00"},
                new { ID="22:00", Name="22:00"},
                new { ID="23:00", Name="23:00"},
                new { ID="00:00", Name="00:00"}
            }, "ID", "Name");
            var sacra = new SelectList(from s in db.Sacramentos select s, "SacramentoID", "DetalleSacramento");
            var sacer = new SelectList(from s in db.Sacerdotes select new { SacerdoteID = s.SacerdoteID, Nombre = s.NombreSacerdote + " " + s.ApellidoSacerdote }, "SacerdoteID", "Nombre");
            ViewData["sacer"] = sacer;
            ViewData["Sacra"] = sacra;
            ViewData["Horas"] = horas;
            ViewData["iglesiass"] = iglesia;
            ViewData["tceremons"] = tipoceremonia;
            return View();
        }

        // POST: Ceremonias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CeremoniaID,Fecha,Hora,SacramentosId,TipoCeremoniasId,SacerdotesId,iglesiaid")] Ceremonia ceremonia)
        {
            if (ModelState.IsValid)
            {
                db.Ceremonias.Add(ceremonia);
                db.SaveChanges();
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
        public ActionResult Edit([Bind(Include = "CeremoniaID,Fecha,Hora,SacramentosId,TipoCeremoniasId,SacerdotesId,iglesiaid")] Ceremonia ceremonia)
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
