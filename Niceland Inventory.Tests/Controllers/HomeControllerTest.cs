using Microsoft.VisualStudio.TestTools.UnitTesting;
using Niceland_Inventory;
using Niceland_Inventory.Controllers;
using System.Web.Mvc;

namespace Niceland_Inventory.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
