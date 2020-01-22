using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistarPreduzecaV11._0.Models
{
	public class Preduzece
	{
		public int Id { get; set; }

		public string RegNaziv { get; set; }

		public string RegAdresa { get; set; }

		public string Opstina { get; set; }

		public int PostanskiBroj { get; set; }

		public string MaticniBroj { get; set; }

		public string PIB { get; set; }

		public int SifraDelatnosti { get; set; }

		public string OpisDelatnosti { get; set; }

		public string BrojRacuna { get; set; }

		public string WebStranica { get; set; }

		public ICollection<KontaktOsoba> KontaktOsobe { get; set; }

		public string Pecat { get; set; }

		public string Beleska { get; set; }
	}
}