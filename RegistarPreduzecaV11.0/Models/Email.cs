using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistarPreduzecaV11._0.Models
{
	public class Email
	{
		public int Id { get; set; }

		public string OznakaTipa { get; set; }

		public string EmailAdresa { get; set; }

		public int KontaktOsobaId { get; set; }

		public KontaktOsoba KontaktOsoba { get; set; }
	}
}