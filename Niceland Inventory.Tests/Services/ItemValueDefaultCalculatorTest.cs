﻿using Niceland_Inventory.Models;
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
            mock = new ItemValueDefaultCalculator(new Item("Frozen Item"));
        }

        [Test]
        public void UpdateValueTest()
        {
            Assert.AreEqual(0, mock.InventoryItem.SellValue);
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(-1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(-1, mock.InventoryItem.SellValue);
            Assert.AreEqual(2, mock.GetQualityValueFactor());
            Assert.AreEqual(0, mock.InventoryItem.QualityValue);

            mock.InventoryItem.SellValue = 5;
            mock.InventoryItem.QualityValue = 5;

            Assert.AreEqual(1, mock.GetSellValueFactor());
            Assert.AreEqual(-1, mock.GetSellValueChange());
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(-1, mock.GetQualityValueChange());

            mock.UpdateValue();

            Assert.AreEqual(4, mock.InventoryItem.SellValue);
            Assert.AreEqual(1, mock.GetQualityValueFactor());
            Assert.AreEqual(4, mock.InventoryItem.QualityValue);
        }
    }
}
