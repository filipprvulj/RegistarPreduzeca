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

		[Display(Name = "Registrovani naziv preduzeća")]
		[Required(ErrorMessage = "Morate uneti naziv")]
		[StringLength(50, ErrorMessage = "Možete uneti najviše 50 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+\s?[a-zA-Z]*$",ErrorMessage = "Možete uneti samo slova")]
		public string RegNaziv { get; set; }

		[Required(ErrorMessage = "Morate uneti adresu")]
		[Display(Name = "Registrovana adresa preduzeća")]
		[StringLength(100, ErrorMessage = "Možete uneti najviše 100 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+\s?[a-zA-Z]*\s?\d{1,3}$", ErrorMessage = "Adresa nije dobrog formata")]
		public string RegAdresa { get; set; }

		[Display(Name = "Opština")]
		[Required(ErrorMessage ="Morate uneti opštinu")]
		[StringLength(100, ErrorMessage = "Možete uneti maksimalno 100 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+\s?[a-zA-Z]*$",ErrorMessage = "Možete uneti samo slova")]
		public string Opstina { get; set; }


		[Display(Name = "Poštaniski broj")]
		[Required(ErrorMessage = "Morate uneti poštanski broj")]
		[RegularExpression(@"\d{5}", ErrorMessage = "Poštanski broj mora imati tačno 5 cifara")]
		public int PostanskiBroj { get; set; }

		[Display(Name = "Matični broj")]
		[Required(ErrorMessage = "Morate uneti matični broj")]
		[RegularExpression(@"\d{8}", ErrorMessage = "Uneta vrednost mora biti broj i sadržati tačno 8 cifara")]
		public string MaticniBroj { get; set; }

		[Required(ErrorMessage = "Morate uneti PIB")]
		[RegularExpression(@"\d{10}", ErrorMessage = "PIB mora sadržati tačno 10 cifara")]
		public string PIB { get; set; }

		[Display(Name = "Šifra delatnosti")]
		[Required(ErrorMessage = "Morate uneti šifru delatnosti")]
		[RegularExpression(@"\d{5,10}", ErrorMessage = "Šifra delatnosti može imati između 5 i 10 cifara")]
		public int SifraDelatnosti { get; set; }

		[Display(Name = "Opis delatnosti")]
		[Required(ErrorMessage = "Morate uneti opis delatnosti")]
		[StringLength(80, ErrorMessage ="Opis delatnosti može imati maksimalno 80 karaktera")]
		[RegularExpression(@"^[a-zA-Z]+\s?[a-zA-Z]*$", ErrorMessage = "Možete uneti samo slova")]
		public string OpisDelatnosti { get; set; }

		[Display(Name = "Broj računa")]
		[Required(ErrorMessage = "Morate uneti broj računa")]
		[RegularExpression(@"\d{18}",ErrorMessage = "Broj računa mora imati tačno 18 cifara")]
		public string BrojRacuna { get; set; }

		[Display(Name = "Internet stranica")]
		[StringLength(255 ,ErrorMessage = "Prekoračili ste dozvoljeni broj karaktera")]
		public string WebStranica { get; set; }

		public ICollection<KontaktOsoba> KontaktOsobe { get; set; }

		[Display(Name = "Pečat")]
		public string Pecat { get; set; }

		[Display(Name = "Beleška")]
		[Required(ErrorMessage = "Morate uneti belešku")]
		[StringLength(255, ErrorMessage = "Prekoračili ste dozvoljeni broj karaktera")]
		public string Beleska { get; set; }
	}
}