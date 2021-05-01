using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public abstract class ValueCalculator : IValueCalculator
    {
        private Item inventoryItem;

        public Item InventoryItem
        {
            get { return inventoryItem; }
            set { inventoryItem = value; }
        }

        private ValueCalculator() { } // Hiding to enforce to pass Item

        public ValueCalculator(Item inventoryItem)
        {
            InventoryItem = inventoryItem;
        }

        // Updates SellValue and QualityValue of Item past 1 day
        public virtual void UpdateValue()
        {
            InventoryItem.SellValue += GetSellValueChange() * GetSellValueFactor();
            InventoryItem.QualityValue += GetQualityValueChange() * GetQualityValueFactor();
        }
        // Updates SellValue and QualityValue of Item past given input number of days
        public void UpdateValue(int days)
        {
            for (int i = 0; i < days; i++)
            {
                UpdateValue();
            }
        }
        public abstract int GetSellValueFactor();
        public abstract int GetQualityValueFactor();
        public abstract int GetSellValueChange();
        public abstract int GetQualityValueChange();
    }
}