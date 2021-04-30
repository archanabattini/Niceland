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
            mock.Setup(x => x.UpdateSellValueChange()).Callback(() =>
            {
                mock.Object.SellValueChange = -1;
            }).Verifiable();
            mock.Setup(x => x.UpdateSellValueFactor()).Callback(() =>
            {
                mock.Object.SellValueFactor = 1;
            }).Verifiable();
            mock.Setup(x => x.UpdateQualityValueChange()).Callback(() =>
            {
                mock.Object.QualityValueChange = -1;
            }).Verifiable();
            mock.Setup(x => x.UpdateQualityValueFactor()).Callback(() =>
            {
                mock.Object.QualityValueFactor = 1;
            }).Verifiable();

            mock.Object.InventoryItem.SellValue = 2;
            mock.Object.InventoryItem.QualityValue = 5;
        }

        [Test]
        public void updateValue_Test1()
        {
            mock.Object.UpdateValue();

            Assert.AreEqual(1, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(4, mock.Object.InventoryItem.QualityValue);
        }

        [Test]
        public void updateValue_Test2()
        {
            mock.Setup(x => x.UpdateSellValueFactor()).Callback(() =>
            {
                mock.Object.SellValueFactor = 2;
            }).Verifiable();

            mock.Object.UpdateValue();

            Assert.AreEqual(0, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(4, mock.Object.InventoryItem.QualityValue);
        }

        [Test]
        public void updateValue_Test3()
        {
            mock.Setup(x => x.UpdateQualityValueChange()).Callback(() =>
            {
                mock.Object.QualityValueChange = -2;
            }).Verifiable();
            mock.Setup(x => x.UpdateQualityValueFactor()).Callback(() =>
            {
                mock.Object.QualityValueFactor = 2;
            }).Verifiable();

            mock.Object.UpdateValue();

            Assert.AreEqual(1, mock.Object.InventoryItem.SellValue);
            Assert.AreEqual(1, mock.Object.InventoryItem.QualityValue);
        }
    }
}
