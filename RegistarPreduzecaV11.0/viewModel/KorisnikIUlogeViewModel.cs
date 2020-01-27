using Microsoft.AspNet.Identity.EntityFramework;
using RegistarPreduzecaV11._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistarPreduzecaV11._0.viewModel
{
    public class KorisnikIUlogeViewModel
    {
        public ApplicationUser Korisnik { get; set; }
        public IEnumerable<IdentityRole> Uloge { get; set; }
    }
}