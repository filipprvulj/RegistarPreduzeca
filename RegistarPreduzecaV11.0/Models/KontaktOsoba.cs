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

		[Required(ErrorMessage = "Morate uneti ime")]
		[StringLength(30, ErrorMessage = "Možete uneti maksimalno 30 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Možete uneti samo slova")]
		public string Ime { get; set; }

		[Required(ErrorMessage = "Morate uneti prezime")]
		[StringLength(50, ErrorMessage = "Možete uneti maksimalno 50 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+$",ErrorMessage = "Možete uneti samo slova")]
		public string Prezime { get; set; }

		[Display(Name = "Radno mesto")]
		[Required(ErrorMessage = "Morate uneti radno mesto")]
		[StringLength(50, ErrorMessage = "Možete uneti maksimalno 50 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+$",ErrorMessage = "Možete uneti samo slova")]
		public string RadnoMesto { get; set; }

		public ICollection<KontaktTelefon> KontaktTelefoni { get; set; }

		public ICollection<Email> Emailovi { get; set; }

		[Display(Name = "Preduzeće")]
		[Required(ErrorMessage ="Morate vezati osobu za preduzeće")]
		public int PreduzeceId { get; set; }

		public Preduzece Preduzece { get; set; }
	}
}