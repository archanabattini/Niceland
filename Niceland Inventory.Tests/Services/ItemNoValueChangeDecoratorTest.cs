using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ItemNoValueChangeDecoratorTest
    {
        ItemNoValueChangeDecorator mock;

        [SetUp]
        public void setup()
        {
            ItemValueDefaultCalculator calc1 = new ItemValueDefaultCalculator(new Item("Soap"));
            mock = new ItemNoValueChangeDecorator(calc1);
        }

        [Test]
        public void UpdateValueTest()
        {
            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);

            Assert.AreEqual(0, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(0, mock.GetQualityValueFactor());
            Assert.AreEqual(0, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.GetQualityValueFactor());
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);

            mock.InventoryItem.SellValue = 5;
            mock.InventoryItem.QualityValue = 5;

            Assert.AreEqual(0, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(0, mock.GetQualityValueFactor());
            Assert.AreEqual(0, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(5, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.GetQualityValueFactor());
            Assert.AreEqual(5, mock.InventoryItem.QualityValue);
        }
    }
}
