﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niceland_Inventory.Repository;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Niceland_Inventory.Tests.Repository
{
    [TestFixture]
    public class ItemsRepositoryTest
    {
        ItemsRepository repository;

        [OneTimeSetUp]
        public void Setup()
        {
            repository = new ItemsRepository();
        }



        [Test]
        public void GetAll()
        {

            IEnumerable<string> result = repository.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());

            Assert.AreEqual("Aged Brie", result.ElementAt(0));
            Assert.AreEqual("Christmas Crackers", result.ElementAt(1));
            Assert.AreEqual("Fresh Item", result.ElementAt(2));
            Assert.AreEqual("Frozen Item", result.ElementAt(3));
            Assert.AreEqual("Soap", result.ElementAt(4));

        }

        [Test]
        public void GetItem()
        {
            Item item = repository.GetItem("");
            Assert.IsNull(item);

            Item abItem = repository.GetItem("Aged Brie");
            Assert.IsNotNull(abItem);
            Assert.AreEqual(0, abItem.SellValue);
            Assert.AreEqual(0, abItem.QualityValue);
            Item ccItem = repository.GetItem("Christmas Crackers");
            Assert.IsNotNull(abItem);
            Assert.AreEqual(0, abItem.SellValue);
            Assert.AreEqual(0, abItem.QualityValue);
            Item fiItem = repository.GetItem("Fresh Item");
            Assert.IsNotNull(abItem);
            Assert.AreEqual(0, abItem.SellValue);
            Assert.AreEqual(0, abItem.QualityValue);
            Item fzItem = repository.GetItem("Frozen Item");
            Assert.IsNotNull(abItem);
            Assert.AreEqual(0, abItem.SellValue);
            Assert.AreEqual(0, abItem.QualityValue);
            Item spItem = repository.GetItem("Soap");
            Assert.IsNotNull(abItem);
            Assert.AreEqual(0, abItem.SellValue);
            Assert.AreEqual(0, abItem.QualityValue);

            Item ivItem = repository.GetItem("Invalid Item");
            Assert.IsNull(abItem);
        }


    }
}
