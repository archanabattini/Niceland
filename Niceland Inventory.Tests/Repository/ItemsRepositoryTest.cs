using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niceland_Inventory.Models;
using Niceland_Inventory.Repository;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Niceland_Inventory.Tests.Repository
{
    [TestFixture]
    public class ItemsRepositoryTest
    {
        IItemsRepository repository;

        [OneTimeSetUp]
        public void Setup()
        {
            repository = new ItemsRepository();
        }

        [Test]
        public void GetAll()
        {
            List<string> result = repository.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());

            Assert.AreEqual("Aged Brie", result.ElementAt(0));
            Assert.AreEqual("Christmas Crackers", result.ElementAt(1));
            Assert.AreEqual("Fresh Item", result.ElementAt(2));
            Assert.AreEqual("Frozen Item", result.ElementAt(3));
            Assert.AreEqual("Soap", result.ElementAt(4));

        }

        [Test]
        public void GetItem_Test1()
        {
            Item item = repository.GetItem("");
            Assert.IsNull(item);
        }

        [Test]
        public void GetItem_Test2()
        {
            Item abItem = repository.GetItem("Aged Brie");
            Assert.IsNotNull(abItem);
            Assert.AreEqual(0, abItem.SellValue);
            Assert.AreEqual(0, abItem.QualityValue);
        }

        [Test]
        public void GetItem_Test3()
        {
            Item ccItem = repository.GetItem("Christmas Crackers");
            Assert.IsNotNull(ccItem);
            Assert.AreEqual(0, ccItem.SellValue);
            Assert.AreEqual(0, ccItem.QualityValue);
        }

        [Test]
        public void GetItem_Test4()
        {
            Item fiItem = repository.GetItem("Fresh Item");
            Assert.IsNotNull(fiItem);
            Assert.AreEqual(0, fiItem.SellValue);
            Assert.AreEqual(0, fiItem.QualityValue);
        }

        [Test]
        public void GetItem_Test5()
        {
            Item fzItem = repository.GetItem("Frozen Item");
            Assert.IsNotNull(fzItem);
            Assert.AreEqual(0, fzItem.SellValue);
            Assert.AreEqual(0, fzItem.QualityValue);
        }

        [Test]
        public void GetItem_Test6()
        {
            Item spItem = repository.GetItem("Soap");
            Assert.IsNotNull(spItem);
            Assert.AreEqual(0, spItem.SellValue);
            Assert.AreEqual(0, spItem.QualityValue);
        }

        [Test]
        public void GetItem_Test7()
        {
            Item ivItem = repository.GetItem("Invalid Item");
            Assert.IsNull(ivItem);
        }
    }
}
