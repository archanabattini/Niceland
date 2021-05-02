using Moq;
using Niceland_Inventory.Controllers;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Niceland_Inventory.Tests.Controllers
{
    [TestFixture]
    public class ItemsControllerTest
    {
        ItemsController controller;

        [OneTimeSetUp]
        public void Setup()
        {
            List<string> input = new List<string>();
            input.Add("Aged Brie 1 1");

            List<string> output = new List<string>();
            input.Add("Aged Brie 0 2");

            Mock<IItemValueService> mockService = new Mock<IItemValueService>(MockBehavior.Default);
            mockService.Setup(m => m.CalculateInventoryValueChange(input)).Returns(
                output
            );
            mockService.Setup(m => m.GetAllItems()).Returns(() =>
            {
                List<string> items = new List<string>();
                items.Add("Aged Brie");
                return items;
            });

            controller = new ItemsController(mockService.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/items/calc-inventory-value")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "items" } });
        }


        [Test]
        public void Get()
        {
            // Arrange


            // Act
            HttpResponseMessage response = controller.Get();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [Test]
        public void CalcInventoryValue()
        {
            List<string> itemsInput = new List<string>();

            HttpResponseMessage response = controller.CalcInventoryValue(itemsInput);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }


    }
}
