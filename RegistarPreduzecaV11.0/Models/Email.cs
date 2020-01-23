using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistarPreduzecaV11._0.Models
{
	public class Email
	{
		public int Id { get; set; }

		[Display(Name = "Tip")]
		public string OznakaTipa { get; set; }

		[Display(Name = "E-mail adresa")]
		public string EmailAdresa { get; set; }

		public int KontaktOsobaId { get; set; }

		public KontaktOsoba KontaktOsoba { get; set; }
	}
}