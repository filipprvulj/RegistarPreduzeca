using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistarPreduzecaV11._0.Models;

namespace RegistarPreduzecaV11._0.viewModel
{
	public class PreduzeceViewModel
	{
		public Preduzece Preduzece { get; set; }
		public IEnumerable<KontaktOsoba> KontaktOsoba { get; set; }
	}
}