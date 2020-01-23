using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RegistarPreduzecaV11._0.Models
{
	public class KontaktTelefon
	{
		public int Id { get; set; }

		[Display(Name = "Tip")]
		public string OznakaTipa { get; set; }

		[Display(Name = "Broj telefona")]
		public string BrojTelefona { get; set; }

		public int Lokal { get; set; }

		public int KontaktOsobaId { get; set; }

		public KontaktOsoba KontaktOsoba { get; set; }
	}
}