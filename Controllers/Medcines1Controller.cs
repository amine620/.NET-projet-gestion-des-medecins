using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using siteweb.Models;
using System.IO;
using System.Data.SqlClient;

namespace siteweb.Controllers
{



    [Authorize(Roles = "Medecines,Administrateurs")]

    public class Medcines1Controller : Controller
    {
        public connection con = new connection();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medcines1
        //[Authorize(Roles = "Administrateurs")]


        public ActionResult Index(string cpt)
        {
            var UserId = User.Identity.GetUserId();
            var Medcine = db.Medcines.Where(a => a.UserId == UserId).Include(m => m.Sexe).Include(m => m.Specialite).Include(m => m.Ville);
            con.connécté();
            
            con.cmd.CommandText = "set '" + cpt + "'=(select count(id) from Medcines ) ";
            con.cmd.Connection = con.con;
            con.cmd.ExecuteNonQuery();
            ViewBag.result = cpt;
            return View(Medcine.ToList());

            //var medcines = db.Medcines.Include(m => m.Sexe).Include(m => m.Specialite).Include(m => m.Ville);
            //return View(medcines.ToList());
        }
        public ActionResult getservice()
        {
            var UserId = User.Identity.GetUserId();
            var Medcine = db.Medcines.Where(a => a.UserId == UserId).Include(m => m.Sexe).Include(m => m.Specialite).Include(m => m.Ville);
            return View(Medcine.ToList());
        }

        // GET: Medcines1/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
             Medcine medcine = db.Medcines.Include(c =>c.Sexe).Include(c => c.Ville).Include(c => c.Specialite).SingleOrDefault(i=>i.id==id);
            if (medcine == null)
            {
                return HttpNotFound();
            }
            return View(medcine);
        }

        // GET: Medcines1/Create
        public ActionResult Create()
        {
            ViewBag.Sexeid = new SelectList(db.Sexes, "id", "nom");
            ViewBag.Specialiteid = new SelectList(db.Specialites, "id", "nom");
            ViewBag.Villeid = new SelectList(db.Villes, "id", "nom");
            return View();
        }

        // POST: Medcines1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Medcine medcine,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                medcine.UserId = User.Identity.GetUserId();
                string path = Path.Combine(Server.MapPath("~/uploid"), upload.FileName);
                upload.SaveAs(path);
                medcine.photo = upload.FileName;
                db.Medcines.Add(medcine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sexeid = new SelectList(db.Sexes, "id", "nom", medcine.Sexeid);
            ViewBag.Specialiteid = new SelectList(db.Specialites, "id", "nom", medcine.Specialiteid);
            ViewBag.Villeid = new SelectList(db.Villes, "id", "nom", medcine.Villeid);
            return View(medcine);
        }

        // GET: Medcines1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medcine medcine = db.Medcines.Find(id);
            if (medcine == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sexeid = new SelectList(db.Sexes, "id", "nom", medcine.Sexeid);
            ViewBag.Specialiteid = new SelectList(db.Specialites, "id", "nom", medcine.Specialiteid);
            ViewBag.Villeid = new SelectList(db.Villes, "id", "nom", medcine.Villeid);
            return View(medcine);
        }

        // POST: Medcines1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medcine medcine, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                medcine.UserId = User.Identity.GetUserId();
                string path = Path.Combine(Server.MapPath("~/uploid"), upload.FileName);
                upload.SaveAs(path);
                medcine.photo = upload.FileName;
                db.Entry(medcine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sexeid = new SelectList(db.Sexes, "id", "nom", medcine.Sexeid);
            ViewBag.Specialiteid = new SelectList(db.Specialites, "id", "nom", medcine.Specialiteid);
            ViewBag.Villeid = new SelectList(db.Villes, "id", "nom", medcine.Villeid);
            return View(medcine);
        }

        // GET: Medcines1/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Medcine medcine = db.Medcines.Find(id);
            //if (medcine == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(medcine);
            Medcine medcine = db.Medcines.Include(c => c.Sexe).Include(c => c.Ville).Include(c => c.Specialite).SingleOrDefault(i => i.id == id);
            if (medcine == null)
            {
                return HttpNotFound();
            }
            return View(medcine);
        }

        // POST: Medcines1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medcine medcine = db.Medcines.Find(id);
            db.Medcines.Remove(medcine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchname)
        {
            var result = db.Medcines.Where(a => a.Specialite.nom.Contains(searchname)||
            a.nom.Contains(searchname)|| a.prenom.Contains(searchname)||
            a.Ville.nom.Contains(searchname) || a.Sexe.nom.Contains(searchname)).ToList();
            return View(result);
        }
        public ActionResult Sum()
        {
            

                return View();
        }
        public ActionResult Sum(string cpt)
        {
            
           
            return RedirectToAction("index");
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
