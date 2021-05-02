using Niceland_Inventory.Models;
using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Models
{
    [TestFixture]
    public class ItemTest
    {

        [Test]
        public void NewItem_Test()
        {
            Assert.Throws<NotSupportedException>(() => new Item(""));//Item cannot be created with empty name.

            Assert.Throws<NotSupportedException>(() => new Item(null));//Item cannot be created with empty name.
        }

        [Test]
        public void Name_Test()
        {
            Item item = new Item("Aged Brie");
            Assert.IsNotNull(item.Name);
            Assert.AreEqual("Aged Brie", item.Name);//Success
        }

        [Test]
        public void SellValue_Test()
        {
            Item item = new Item("Aged Brie");
            Assert.AreEqual(0, item.SellValue);//SellValue set by default to zero.
            Assert.AreEqual(typeof(int), item.SellValue.GetType());
            
            Item item2 = new Item("Christmas Crackers");
            Assert.AreEqual(0, item2.SellValue);
            item2.SellValue = -99;
            Assert.AreEqual(-99, item2.SellValue);//SellValue can be negative.
            item2.SellValue = 5;
            Assert.AreEqual(5, item2.SellValue);//SellValue is positive Integer.
        }

        [Test]
        public void QualityValue_Test()
        {
            Item item = new Item("Aged Brie");
            Assert.AreEqual(0, item.QualityValue);//QualityValue set by default to zero.
            Assert.AreEqual(typeof(int), item.QualityValue.GetType());//QualityValue must be integer

            Item item2 = new Item("Christmas Crackers");
            Assert.AreEqual(0, item2.QualityValue);
            item2.QualityValue = -99;
            Assert.AreEqual(0, item2.QualityValue);//QualityValue cannot be negative.
            item2.QualityValue = -1;
            Assert.AreEqual(0, item2.QualityValue);//QualityValue boundary condition - overflow
            item2.QualityValue = 0;
            Assert.AreEqual(0, item2.QualityValue);//QualityValue boundary condition - min
            item2.QualityValue = 5;
            Assert.AreEqual(5, item2.QualityValue);//QualityValue appropriate
            item2.QualityValue = 50;
            Assert.AreEqual(50, item2.QualityValue);//QualityValue boundary condition - max
            item2.QualityValue = 51;
            Assert.AreEqual(50, item2.QualityValue);//QualityValue boundary condition - overflow
        }
    }
}
