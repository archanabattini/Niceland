using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ChristmasQualityValueIncreaseDecoratorTest
    {
        ChristmasQualityValueIncreaseDecorator mock;

        [SetUp]
        public void setup()
        {
            mock = new ChristmasQualityValueIncreaseDecorator(new ItemQualityValueIncreaseCalculator(new Item("Christmas Crackers")));
        }

        [Test]
        public void UpdateValue_Test1()
        {
            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(-1, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.GetQualityValueFactor());
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test2()
        {
            mock.InventoryItem.SellValue = 12;
            mock.InventoryItem.QualityValue = 12;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(1, mock.GetQualityValueChange());

            Assert.AreEqual(11, mock.InventoryItem.SellValue);
            Assert.AreEqual(13, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test3()
        {
            mock.InventoryItem.SellValue = 11;
            mock.InventoryItem.QualityValue = 13;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(2, mock.GetQualityValueChange());

            Assert.AreEqual(10, mock.InventoryItem.SellValue);
            Assert.AreEqual(15, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test4()
        {
            mock.InventoryItem.SellValue = 10;
            mock.InventoryItem.QualityValue = 15;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(2, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(2, mock.GetQualityValueChange());

            Assert.AreEqual(9, mock.InventoryItem.SellValue);
            Assert.AreEqual(17, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test5()
        {
            mock.InventoryItem.SellValue = 7;
            mock.InventoryItem.QualityValue = 15;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(2, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(2, mock.GetQualityValueChange());

            Assert.AreEqual(6, mock.InventoryItem.SellValue);
            Assert.AreEqual(17, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test6()
        {
            mock.InventoryItem.SellValue = 6;
            mock.InventoryItem.QualityValue = 17;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(2, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            Assert.AreEqual(5, mock.InventoryItem.SellValue);
            Assert.AreEqual(20, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test7()
        {
            mock.InventoryItem.SellValue = 5;
            mock.InventoryItem.QualityValue = 20;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            Assert.AreEqual(4, mock.InventoryItem.SellValue);
            Assert.AreEqual(23, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test8()
        {
            mock.InventoryItem.SellValue = 1;
            mock.InventoryItem.QualityValue = 20;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(23, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test9()
        {
            mock.InventoryItem.SellValue = 0;
            mock.InventoryItem.QualityValue = 23;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(0, mock.GetQualityValueFactor());
            Assert.AreEqual(0, mock.GetQualityValueChange());

            Assert.AreEqual(-1, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test10()
        {
            mock.InventoryItem.SellValue = 1;
            mock.InventoryItem.QualityValue = 50;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(3, mock.GetQualityValueChange());

            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(50, mock.InventoryItem.QualityValue);
        }
    }
}
