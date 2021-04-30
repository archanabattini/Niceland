﻿using NUnit.Framework;
using System;

namespace Niceland_Inventory.Tests.Models
{
    [TestFixture]
    public class ItemTest
    {
        [Test]
        public void Name()
        {
            Assert.Throws(new Item()); //Default constructor not allowed.

            Item item = new Item("Aged Brie");
            Assert.Equals("Aged Brie", item.Name);//Success

            Item item2 = new Item("Christmas Crackers");
            Assert.Equals("Christmas Crackers", item2.Name);
            item2.Name = "Soap";
            Assert.Equals("Soap", item6.Name);// Name is changeable

            Assert.Throws<NotSupportedException>(() => item6.Name = "");//Name cannot be set to Empty.

            Assert.Throws<NotSupportedException>(new Item(""));//Item cannot be created with empty name.
        }

        [Test]
        public void SellValue()
        {
            Assert.Throws(new Item());//Default constructor not allowed.

            Item item = new Item("Aged Brie");
            Assert.Equals(0, item.SellValue);//SellValue set by default to zero.
            Assert.True(item.SellValue is int);//SellValue must be integer

            Item item2 = new Item("Christmas Crackers");
            Assert.Equals(0, item2.SellValue);
            item2.SellValue = -99;
            Assert.Equals(-99, item2.SellValue);//SellValue can be negative.
            item2.SellValue = 5;
            Assert.Equals(5, item2.SellValue);//SellValue is positive Integer.

            Item item3 = new Item("Fresh Item");
            Assert.Equals("Fresh Item", item3.Name);//Success
            item3.SellValue = 9;
            Assert.Equals(9, item3.SellValue);
            item3.Name = "Soap";
            Assert.Equals("Soap", item3.Name);
            Assert.Equals(0, item3.SellValue);//When Name changed, SellValue will be reset to zero.

            Assert.Throws<NotSupportedException>(new Item(""));//Item cannot be created with empty name.
        }

        [Test]
        public void QualityValue()
        {
            Assert.Throws(new Item());//Default constructor not allowed.

            Item item = new Item("Aged Brie");
            Assert.Equals(0, item.QualityValue);//QualityValue set by default to zero.
            Assert.True(item.QualityValue is int);//QualityValue must be integer

            Item item2 = new Item("Christmas Crackers");
            Assert.Equals(0, item2.QualityValue);
            item2.QualityValue = -99;
            Assert.Equals(0, item2.QualityValue);//QualityValue cannot be negative.
            item2.QualityValue = -1;
            Assert.Equals(0, item2.QualityValue);//QualityValue boundary condition - overflow
            item2.QualityValue = 0;
            Assert.Equals(0, item2.QualityValue);//QualityValue boundary condition - min
            item2.QualityValue = 5;
            Assert.Equals(5, item2.QualityValue);//QualityValue appropriate
            item2.QualityValue = 50;
            Assert.Equals(50, item2.QualityValue);//QualityValue boundary condition - max
            item2.QualityValue = 51;
            Assert.Equals(50, item2.QualityValue);//QualityValue boundary condition - overflow

            Item item3 = new Item("Fresh Item");
            Assert.Equals("Fresh Item", item3.Name);//Success
            item3.QualityValue = 9;
            Assert.Equals(9, item3.QualityValue);
            item3.Name = "Soap";
            Assert.Equals("Soap", item3.Name);
            Assert.Equals(0, item3.QualityValue);//When Name changed QualityValue reset to zero.

            Assert.Throws<NotSupportedException>(new Item(""));//Item cannot be created with empty name.
        }
    }
}
