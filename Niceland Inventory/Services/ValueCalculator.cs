using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public abstract class ValueCalculator : IValueCalculator
    {
        private int sellValueFactor;
        private int qualityValueFactor;

        private int sellValueChange;
        private int qualityValueChange;

        private Item inventoryItem;

        public Item InventoryItem
        {
            get { return inventoryItem; }
            set { inventoryItem = value; }
        }

        public int SellValueFactor
        {
            get { return sellValueFactor; }
            set { sellValueFactor = value; }
        }

        public int QualityValueFactor
        {
            get { return qualityValueFactor; }
            set { qualityValueFactor = value; }
        }

        public int SellValueChange
        {
            get { return sellValueChange; }
            set { sellValueChange = value; }
        }

        public int QualityValueChange
        {
            get { return qualityValueChange; }
            set { qualityValueChange = value; }
        }

        public ValueCalculator(Item inventoryItem)
        {
            InventoryItem = inventoryItem;
            sellValueChange = 1;
            qualityValueChange = 1;

            sellValueFactor = 1;
            qualityValueFactor = 1;
        }

        // Updates SellValue and QualityValue of Item past 1 day
        public void UpdateValue()
        {
            UpdateSellValueChange();
            UpdateSellValueFactor();
            InventoryItem.SellValue += SellValueChange * SellValueFactor;
            UpdateQualityValueChange();
            UpdateQualityValueFactor();
            InventoryItem.QualityValue += QualityValueChange * QualityValueFactor;
        }
        // Updates SellValue and QualityValue of Item past given input number of days
        public void UpdateValue(int days)
        {
            for (int i = 0; i < days; i++)
            {
                UpdateValue();
            }
        }
        public abstract void UpdateSellValueFactor();
        public abstract void UpdateQualityValueFactor();
        public abstract void UpdateSellValueChange();
        public abstract void UpdateQualityValueChange();
    }
}