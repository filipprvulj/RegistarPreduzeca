using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistarPreduzecaV11._0.Controllers;
using RegistarPreduzecaV11._0.Models;

namespace RegistarPreduzecaV11._0.Tests.Controllers
{
    [TestClass]
    public class KontaktTelefonsControllerTest
    {
        [TestMethod]
        public void Details()

        {

            // Arrange

            KontaktTelefonsController controller = new KontaktTelefonsController();





            // Act

            ViewResult result = controller.Details(1) as ViewResult;





            // Assert

            Assert.AreEqual("Details", result.ViewName);

        }







        [TestMethod]
        public void Details_CheckingDataType()

        {

            // Arrange



            KontaktTelefonsController controller = new KontaktTelefonsController();





            // Act

            ViewResult result = controller.Details(2) as ViewResult;

            var kt = (KontaktTelefon)result.ViewData.Model;



            // Assert

            Assert.IsInstanceOfType(kt.GetType(), typeof(KontaktTelefon));

        }
    }
}
