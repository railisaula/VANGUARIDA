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
    public class SegmentosController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Segmentos
        public ActionResult Index()
        {
            var segmentos = db.Segmentos.Include(s => s.Cursos);
            return View(segmentos.ToList());
        }

        // GET: Segmentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmentos segmentos = db.Segmentos.Find(id);
            if (segmentos == null)
            {
                return HttpNotFound();
            }
            return View(segmentos);
        }

        // GET: Segmentos/Create
        public ActionResult Create()
        {
            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre");
            return View();
        }

        // POST: Segmentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Segmento,IdF_Curso,Id_SegmentoPadre,Titulo,Descripcion,Visible,IdF_Pais")] Segmentos segmentos)
        {
            if (ModelState.IsValid)
            {
                db.Segmentos.Add(segmentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre", segmentos.IdF_Curso);
            return View(segmentos);
        }

        // GET: Segmentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmentos segmentos = db.Segmentos.Find(id);
            if (segmentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre", segmentos.IdF_Curso);
            return View(segmentos);
        }

        // POST: Segmentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Segmento,IdF_Curso,Id_SegmentoPadre,Titulo,Descripcion,Visible,IdF_Pais")] Segmentos segmentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segmentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre", segmentos.IdF_Curso);
            return View(segmentos);
        }

        // GET: Segmentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmentos segmentos = db.Segmentos.Find(id);
            if (segmentos == null)
            {
                return HttpNotFound();
            }
            return View(segmentos);
        }

        // POST: Segmentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Segmentos segmentos = db.Segmentos.Find(id);
            db.Segmentos.Remove(segmentos);
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
