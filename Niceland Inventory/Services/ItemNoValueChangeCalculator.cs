using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ItemNoValueChangeCalculator : ValueCalculator
    {
        public ItemNoValueChangeCalculator(Item item): base(item)
        { }

        public override int GetQualityValueChange()
        {
            return 0;
        }

        public override int GetQualityValueFactor()
        {
            return 0;
        }

        public override int GetSellValueChange()
        {
            return -1;
        }

        public override int GetSellValueFactor()
        {
            return 0;
        }
    }
}