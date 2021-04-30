using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ItemValueDefaultCalculatorTest
    {
        ItemValueDefaultCalculator mock;

        [SetUp]
        public void setup()
        {
            mock = new ItemValueDefaultCalculator(new Item("Aged Brie"));
        }

        [Test]
        public void UpdateSellValueFactor_Test()
        {
            Assert.AreEqual(1, mock.SellValueFactor);

            mock.UpdateSellValueFactor();

            Assert.AreEqual(1, mock.SellValueFactor);
        }

        [Test]
        public void UpdateSellValueChange_Test()
        {
            Assert.AreEqual(1, mock.SellValueChange);

            mock.UpdateSellValueChange();

            Assert.AreEqual(-1, mock.SellValueChange);
        }

        [Test]
        public void UpdateQualityValueFactor_Test()
        {
            Assert.AreEqual(1, mock.QualityValueFactor);

            mock.UpdateQualityValueFactor();

            if (mock.InventoryItem.SellValue >= 0)
            {
                Assert.AreEqual(1, mock.QualityValueFactor);
            } else
            {
                Assert.AreEqual(2, mock.QualityValueFactor);
            }
        }

        [Test]
        public void UpdateQualityValueChange_Test()
        {
            Assert.AreEqual(1, mock.QualityValueChange);

            mock.UpdateQualityValueChange();

            Assert.AreEqual(-1, mock.QualityValueChange);
        }
    }
}
