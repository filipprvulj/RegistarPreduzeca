using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistarPreduzecaV11._0.Models
{
	public class KontaktOsoba
	{
		public int Id { get; set; }

		public string Ime { get; set; }

		public string Prezime { get; set; }

		[Display(Name = "Radno mesto")]
		public string RadnoMesto { get; set; }

		public ICollection<KontaktTelefon> KontaktTelefoni { get; set; }

		public ICollection<Email> Emailovi { get; set; }

		public int PreduzeceId { get; set; }

		public Preduzece Preduzece { get; set; }
	}
}