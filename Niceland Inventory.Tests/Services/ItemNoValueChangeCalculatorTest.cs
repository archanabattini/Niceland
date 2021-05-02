using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ItemNoValueChangeCalculatorTest
    {
        ValueCalculator service;

        [SetUp]
        public void setup()
        {
            service = new ItemNoValueChangeCalculator(new Item("Soap"));
        }

        [Test]
        public void UpdateValue_Test1()
        {
            Assert.AreEqual(0, service.InventoryItem.SellValue);
            Assert.AreEqual(0, service.InventoryItem.QualityValue);

            Assert.AreEqual(0, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(0, service.GetQualityValueFactor());
            Assert.AreEqual(0, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(0, service.InventoryItem.SellValue);
            Assert.AreEqual(0, service.GetQualityValueFactor());
            Assert.AreEqual(0, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test2()
        {
            service.InventoryItem.SellValue = 5;
            service.InventoryItem.QualityValue = 5;

            Assert.AreEqual(0, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(0, service.GetQualityValueFactor());
            Assert.AreEqual(0, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(5, service.InventoryItem.SellValue);
            Assert.AreEqual(0, service.GetQualityValueFactor());
            Assert.AreEqual(5, service.InventoryItem.QualityValue);
        }
    }
}
