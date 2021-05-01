using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class FactoredQualityValueCalculatorTest
    {
        FactoredQualityValueCalculator mock;

        [SetUp]
        public void setup()
        {
            mock = new FactoredQualityValueCalculator(new Item("Fresh Item"), 2);
        }

        [Test]
        public void UpdateValue_Test1()
        {
            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(2, mock.GetQualityValueFactor());
            Assert.AreEqual(-1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(-1, mock.InventoryItem.SellValue);
            Assert.AreEqual(2, mock.GetQualityValueFactor());
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test2()
        {
            mock.InventoryItem.SellValue = 5;
            mock.InventoryItem.QualityValue = 5;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(2, mock.GetQualityValueFactor());
            Assert.AreEqual(-1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(4, mock.InventoryItem.SellValue);
            Assert.AreEqual(2, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.InventoryItem.QualityValue);
        }
    }
}
