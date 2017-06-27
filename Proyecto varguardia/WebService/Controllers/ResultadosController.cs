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
    public class ResultadosController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Resultados
        public ActionResult Index()
        {
            var resultados = db.Resultados.Include(r => r.Pruebas).Include(r => r.Respuestas);
            return View(resultados.ToList());
        }

        // GET: Resultados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultados resultados = db.Resultados.Find(id);
            if (resultados == null)
            {
                return HttpNotFound();
            }
            return View(resultados);
        }

        // GET: Resultados/Create
        public ActionResult Create()
        {
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo");
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario");
            return View();
        }

        // POST: Resultados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Resultado,IdF_Respuesta,IdF_Prueba,Intento")] Resultados resultados)
        {
            if (ModelState.IsValid)
            {
                db.Resultados.Add(resultados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", resultados.IdF_Prueba);
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario", resultados.IdF_Respuesta);
            return View(resultados);
        }

        // GET: Resultados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultados resultados = db.Resultados.Find(id);
            if (resultados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", resultados.IdF_Prueba);
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario", resultados.IdF_Respuesta);
            return View(resultados);
        }

        // POST: Resultados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Resultado,IdF_Respuesta,IdF_Prueba,Intento")] Resultados resultados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", resultados.IdF_Prueba);
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario", resultados.IdF_Respuesta);
            return View(resultados);
        }

        // GET: Resultados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultados resultados = db.Resultados.Find(id);
            if (resultados == null)
            {
                return HttpNotFound();
            }
            return View(resultados);
        }

        // POST: Resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultados resultados = db.Resultados.Find(id);
            db.Resultados.Remove(resultados);
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
