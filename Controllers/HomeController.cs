using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using siteweb.Models;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace siteweb.Controllers
{

    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {           

            var sp = db.Specialites.ToList();
            return View(sp);
        }
        [Authorize]

        public ActionResult Details(int id)
        {
            Medcine medcine = db.Medcines.Include(c => c.Ville).Include(c => c.Specialite).SingleOrDefault(i => i.id ==id);
            if (medcine == null)
            {
                return HttpNotFound();
            }
            Session[" Medcineid"] = id;
            return View(medcine);
        }
        [Authorize(Roles = "Clients")]

        public ActionResult Rendez()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Clients")]

        public ActionResult Rendez(string message,string Prenom,string CNE)
        {
            var UserId = User.Identity.GetUserId();
            var MedId = (int)(Session[" Medcineid"]);
            var check = db.rendez_vous.Where(a => a.Medcineid == MedId && a.UserId == UserId).ToList();
            if (check.Count < 1)
            {
                var medcine = new rendez_vous();
                medcine.Medcineid = MedId;
                medcine.UserId = UserId;
                medcine.Message = message;
                medcine.Prenom = Prenom;
                medcine.CNE = CNE;
                medcine.Date = DateTime.Now;
                db.rendez_vous.Add(medcine);
                db.SaveChanges();
                ViewBag.Result = "Rendez-vous réservé";
            }
            else
            {
                ViewBag.Result = "Desolé tu est deja reserver";

            }
            return View();
        }
        [Authorize(Roles = "Clients,Administrateurs")]

        public ActionResult listrendez()
        {
            var UserId = User.Identity.GetUserId();
            var Medcine = db.rendez_vous.Where(a => a.UserId == UserId);
            return View(Medcine.ToList());
        }
        [Authorize(Roles = "Clients,Administrateurs")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           rendez_vous medcine = db.rendez_vous.Find(id);
            if (medcine == null)
            {
                return HttpNotFound();
            }
            return View(medcine);
        }

        // POST: Medcines1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Clients")]
        public ActionResult DeleteConfirmed(int id)
        {
            rendez_vous medcine = db.rendez_vous.Find(id);
            db.rendez_vous.Remove(medcine);
            db.SaveChanges();
            return RedirectToAction("listrendez");
        }
        //public ActionResult getservicesbydoctor()
        //{
        //    var medcine = db.Specialites.Include(c => c.nom);
        //    return View(medcine.ToList());
        //}
        [Authorize(Roles = "Medecines,Administrateurs")]
        public ActionResult getservicesbydoctor()
        {
            var USerId = User.Identity.GetUserId();
            var mecine = from app in db.rendez_vous
                         join Medcine in db.Medcines
                         on app.Medcineid  equals Medcine.id
                         where Medcine.User.Id == USerId
                         select app;
            return View(mecine.ToList());
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchname)
        {
            var result = db.Medcines.Where(a => a.Specialite.nom.Contains(searchname)).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        [Authorize]

        public ActionResult Contact(contact contact)
        {
            var Mail = new MailMessage();
            var LoginInfo = new NetworkCredential("mohafidi1998@gmail.com", "Amin.Morid..");
            Mail.From = new MailAddress(contact.Email);
            Mail.To.Add(new MailAddress("mohafidi1998@gmail.com"));
            Mail.Subject = contact.subject;
            Mail.IsBodyHtml = true;
            string body = "Nom : " + contact.Name + "<br>" +
                            "Email : " + contact.Email + "<br>" +
                            "Le Titre : " + contact.subject + "<br>" +
                            "Message : " + contact.Message + "</br>";
            Mail.Body = body;
            var smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.EnableSsl = true;
            smtp.Credentials = LoginInfo;
            smtp.Send(Mail);
            return RedirectToAction("Index");
        }
    }
}