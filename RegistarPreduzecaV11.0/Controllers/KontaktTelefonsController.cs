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
    public class KontaktTelefonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KontaktTelefons
        public ActionResult Index()
        {
            var kontaktTelefons = db.KontaktTelefons.Include(k => k.KontaktOsoba);
            return View(kontaktTelefons.ToList());
        }

        // GET: KontaktTelefons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktTelefon kontaktTelefon = db.KontaktTelefons.Include(o=>o.KontaktOsoba).SingleOrDefault(t=>t.Id == id);
            if (kontaktTelefon == null)
            {
                return HttpNotFound();
            }
            return View(kontaktTelefon);
        }

        // GET: KontaktTelefons/Create
        public ActionResult Create()
        {
            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime");
            return View();
        }

        // POST: KontaktTelefons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OznakaTipa,BrojTelefona,Lokal,KontaktOsobaId")] KontaktTelefon kontaktTelefon)
        {
            if (ModelState.IsValid)
            {
                db.KontaktTelefons.Add(kontaktTelefon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime", kontaktTelefon.KontaktOsobaId);
            return View(kontaktTelefon);
        }

        // GET: KontaktTelefons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktTelefon kontaktTelefon = db.KontaktTelefons.Find(id);
            if (kontaktTelefon == null)
            {
                return HttpNotFound();
            }
            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime", kontaktTelefon.KontaktOsobaId);
            return View(kontaktTelefon);
        }

        // POST: KontaktTelefons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OznakaTipa,BrojTelefona,Lokal,KontaktOsobaId")] KontaktTelefon kontaktTelefon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontaktTelefon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KontaktOsobaId = new SelectList(db.KontaktOsobas, "Id", "Ime", kontaktTelefon.KontaktOsobaId);
            return View(kontaktTelefon);
        }

        // GET: KontaktTelefons/Delete/5
        [Authorize(Roles = RoleName.SaPravomAdministracije)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktTelefon kontaktTelefon = db.KontaktTelefons.Include(o=>o.KontaktOsoba).SingleOrDefault(t=>t.Id==id);
            if (kontaktTelefon == null)
            {
                return HttpNotFound();
            }
            return View(kontaktTelefon);
        }

        // POST: KontaktTelefons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SaPravomAdministracije)]
        public ActionResult DeleteConfirmed(int id)
        {
            KontaktTelefon kontaktTelefon = db.KontaktTelefons.Include(o => o.KontaktOsoba).SingleOrDefault(t => t.Id == id);
            db.KontaktTelefons.Remove(kontaktTelefon);
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
