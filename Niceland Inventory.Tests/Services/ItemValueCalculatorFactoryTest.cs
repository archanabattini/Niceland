using Niceland_Inventory.Models;
using Niceland_Inventory.Services;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Services
{
    [TestFixture]
    public class ItemValueCalculatorFactoryTest
    {
        IItemValueCalculatorFactory factory;

        [OneTimeSetUp]
        public void SetUp()
        {
            factory = new ItemValueCalculatorFactory();
        }

        [Test]
        public void CreateValueCalculator_Test1()
        {
            IValueCalculator calc = factory.CreateValueCalculator(new Item("Aged Brie"));

            Assert.IsInstanceOf<ItemQualityValueIncreaseCalculator>(calc);
        }

        [Test]
        public void CreateValueCalculator_Test2()
        {
            IValueCalculator calc = factory.CreateValueCalculator(new Item("Christmas Crackers"));

            Assert.IsInstanceOf<ChristmasQualityValueIncreaseDecorator>(calc);
        }

        [Test]
        public void CreateValueCalculator_Test3()
        {
            IValueCalculator calc = factory.CreateValueCalculator(new Item("Fresh Item"));

            Assert.IsInstanceOf<FactoredQualityValueCalculator>(calc);
        }

        [Test]
        public void CreateValueCalculator_Test4()
        {
            IValueCalculator calc = factory.CreateValueCalculator(new Item("Frozen Item"));

            Assert.IsInstanceOf<ItemValueDefaultCalculator>(calc);
        }

        [Test]
        public void CreateValueCalculator_Test5()
        {
            IValueCalculator calc = factory.CreateValueCalculator(new Item("Soap"));

            Assert.IsInstanceOf<ItemNoValueChangeCalculator>(calc);
        }

        [Test]
        public void CreateValueCalculator_Test6()
        {
            IValueCalculator calc = factory.CreateValueCalculator(null);

            Assert.IsNull(calc);
        }
    }
}
