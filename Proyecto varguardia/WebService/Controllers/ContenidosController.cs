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
    public class ContenidosController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Contenidos
        public ActionResult Index()
        {
            return View(db.Contenidos.ToList());
        }

        // GET: Contenidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenidos contenidos = db.Contenidos.Find(id);
            if (contenidos == null)
            {
                return HttpNotFound();
            }
            return View(contenidos);
        }

        // GET: Contenidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contenidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Contenido,Titulo,Descripcion,Archivo,Enlace")] Contenidos contenidos)
        {
            if (ModelState.IsValid)
            {
                db.Contenidos.Add(contenidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contenidos);
        }

        // GET: Contenidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenidos contenidos = db.Contenidos.Find(id);
            if (contenidos == null)
            {
                return HttpNotFound();
            }
            return View(contenidos);
        }

        // POST: Contenidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Contenido,Titulo,Descripcion,Archivo,Enlace")] Contenidos contenidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contenidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contenidos);
        }

        // GET: Contenidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenidos contenidos = db.Contenidos.Find(id);
            if (contenidos == null)
            {
                return HttpNotFound();
            }
            return View(contenidos);
        }

        // POST: Contenidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contenidos contenidos = db.Contenidos.Find(id);
            db.Contenidos.Remove(contenidos);
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
