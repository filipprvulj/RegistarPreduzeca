using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistarPreduzecaV11._0.viewModel
{
    public class GrupaKorisnikaViewModel
    {
        public List<KorisnikViewModel> Korisnici { get; set; }
        public List<KorisnikViewModel> Moderatori { get; set; }
        public List<KorisnikViewModel> Admini { get; set; }
    }
}