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
    public class MatriculasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matriculas
        public ActionResult Index()
        {
            return View(db.Matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            var iglesia = new SelectList(db.Iglesias.ToList(), "IglesiaID", "Nombre");
            ViewData["tipo"] = iglesia;

            var cate = new SelectList(db.Catequistas.ToList(), "CatequistaID", "Nombre", "Apellido");
            ViewData["catequistaa"] = cate;

            var car = new SelectList(db.Sacramentos.ToList(), "SacramentoID", "DetalleSacramento");
            ViewData["sacramentoo"] = car;

            var perio = new SelectList(db.Periodos.ToList(), "PeriodoID", "Detalle");
            ViewData["periodoss"] = perio;
            return View();
        }

        // POST: Matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatriculaID,IglesiasId,CatequistasId,SacramentosId,PeriodosId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            var iglesia = new SelectList(db.Iglesias.ToList(), "IglesiaID", "Nombre");
            ViewData["tipo"] = iglesia;

            var cate = new SelectList(db.Catequistas.ToList(), "CatequistaID", "Nombre", "Apellido");
            ViewData["catequistaa"] = cate;

            var car = new SelectList(db.Sacramentos.ToList(), "SacramentoID", "DetalleSacramento");
            ViewData["sacramentoo"] = car;

            var perio = new SelectList(db.Periodos.ToList(), "PeriodoID", "Detalle");
            ViewData["periodoss"] = perio;
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatriculaID,IglesiasId,CatequistasId,SacramentosId,PeriodosId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
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
