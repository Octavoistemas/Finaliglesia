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
            var tipo = new SelectList(from s in db.TipoIglesias select s, "TipoiglesiaID", "Detalle");
            ViewData["tipo"] = tipo;
            return View();
        }
        public ActionResult ListaIglesias()
        {
            IglesiasVistaModelo lista = new IglesiasVistaModelo();
            return PartialView("_ListaIglesias", lista.Iglesias().ToList());
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
            var tipo = new SelectList(from s in db.TipoIglesias select s, "TipoiglesiaID", "Detalle");
            ViewData["tipo"] = tipo;
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

        public ActionResult Reporte()
        {
            return View(db.Iglesias.ToList());
        }

        public ActionResult ListadoIglesiasVista()
        {
            return View(db.Iglesias.ToList());
        }

        public JsonResult ListaIglesia()
        {

            return Json(db.Iglesias.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MatriculaPorIglesia()
        {

            return View(db.Periodos.ToList());
        }



        public JsonResult BusquedaPorIglecia(int id)
        {

            var consulta = (from s in db.Sacerdotes
                            join c in db.Ceremonias on s.SacerdoteID equals c.SacerdotesId
                            join i in db.Iglesias on c.iglesiaid equals i.IglesiaID
                            join sc in db.Sacramentos on c.SacramentosId equals sc.SacramentoID
                            join tc in db.TipoCeremonias on c.TipoCeremoniasId equals tc.TipoceremoniaID
                            where i.IglesiaID.Equals(id)
                            select new
                            {
                                s.Cedula,
                                s.NombreSacerdote,
                                s.ApellidoSacerdote,
                                c.Fecha,
                                c.Hora,
                                i.Nombre,
                                sc.DetalleSacramento,
                                tc.Detalle

                            }).ToList();

            return Json(consulta, JsonRequestBehavior.AllowGet);


        }

        public JsonResult BusquedaPorIgleciaMatricula(int id, int idc, int idp)
        {

            object consulta = null;

            var consultaa = (from m in db.Matriculas
                             where m.SacramentosId.Equals(idc) && m.IglesiasId.Equals(id) && m.PeriodosId.Equals(idp)
                             select new
                             {
                                 m.MatriculaID
                             }).ToList();

            if (consultaa != null)
            {
                foreach (var item in consultaa)
                {

                    consulta = (from m in db.Matriculas
                                join p in db.Periodos on m.PeriodosId equals p.PeriodoID
                                join mm in db.MiembrosMatriculas on m.MatriculaID equals mm.MatriculasId
                                
                                //join mem in db.Miembros on mm.MiembrosId equals mem.MiembroID
                                where m.MatriculaID.Equals(item.MatriculaID)
                                from mem in mm.Miembros
                                where mem.Rol == "Estudiante"
                                select new
                                {
                                    p.Detalle,
                                    mem.Cedula,
                                    mem.Nombre,
                                    mem.Apellido,
                                    mem.Direccion,
                                    mem.Telefono
                                }).ToList();
                }
            }


            return Json(consulta, JsonRequestBehavior.AllowGet);
        }
    
}
}
