using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ItemValueDefaultCalculator : ValueCalculator
    {
        public ItemValueDefaultCalculator(Item item): base(item)
        {

        }
        public override void UpdateQualityValueChange()
        {
            QualityValueChange = -1;
        }

        public override void UpdateQualityValueFactor()
        {
            if (InventoryItem.SellValue < 0)
            {
                QualityValueFactor = 2;
            } else
            {
                QualityValueFactor = 1;
            }
        }

        public override void UpdateSellValueChange()
        {
            SellValueChange = -1;
        }

        public override void UpdateSellValueFactor()
        {
            SellValueFactor = 1;
        }
    }
}