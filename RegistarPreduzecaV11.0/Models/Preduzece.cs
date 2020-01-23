using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistarPreduzecaV11._0.Models
{
	public class Preduzece
	{
		public int Id { get; set; }

		[Display(Name = "Registrovani naziv")]
		public string RegNaziv { get; set; }

		[Display(Name = "Registrovana adresa")]
		public string RegAdresa { get; set; }

		[Display(Name = "Opština")]
		public string Opstina { get; set; }

		[Display(Name = "Poštaniski broj")]
		public int PostanskiBroj { get; set; }

		[Display(Name = "Matični broj")]
		public string MaticniBroj { get; set; }

		public string PIB { get; set; }

		[Display(Name = "Šifra delatnosti")]
		public int SifraDelatnosti { get; set; }

		[Display(Name = "Opis delatnosti")]
		public string OpisDelatnosti { get; set; }

		[Display(Name = "Broj računa")]
		public string BrojRacuna { get; set; }

		[Display(Name = "Internet stranica")]
		public string WebStranica { get; set; }

		public ICollection<KontaktOsoba> KontaktOsobe { get; set; }

		[Display(Name = "Pečat")]
		public string Pecat { get; set; }

		[Display(Name = "Beleška")]
		public string Beleska { get; set; }
	}
}