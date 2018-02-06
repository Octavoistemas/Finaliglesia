﻿using System;
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
            var lista = new SelectList(from c in db.TipoCeremonias select c, "TipoceremoniaID", "Detalle");
            ViewData["Tipo"] = lista;
            var iglesias = new SelectList(from i in db.Iglesias select i, "IglesiaID", "Nombre");
            ViewData["iglesias"] = iglesias;
            return View();
        }

        // POST: Ceremonias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CeremoniaID,IglesiasId,HoraiosId,SacramentosId,FacturasId,SacerdotesId, Tipoceremonia_TipoceremoniaID")] Ceremonia ceremonia)
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
        public ActionResult Edit([Bind(Include = "CeremoniaID,IglesiasId,HoraiosId,SacramentosId,FacturasId,SacerdotesId")] Ceremonia ceremonia)
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
