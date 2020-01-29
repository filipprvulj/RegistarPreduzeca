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
		[Required(ErrorMessage = "Morate uneti tip")]
		[StringLength(25, ErrorMessage = "Možete uneti maksimalno 25 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="Možete uneti samo slova")]
		public string OznakaTipa { get; set; }

		[Display(Name = "Broj telefona")]
		[Required(ErrorMessage = "Morate uneti broj telefona")]
		[RegularExpression(@"\d{9,10}", ErrorMessage ="Uneti broj mora sadržati tačno 9 ili 10 cifara")]
		public string BrojTelefona { get; set; }

		[Display(Name = "Broj lokala")]
		[RegularExpression(@"\d+",ErrorMessage = "Možete uneti samo broj")]
		public int? Lokal { get; set; }

		[Display(Name = "Kontakt osoba")]
		[Required(ErrorMessage = "Morate vezati telefon sa osobom")]
		public int KontaktOsobaId { get; set; }

		public KontaktOsoba KontaktOsoba { get; set; }
	}
}