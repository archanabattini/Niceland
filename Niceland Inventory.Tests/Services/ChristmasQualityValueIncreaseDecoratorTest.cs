using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ChristmasQualityValueIncreaseDecoratorTest
    {
        ValueCalculator service;

        [SetUp]
        public void setup()
        {
            service = new ChristmasQualityValueIncreaseDecorator(new ItemQualityValueIncreaseCalculator(new Item("Christmas Crackers")));
        }

        [Test]
        public void UpdateValue_Test1()
        {
            Assert.AreEqual(0, service.InventoryItem.SellValue);
            Assert.AreEqual(0, service.InventoryItem.QualityValue);

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(-1, service.InventoryItem.SellValue);
            Assert.AreEqual(0, service.GetQualityValueFactor());
            Assert.AreEqual(0, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test2()
        {
            service.InventoryItem.SellValue = 12;
            service.InventoryItem.QualityValue = 12;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(1, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(1, service.GetQualityValueChange());

            Assert.AreEqual(11, service.InventoryItem.SellValue);
            Assert.AreEqual(13, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test3()
        {
            service.InventoryItem.SellValue = 11;
            service.InventoryItem.QualityValue = 13;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(1, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(2, service.GetQualityValueChange());

            Assert.AreEqual(10, service.InventoryItem.SellValue);
            Assert.AreEqual(15, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test4()
        {
            service.InventoryItem.SellValue = 10;
            service.InventoryItem.QualityValue = 15;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(2, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(2, service.GetQualityValueChange());

            Assert.AreEqual(9, service.InventoryItem.SellValue);
            Assert.AreEqual(17, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test5()
        {
            service.InventoryItem.SellValue = 7;
            service.InventoryItem.QualityValue = 15;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(2, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(2, service.GetQualityValueChange());

            Assert.AreEqual(6, service.InventoryItem.SellValue);
            Assert.AreEqual(17, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test6()
        {
            service.InventoryItem.SellValue = 6;
            service.InventoryItem.QualityValue = 17;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(2, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            Assert.AreEqual(5, service.InventoryItem.SellValue);
            Assert.AreEqual(20, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test7()
        {
            service.InventoryItem.SellValue = 5;
            service.InventoryItem.QualityValue = 20;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            Assert.AreEqual(4, service.InventoryItem.SellValue);
            Assert.AreEqual(23, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test8()
        {
            service.InventoryItem.SellValue = 1;
            service.InventoryItem.QualityValue = 20;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            Assert.AreEqual(0, service.InventoryItem.SellValue);
            Assert.AreEqual(23, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test9()
        {
            service.InventoryItem.SellValue = 0;
            service.InventoryItem.QualityValue = 23;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(0, service.GetQualityValueFactor());
            Assert.AreEqual(0, service.GetQualityValueChange());

            Assert.AreEqual(-1, service.InventoryItem.SellValue);
            Assert.AreEqual(0, service.InventoryItem.QualityValue);
        }

        [Test]
        public void UpdateValue_Test10()
        {
            service.InventoryItem.SellValue = 1;
            service.InventoryItem.QualityValue = 50;

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            service.UpdateValue();

            Assert.AreEqual(1, service.GetSellValueFactor());
            Assert.AreEqual(-1, service.GetSellValueChange());
            Assert.AreEqual(1, service.GetQualityValueFactor());
            Assert.AreEqual(3, service.GetQualityValueChange());

            Assert.AreEqual(0, service.InventoryItem.SellValue);
            Assert.AreEqual(50, service.InventoryItem.QualityValue);
        }
    }
}
