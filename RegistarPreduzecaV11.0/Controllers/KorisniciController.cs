using RegistarPreduzecaV11._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistarPreduzecaV11._0.viewModel;
namespace RegistarPreduzecaV11._0.Controllers
{
    [Authorize(Roles = RoleName.SaPravomAdministracije)]
    public class KorisniciController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Korisnici
        public ActionResult Index()
        {
            var roleAdmin = db.Roles.SingleOrDefault(r => r.Name == RoleName.SaPravomAdministracije);
            var admini = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(roleAdmin.Id)).ToList();
            var adminViewModel = admini.Select(admin => new KorisnikViewModel
            {
                Username = admin.UserName,
                Role = RoleName.SaPravomAdministracije
            }).ToList();


            var roleMod = db.Roles.SingleOrDefault(r => r.Name == RoleName.SaPravomUnosa);
            var moderatori = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(roleMod.Id)).ToList();
            var moderatorViewModel = moderatori.Select(moderator => new KorisnikViewModel
            {
                Username = moderator.UserName,
                Role = RoleName.SaPravomUnosa
            }).ToList();

            var roleKorisnik = db.Roles.SingleOrDefault(r => r.Name == RoleName.SaPravomPregleda);
            var korisnici = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(roleKorisnik.Id)).ToList();
            var korisnikViewModel = korisnici.Select(korisnik => new KorisnikViewModel
            {
                Username = korisnik.UserName,
                Role = RoleName.SaPravomPregleda
            }).ToList();

            var grupeKorisnika = new GrupaKorisnikaViewModel
            {
                Admini = adminViewModel,
                Moderatori = moderatorViewModel,
                Korisnici = korisnikViewModel
            };

            return View(grupeKorisnika);
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