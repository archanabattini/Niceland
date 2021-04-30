using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ItemQualityValueIncreaseDecoratorTest
    {
        ItemQualityValueIncreaseDecorator mock;

        [SetUp]
        public void setup()
        {
            ItemValueDefaultCalculator calc1 = new ItemValueDefaultCalculator(new Item("Aged Brie"));
            mock = new ItemQualityValueIncreaseDecorator(calc1);
        }

        [Test]
        public void UpdateValueTest()
        {
            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(-1, mock.InventoryItem.SellValue);
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(1, mock.InventoryItem.QualityValue);

            mock.InventoryItem.SellValue = 5;
            mock.InventoryItem.QualityValue = 5;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(4, mock.InventoryItem.SellValue);
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(6, mock.InventoryItem.QualityValue);
        }
    }
}
