using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistarPreduzecaV11._0.Models
{
    public static class RoleName
    {
        public const string SaPravomUnosa = "SaPravomUnosa";
        public const string SaPravomAdministracije = "SaPravomAdministracije";
        public const string SaPravomUnosaIliAdministracije = SaPravomAdministracije + ", " + SaPravomUnosa;
    }
}