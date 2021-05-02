using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Models
{
    // Inventory Management - Item
    public class Item
    {
        private string name;
        private int sellValue;
        private int qualityValue;

        private Item() { }//No Default constructor
        public Item(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NotSupportedException();
            }
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
        public int SellValue
        {
            get { return sellValue; }
            set { sellValue = value; }
        }

        public int QualityValue
        {
            get { return qualityValue; }
            set
            {
                qualityValue = value;
            }
        }
    }
}