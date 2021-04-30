using Moq;
using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ValueCalculatorTest
    {
        Mock<ValueCalculator> mock;

        [OneTimeSetUp]
        public void Setup()
        {
            mock = new Mock<ValueCalculator>(MockBehavior.Strict, new object[] { new Item("Aged Brie") });
            mock.CallBase = true;
        }

        [SetUp]
        public void reset()
        {
            mock.Setup(x => x.GetSellValueChange()).Returns(-1);
            mock.Setup(x => x.GetSellValueFactor()).Returns(1);
            mock.Setup(x => x.GetQualityValueChange()).Returns(-1);
            mock.Setup(x => x.GetQualityValueFactor()).Returns(1);
        }

        [Test]
        public void updateValue_Test1()
        {
            mock.Object.InventoryItem.SellValue = 2;
            mock.Object.InventoryItem.QualityValue = 5;

            mock.Object.UpdateValue();

            Assert.AreEqual(1, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(4, mock.Object.InventoryItem.QualityValue);
        }

        [Test]
        public void updateValue_Test2()
        {
            mock.Setup(x => x.GetSellValueFactor()).Returns(2);

            mock.Object.InventoryItem.SellValue = 2;
            mock.Object.InventoryItem.QualityValue = 5;

            mock.Object.UpdateValue();

            Assert.AreEqual(0, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(4, mock.Object.InventoryItem.QualityValue);
        }

        [Test]
        public void updateValue_Test3()
        {
            mock.Setup(x => x.GetQualityValueChange()).Returns(-2);
            mock.Setup(x => x.GetQualityValueFactor()).Returns(2);

            mock.Object.InventoryItem.SellValue = 2;
            mock.Object.InventoryItem.QualityValue = 5;

            mock.Object.UpdateValue();

            Assert.AreEqual(1, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(1, mock.Object.InventoryItem.QualityValue);
        }

        [Test]
        public void updateValue_Days_Test1()
        {
            mock.Object.InventoryItem.SellValue = 5;
            mock.Object.InventoryItem.QualityValue = 10;

            mock.Object.UpdateValue(3);

            Assert.AreEqual(2, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(7, mock.Object.InventoryItem.QualityValue);
        }

        [Test]
        public void updateValue_Days_Test2()
        {
            mock.Setup(x => x.GetSellValueFactor()).Returns(2);

            mock.Object.InventoryItem.SellValue = 5;
            mock.Object.InventoryItem.QualityValue = 10;

            mock.Object.UpdateValue(3);

            Assert.AreEqual(-1, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(7, mock.Object.InventoryItem.QualityValue);
        }

        [Test]
        public void updateValue_Days_Test3()
        {
            mock.Setup(x => x.GetQualityValueChange()).Returns(-2);
            mock.Setup(x => x.GetQualityValueFactor()).Returns(2);

            mock.Object.InventoryItem.SellValue = 5;
            mock.Object.InventoryItem.QualityValue = 10;

            mock.Object.UpdateValue(3);

            Assert.AreEqual(2, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.Object.InventoryItem.QualityValue);
        }
    }
}
