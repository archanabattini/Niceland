using Moq;
using Niceland_Inventory.Repository;
using Niceland_Inventory.Services;
using Niceland_Inventory.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ItemValueServiceTest
    {
        IItemValueService service;

        [OneTimeSetUp]
        public void create()
        {
            Item item1 = new Item("Aged Brie");
            Item item2 = new Item("Christmas Crackers");

            Mock<IItemsRepository> itemsRepoMock = new Mock<IItemsRepository>(MockBehavior.Default);
            itemsRepoMock.Setup(x => x.GetItem("Aged Brie")).Returns(item1);
            itemsRepoMock.Setup(x => x.GetItem("Christmas Crackers")).Returns(item2);

            Mock<IItemValueCalculatorFactory> itemsValueFactoryMock = new Mock<IItemValueCalculatorFactory>(MockBehavior.Default);
            itemsValueFactoryMock.Setup(x => x.CreateValueCalculator(item1)).Returns(
                new ItemQualityValueIncreaseCalculator(item1)
             );
            itemsValueFactoryMock.Setup(x => x.CreateValueCalculator(item2)).Returns(
                new ChristmasQualityValueIncreaseDecorator(new ItemQualityValueIncreaseCalculator(item1))
             );

            service = new ItemValueService(itemsRepoMock.Object, itemsValueFactoryMock.Object);
        }

        [Test]
        public void CalculateInventoryValueChange_Test1()
        {
            List<string> items = new List<string> { "Aged Brie 2 2" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(items.Count, updatedItems.Count);
            Assert.AreNotEqual("INVALID INPUT FORMAT", updatedItems[0]);
            Assert.AreNotEqual("NO SUCH ITEM", updatedItems[0]);
        }

        [Test]
        public void CalculateInventoryValueChange_Test2()
        {
            List<string> items = new List<string>();

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(0, updatedItems.Count);
        }

        [Test]
        public void CalculateInventoryValueChange_Test3()
        {
            List<string> items = null;

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNull(updatedItems);
        }

        [Test]
        public void CalculateInventoryValueChange_Test4()
        {
            List<string> items = new List<string> { "Aged Brie 2" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(1, updatedItems.Count);
            Assert.AreEqual("INVALID INPUT FORMAT", updatedItems[0]);
        }
        public void CalculateInventoryValueChange_Test5()
        {

            List<string> items = new List<string> { "Aged Brie 2 A" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(1, updatedItems.Count);
            Assert.AreEqual("INVALID INPUT FORMAT", updatedItems[0]);
        }
        public void CalculateInventoryValueChange_Test6()
        {

            List<string> items = new List<string> { "Aged Brie B 2" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(1, updatedItems.Count);
            Assert.AreEqual("INVALID INPUT FORMAT", updatedItems[0]);
        }

        public void CalculateInventoryValueChange_Test7()
        {
            List<string> items = new List<string> { "Aged Brie" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(1, updatedItems.Count);
            Assert.AreEqual("INVALID INPUT FORMAT", updatedItems[0]);

        }

        public void CalculateInventoryValueChange_Test8()
        {
            List<string> items = new List<string> { "Aged Brie B B" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(1, updatedItems.Count);
            Assert.AreEqual("INVALID INPUT FORMAT", updatedItems[0]);
        }

        public void CalculateInventoryValueChange_Test9()
        {
            List<string> items = new List<string> { "INVALID ITEM 2 2" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(1, updatedItems.Count);
            Assert.AreEqual("NO SUCH ITEM", updatedItems[0]);
        }

        [Test]
        public void CalculateInventoryValueChange_Test10()
        {
            List<string> items = new List<string> { "Aged Brie 1 1", "Christmas Crackers -1 2" };

            List<string> updatedItems = service.CalculateInventoryValueChange(items);

            Assert.IsNotNull(updatedItems);
            Assert.AreEqual(items.Count, updatedItems.Count);
            Assert.AreNotEqual("INVALID INPUT FORMAT", updatedItems[0]);
            Assert.AreNotEqual("NO SUCH ITEM", updatedItems[0]);
            Assert.AreNotEqual("INVALID INPUT FORMAT", updatedItems[1]);
            Assert.AreNotEqual("NO SUCH ITEM", updatedItems[1]);
        }
    }
}
