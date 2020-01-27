using RegistarPreduzecaV11._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistarPreduzecaV11._0.viewModel;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

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

        public ActionResult Create()
        {
            var viewModel = new AdminCreateUserViewModel
            {
                Uloge = db.Roles.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(AdminCreateUserViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            { 
                var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = new ApplicationUser
                {
                    Email = viewModel.Register.Email,
                    UserName = viewModel.Register.Email
                };
                var result = userManager.Create(user, viewModel.Register.Password);
                if (result.Succeeded)
                {
                    var role = db.Roles.SingleOrDefault(r => r.Id == viewModel.UlogaId).Name;

                    userManager.AddToRole(user.Id, role);

                    return RedirectToAction("Index", "Korisnici");
                }
            }
            return View(viewModel);
        }


        public ActionResult Delete(string userName)
        {
            var user = db.Users.SingleOrDefault(c => c.UserName == userName);
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ChangeRoles(string username)
        {
            var user = db.Users.SingleOrDefault(u => u.UserName == username);
            var roles = db.Roles.ToList();
          
            var userRolesViewModel = new KorisnikIUlogeViewModel
            {
                Korisnik = user,
                Uloge = roles
            };

            return View("ChangeRolesForm", userRolesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeRole(KorisnikIUlogeViewModel viewModel, string role)
        {
            var korisnikUsername = viewModel.Korisnik.UserName;
            var korisnik = db.Users.SingleOrDefault(u => u.UserName == korisnikUsername);
            var korisnikRoleId = korisnik.Roles.SingleOrDefault().RoleId;
            var korisnikRoleName = db.Roles.SingleOrDefault(r => r.Id == korisnikRoleId).Name;

        
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            userManager.RemoveFromRole(korisnik.Id, korisnikRoleName);

            var korisnikRoleNameNovi = db.Roles.SingleOrDefault(r => r.Id == role).Name;
        
            userManager.AddToRole(korisnik.Id, korisnikRoleNameNovi);

            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(string user)
        {
            var korisnik = db.Users.SingleOrDefault(u => u.UserName == user);

            return View(korisnik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordConfirm(string UserName, string password) 
        {
            var korisnik = db.Users.SingleOrDefault(u => u.UserName == UserName);

            
                var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                
                string resetToken = userManager.GeneratePasswordResetToken(korisnik.Id);

                var result = userManager.ResetPassword(korisnik.Id, resetToken, password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                   
                    ModelState.AddModelError("Error", "Password mora sadržati jedno veliko slovo, jedan broj i jedan specijalni karakter i mora imati minimum 6 karaktera");
                    
                    return View("ResetPassword", korisnik);
                }
            
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