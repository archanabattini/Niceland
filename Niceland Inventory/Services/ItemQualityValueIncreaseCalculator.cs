using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ItemQualityValueIncreaseCalculator : ItemValueDefaultCalculator
    {
        public ItemQualityValueIncreaseCalculator(Item item): base(item)
        {

        }
        public override int GetQualityValueChange()
        {
            return 1;
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
            return 1;
        }
    }
}