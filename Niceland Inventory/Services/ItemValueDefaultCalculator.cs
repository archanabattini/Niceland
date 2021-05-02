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
        { }

        public override int GetQualityValueChange()
        {
            if (InventoryItem.SellValue < 0)
            {
                return -2;
            }
            else
            {
                return -1;
            }
        }

        public override int GetQualityValueFactor()
        {
            return 1;
        }

        public override int GetSellValueChange()
        {
            return -1;
        }

        public override int GetSellValueFactor()
        {
            return  1;
        }
    }
}