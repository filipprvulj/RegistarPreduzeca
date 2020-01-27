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
		[StringLength(50, ErrorMessage = "Možete uneti maksimalno 50 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Možete uneti samo slova")]
		[Required(ErrorMessage = "Morate uneti tip")]
		public string OznakaTipa { get; set; }

		[Display(Name = "E-mail adresa")]
		[EmailAddress(ErrorMessage = "Uneta adresa nije dobrog formata")]
		[Required(ErrorMessage = "Morate uneti e-mail adresu")]
		public string EmailAdresa { get; set; }

		[Display(Name = "Kontakt osoba")]
		[Required(ErrorMessage = "Morate vezati e-mail adresu za osobu")]
		public int KontaktOsobaId { get; set; }

		public KontaktOsoba KontaktOsoba { get; set; }
	}
}