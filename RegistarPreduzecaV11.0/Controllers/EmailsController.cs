using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistarPreduzecaV11._0.Models;

namespace RegistarPreduzecaV11._0.Controllers
{
    [Authorize(Roles = RoleName.SaPravomUnosaIliAdministracije)]
    public class EmailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Emails
        public ActionResult Index()
        {
            var emails = db.Emails.Include(e => e.KontaktOsoba);
            return View(emails.ToList());
        }

        // GET: Emails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // GET: Emails/Create
        public ActionResult Create()
        {
            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime");
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OznakaTipa,EmailAdresa,KontaktOsobaId")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Emails.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime", email.KontaktOsobaId);
            return View(email);
        }

        // GET: Emails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime", email.KontaktOsobaId);
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OznakaTipa,EmailAdresa,KontaktOsobaId")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime", email.KontaktOsobaId);
            return View(email);
        }

        // GET: Emails/Delete/5
        [Authorize(Roles = RoleName.SaPravomAdministracije)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SaPravomAdministracije)]
        public ActionResult DeleteConfirmed(int id)
        {
            Email email = db.Emails.Find(id);
            db.Emails.Remove(email);
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
