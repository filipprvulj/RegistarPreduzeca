using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using RegistarPreduzecaV11._0.Models;

namespace RegistarPreduzecaV11._0.viewModel
{
    public class AdminCreateUserViewModel
    {
        public RegisterViewModel Register { get; set; }

        public IEnumerable<IdentityRole> Uloge { get; set; }

        public string UlogaId { get; set; }
    }
}