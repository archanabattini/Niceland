using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ItemQualityValueIncreaseCalculatorTest
    {
        ValueCalculator service;

        [SetUp]
        public void setup()
        {
            service = new ItemQualityValueIncreaseCalculator(new Item("Aged Brie"));
        }

        [Test]
        public void UpdateValue_Test1()
        {
            Assert.AreEqual(0, service.InventoryItem.SellValue);
            Assert.AreEqual(0, service.InventoryItem.QualityValue);

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(1, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(-1, service.InventoryItem.SellValue);
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(1, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test2()
        {
            service.InventoryItem.SellValue = 5;
            service.InventoryItem.QualityValue = 5;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(1, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(4, service.InventoryItem.SellValue);
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(6, service.InventoryItem.QualityValue);
        }
    }
}
