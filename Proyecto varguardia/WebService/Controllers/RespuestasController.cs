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
    public class RespuestasController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Respuestas
        public ActionResult Index()
        {
            var respuestas = db.Respuestas.Include(r => r.AspNetUsers).Include(r => r.Preguntas).Include(r => r.Pruebas);
            return View(respuestas.ToList());
        }

        // GET: Respuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestas respuestas = db.Respuestas.Find(id);
            if (respuestas == null)
            {
                return HttpNotFound();
            }
            return View(respuestas);
        }

        // GET: Respuestas/Create
        public ActionResult Create()
        {
            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo");
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo");
            return View();
        }

        // POST: Respuestas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Respuesta,IdF_Pregunta,IdF_Prueba,IdF_Usuario,TituloRespuesta,TextoRespuesta,Correcto,Ponderacion")] Respuestas respuestas)
        {
            if (ModelState.IsValid)
            {
                db.Respuestas.Add(respuestas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", respuestas.IdF_Usuario);
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo", respuestas.IdF_Pregunta);
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", respuestas.IdF_Prueba);
            return View(respuestas);
        }

        // GET: Respuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestas respuestas = db.Respuestas.Find(id);
            if (respuestas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", respuestas.IdF_Usuario);
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo", respuestas.IdF_Pregunta);
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", respuestas.IdF_Prueba);
            return View(respuestas);
        }

        // POST: Respuestas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Respuesta,IdF_Pregunta,IdF_Prueba,IdF_Usuario,TituloRespuesta,TextoRespuesta,Correcto,Ponderacion")] Respuestas respuestas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuestas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", respuestas.IdF_Usuario);
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo", respuestas.IdF_Pregunta);
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", respuestas.IdF_Prueba);
            return View(respuestas);
        }

        // GET: Respuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestas respuestas = db.Respuestas.Find(id);
            if (respuestas == null)
            {
                return HttpNotFound();
            }
            return View(respuestas);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuestas respuestas = db.Respuestas.Find(id);
            db.Respuestas.Remove(respuestas);
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
