using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using siteweb.Models;

namespace siteweb.Controllers
{
    [Authorize(Roles = "Administrateurs")]

    public class SexesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sexes
        public ActionResult Index()
        {
            return View(db.Sexes.ToList());
        }

        // GET: Sexes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sexe sexe = db.Sexes.Find(id);
            if (sexe == null)
            {
                return HttpNotFound();
            }
            return View(sexe);
        }

        // GET: Sexes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom")] Sexe sexe)
        {
            if (ModelState.IsValid)
            {
                db.Sexes.Add(sexe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sexe);
        }

        // GET: Sexes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sexe sexe = db.Sexes.Find(id);
            if (sexe == null)
            {
                return HttpNotFound();
            }
            return View(sexe);
        }

        // POST: Sexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom")] Sexe sexe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sexe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sexe);
        }

        // GET: Sexes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sexe sexe = db.Sexes.Find(id);
            if (sexe == null)
            {
                return HttpNotFound();
            }
            return View(sexe);
        }

        // POST: Sexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sexe sexe = db.Sexes.Find(id);
            db.Sexes.Remove(sexe);
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
