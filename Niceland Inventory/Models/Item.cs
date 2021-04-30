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
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set {
                if (value == null || value.Length == 0)
                {
                    throw new NotSupportedException();
                }
                name = value;
                SellValue = 0;
                QualityValue = 0;
            }
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
                if (value < 0)
                {
                    qualityValue = 0;
                }
                else if (value > 50)
                {
                    qualityValue = 50;
                }
                else
                {
                    qualityValue = value;
                }

            }
        }
    }
}