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
	public class KontaktOsobasController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: KontaktOsobas
		public ActionResult Index()
		{
			var kontaktOsobas = db.KontaktOsobas.Include(k => k.Preduzece);
			return View(kontaktOsobas.ToList());
		}

		// GET: KontaktOsobas/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			KontaktOsoba kontaktOsoba = db.KontaktOsobas
					.Include(ko => ko.KontaktTelefoni)
					.Include(ko => ko.Emailovi)
					.SingleOrDefault(ko => ko.Id == id);
			if (kontaktOsoba == null)
			{
				return HttpNotFound();
			}
			return View(kontaktOsoba);
		}

		// GET: KontaktOsobas/Create
		public ActionResult Create()
		{
			ViewBag.PreduzeceId = new SelectList(db.Preduzeces, "Id", "RegNaziv");
			return View();
		}

		// POST: KontaktOsobas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Ime,Prezime,RadnoMesto,PreduzeceId")] KontaktOsoba kontaktOsoba)
		{
			if (ModelState.IsValid)
			{
				db.KontaktOsobas.Add(kontaktOsoba);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.PreduzeceId = new SelectList(db.Preduzeces, "Id", "RegNaziv", kontaktOsoba.PreduzeceId);
			return View(kontaktOsoba);
		}

		// GET: KontaktOsobas/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			KontaktOsoba kontaktOsoba = db.KontaktOsobas.Find(id);
			if (kontaktOsoba == null)
			{
				return HttpNotFound();
			}
			ViewBag.PreduzeceId = new SelectList(db.Preduzeces, "Id", "RegNaziv", kontaktOsoba.PreduzeceId);
			return View(kontaktOsoba);
		}

		// POST: KontaktOsobas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Ime,Prezime,RadnoMesto,PreduzeceId")] KontaktOsoba kontaktOsoba)
		{
			if (ModelState.IsValid)
			{
				db.Entry(kontaktOsoba).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.PreduzeceId = new SelectList(db.Preduzeces, "Id", "RegNaziv", kontaktOsoba.PreduzeceId);
			return View(kontaktOsoba);
		}

		// GET: KontaktOsobas/Delete/5
		[Authorize(Roles = RoleName.SaPravomAdministracije)]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			KontaktOsoba kontaktOsoba = db.KontaktOsobas.Find(id);
			if (kontaktOsoba == null)
			{
				return HttpNotFound();
			}
			return View(kontaktOsoba);
		}

		// POST: KontaktOsobas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.SaPravomAdministracije)]
		public ActionResult DeleteConfirmed(int id)
		{
			KontaktOsoba kontaktOsoba = db.KontaktOsobas.Find(id);
			db.KontaktOsobas.Remove(kontaktOsoba);
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
