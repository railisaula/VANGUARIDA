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
    public class C__MigrationHistoryController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: C__MigrationHistory
        public ActionResult Index()
        {
            return View(db.C__MigrationHistory.ToList());
        }

        // GET: C__MigrationHistory/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C__MigrationHistory c__MigrationHistory = db.C__MigrationHistory.Find(id);
            if (c__MigrationHistory == null)
            {
                return HttpNotFound();
            }
            return View(c__MigrationHistory);
        }

        // GET: C__MigrationHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: C__MigrationHistory/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MigrationId,ContextKey,Model,ProductVersion")] C__MigrationHistory c__MigrationHistory)
        {
            if (ModelState.IsValid)
            {
                db.C__MigrationHistory.Add(c__MigrationHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c__MigrationHistory);
        }

        // GET: C__MigrationHistory/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C__MigrationHistory c__MigrationHistory = db.C__MigrationHistory.Find(id);
            if (c__MigrationHistory == null)
            {
                return HttpNotFound();
            }
            return View(c__MigrationHistory);
        }

        // POST: C__MigrationHistory/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MigrationId,ContextKey,Model,ProductVersion")] C__MigrationHistory c__MigrationHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c__MigrationHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c__MigrationHistory);
        }

        // GET: C__MigrationHistory/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C__MigrationHistory c__MigrationHistory = db.C__MigrationHistory.Find(id);
            if (c__MigrationHistory == null)
            {
                return HttpNotFound();
            }
            return View(c__MigrationHistory);
        }

        // POST: C__MigrationHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            C__MigrationHistory c__MigrationHistory = db.C__MigrationHistory.Find(id);
            db.C__MigrationHistory.Remove(c__MigrationHistory);
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
