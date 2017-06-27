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
    public class CursosController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.AspNetUsers).Include(c => c.AspNetUsers1);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Cursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Curso,Nombre,Id_CursoRequisito,Autorizado,IdF_Pais,NotaMinima,Visible,IdF_UsuarioCreacion,FechaCreacion,IdF_UsuarioModificacion,FechaModificacion,Estado")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email", cursos.IdF_UsuarioCreacion);
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email", cursos.IdF_UsuarioModificacion);
            return View(cursos);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email", cursos.IdF_UsuarioCreacion);
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email", cursos.IdF_UsuarioModificacion);
            return View(cursos);
        }

        // POST: Cursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Curso,Nombre,Id_CursoRequisito,Autorizado,IdF_Pais,NotaMinima,Visible,IdF_UsuarioCreacion,FechaCreacion,IdF_UsuarioModificacion,FechaModificacion,Estado")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email", cursos.IdF_UsuarioCreacion);
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email", cursos.IdF_UsuarioModificacion);
            return View(cursos);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
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
