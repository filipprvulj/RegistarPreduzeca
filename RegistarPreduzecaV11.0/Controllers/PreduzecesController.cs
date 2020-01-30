using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistarPreduzecaV11._0.Models;
using RegistarPreduzecaV11._0.viewModel;
using SelectPdf;

namespace RegistarPreduzecaV11._0.Controllers
{
	public class PreduzecesController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Preduzeces
		public ActionResult Index()
		{
			return View(db.Preduzeces.ToList());
		}

		// GET: Preduzeces/Details/5
		[AllowAnonymous]
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var preduzece = db.Preduzeces.Include(p => p.KontaktOsobe).Single(p => p.Id == id);
			var kontaktOsoba = db.KontaktOsobas
					.Include(ko => ko.KontaktTelefoni)
					.Include(ko=>ko.Emailovi)
					.Where(ko => ko.PreduzeceId == id);

			var viewModel = new PreduzeceViewModel
			{
				Preduzece = preduzece,
				KontaktOsoba = kontaktOsoba
			};
			//var kontaktOsoba = db.KontaktOsobas.Where(k => k.PreduzeceId == id).ToList();
			//var kontaktTelefoni = new List<KontaktTelefon>();
			//var sviTelefoni = db.KontaktTelefons.ToList();
			//foreach(var osoba in kontaktOsoba)
			//{
			//	var asd = osoba.Id;
			//	foreach(var telefon in sviTelefoni)
			//	{
			//		if (asd == telefon.KontaktOsobaId)
			//			kontaktTelefoni.Add(telefon);
			//	}
			//}

			//var preduzece = new PreduzeceViewModel
			//{
			//	Preduzece = db.Preduzeces.SingleOrDefault(p => p.Id == id),
			//	KontaktOsoba = kontaktOsoba,
			//	KontaktTelefoni = db.KontaktTelefons.Where(kt => kt.KontaktOsobaId == kontaktOsoba.FirstOrDefault(ko => kt.KontaktOsobaId == ko.Id).Id).ToList()
			//}; 

			if (preduzece == null)
			{
				return HttpNotFound();
			}
			return View(viewModel);
		}

		// GET: Preduzeces/Create
		[Authorize(Roles = RoleName.SaPravomUnosaIliAdministracije)]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Preduzeces/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.SaPravomUnosaIliAdministracije)]
		public ActionResult Create([Bind(Include = "Id,RegNaziv,RegAdresa,Opstina,PostanskiBroj,MaticniBroj,PIB,SifraDelatnosti,OpisDelatnosti,BrojRacuna,WebStranica,Pecat,Beleska")] Preduzece preduzece)
		{
			if (ModelState.IsValid)
			{
				db.Preduzeces.Add(preduzece);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(preduzece);
		}

		// GET: Preduzeces/Edit/5
		[Authorize(Roles = RoleName.SaPravomUnosaIliAdministracije)]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Preduzece preduzece = db.Preduzeces.Find(id);
			if (preduzece == null)
			{
				return HttpNotFound();
			}
			return View(preduzece);
		}

		// POST: Preduzeces/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.SaPravomUnosaIliAdministracije)]
		public ActionResult Edit([Bind(Include = "Id,RegNaziv,RegAdresa,Opstina,PostanskiBroj,MaticniBroj,PIB,SifraDelatnosti,OpisDelatnosti,BrojRacuna,WebStranica,Pecat,Beleska")] Preduzece preduzece)
		{
			if (ModelState.IsValid)
			{
				db.Entry(preduzece).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(preduzece);
		}

		// GET: Preduzeces/Delete/5
		[Authorize(Roles = RoleName.SaPravomAdministracije)]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Preduzece preduzece = db.Preduzeces.Find(id);
			if (preduzece == null)
			{
				return HttpNotFound();
			}
			return View(preduzece);
		}

		// POST: Preduzeces/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.SaPravomAdministracije)]
		public ActionResult DeleteConfirmed(int id)
		{
			Preduzece preduzece = db.Preduzeces.Find(id);
			db.Preduzeces.Remove(preduzece);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[AllowAnonymous]
		public ActionResult Convert(int id)
		{
			//PdfConverter pdfConverter = new PdfConverter();
			//string url = collection["TxtUrl"];
			//byte[] pdf = pdfConverter.GetPdfBytesFromUrl(url);

			//FileResult fileResult = new FileContentResult(pdf, "application/pdf");
			//fileResult.FileDownloadName = "RenderedPage.pdf";

			//return fileResult;
			var fullUrl = this.Url.Action("Details", "Preduzeces", new { id }, this.Request.Url.Scheme);

			var converter = new HtmlToPdf();
			var doc = converter.ConvertUrl(fullUrl);
			doc.Save(System.Web.HttpContext.Current.Response, true, "test.pdf");
			doc.Close();

			return null;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		//[HttpPost]
		//public ActionResult Convert(FormCollection collection)
		//{
		//	// read parameters from the webpage
		//	string url = collection["TxtUrl"];

		//	string pdf_page_size = collection["DdlPageSize"];
		//	PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);

		//	string pdf_orientation = collection["DdlPageOrientation"];
		//	PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(
		//		typeof(PdfPageOrientation), pdf_orientation, true);

		//	int webPageWidth = 1024;
		//	try
		//	{
		//		webPageWidth = System.Convert.ToInt32(collection["TxtWidth"]);
		//	}
		//	catch { }

		//	int webPageHeight = 0;
		//	try
		//	{
		//		webPageHeight = System.Convert.ToInt32(collection["TxtHeight"]);
		//	}
		//	catch { }

		//	// instantiate a html to pdf converter object
		//	HtmlToPdf converter = new HtmlToPdf();

		//	// set converter options
		//	converter.Options.PdfPageSize = pageSize;
		//	converter.Options.PdfPageOrientation = pdfOrientation;
		//	converter.Options.WebPageWidth = webPageWidth;
		//	converter.Options.WebPageHeight = webPageHeight;

		//	// create a new pdf document converting an url
		//	PdfDocument doc = converter.ConvertUrl(url);

		//	// save pdf document
		//	byte[] pdf = doc.Save();

		//	// close pdf document
		//	doc.Close();

		//	// return resulted pdf document
		//	FileResult fileResult = new FileContentResult(pdf, "application/pdf");
		//	fileResult.FileDownloadName = "Document.pdf";
		//	return fileResult;
		//}
	}
}
