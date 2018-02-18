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
        public ActionResult ListaMiembrosMatricula()
        {
            MiembroMatriculaVistaModelo lista = new MiembroMatriculaVistaModelo();
            return PartialView("_ListaMiembroMatricula", lista.MiembroMatriculas().ToList());
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
        public ActionResult Create(int id)
        {
            var matriculas = new SelectList(from m in db.Matriculas
                                           join s in db.Sacramentos on m.SacramentosId equals s.SacramentoID
                                           join p in db.Periodos on m.PeriodosId equals p.PeriodoID
                                           join i in db.Iglesias on m.IglesiasId equals i.IglesiaID
                                           where m.MatriculaID.Equals(id)
                                           select new
                                           {
                                               MatriculaID = m.MatriculaID,
                                               Dato = s.DetalleSacramento+"/"+p.Detalle+"/"+i.Nombre
                                           }, "MatriculaID", "Dato");

            ViewData["matricula"] = matriculas;
            return View();
        }

        // POST: MiembroMatriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(MiembroMatricula miembromatricula)
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

                db.MiembrosMatriculas.Add(miembromatricula);

                db.SaveChanges();

                return Json(true);
            }

            return Json(false);
        }
        //public ActionResult Create([Bind(Include = "MiembroMatriculaID,MiembrosId,MatriculasId")] MiembroMatricula miembroMatricula)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.MiembrosMatriculas.Add(miembroMatricula);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(miembroMatricula);
        //}

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
        public ActionResult Edit([Bind(Include = "MiembroMatriculaID,MatriculasId")] MiembroMatricula miembroMatricula)
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

        public JsonResult BusquedaMatricula(int id, int idmm)
        {

            object consulta = (from m in db.Matriculas
                               join c in db.Catequistas on m.CatequistasId equals c.CatequistaID
                               join s in db.Sacramentos on m.SacramentosId equals s.SacramentoID
                               join p in db.Periodos on m.PeriodosId equals p.PeriodoID
                               join mm in db.MiembrosMatriculas on m.MatriculaID equals mm.MatriculasId
                               from mem in mm.Miembros
                                   // join mem in db.Miembros on mm.MiembrosId equals mem.MiembroID
                               where mm.MatriculasId.Equals(id) && mem.MiembroID.Equals(idmm)
                               select new
                               {
                                   Periodo = p.Detalle,
                                   CedulaE = mem.Cedula,
                                   NombreE = mem.Nombre + " " + mem.Apellido,
                                   DireccionE = mem.Direccion,
                                   TelefonoE = mem.Telefono,
                                   Sacramento = s.DetalleSacramento,
                                   NombreC = c.Nombre + " " + c.Apellido,
                                   Cedula = c.Cedula,
                                   Numero = mm.MiembroMatriculaID,
                                   TelefonoC = c.Telefono,
                                   DireccionC = c.Direccion
                               }).ToList();




            return Json(consulta, JsonRequestBehavior.AllowGet);
        }
    }
}
