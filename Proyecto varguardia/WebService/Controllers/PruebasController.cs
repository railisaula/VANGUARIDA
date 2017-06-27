using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    public class PruebasController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Pruebas
        public ActionResult Index()
        {
            return View(db.Pruebas.ToList());
        }

        // GET: Pruebas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pruebas pruebas = db.Pruebas.Find(id);
            if (pruebas == null)
            {
                return HttpNotFound();
            }
            return View(pruebas);
        }

        // GET: Pruebas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pruebas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Prueba,Titulo,Descripcion,Intentos,Aleatorio")] Pruebas pruebas)
        {
            if (ModelState.IsValid)
            {
                db.Pruebas.Add(pruebas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pruebas);
        }

        // GET: Pruebas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pruebas pruebas = db.Pruebas.Find(id);
            if (pruebas == null)
            {
                return HttpNotFound();
            }
            return View(pruebas);
        }

        // POST: Pruebas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Prueba,Titulo,Descripcion,Intentos,Aleatorio")] Pruebas pruebas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pruebas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pruebas);
        }

        // GET: Pruebas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pruebas pruebas = db.Pruebas.Find(id);
            if (pruebas == null)
            {
                return HttpNotFound();
            }
            return View(pruebas);
        }

        // POST: Pruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pruebas pruebas = db.Pruebas.Find(id);
            db.Pruebas.Remove(pruebas);
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
