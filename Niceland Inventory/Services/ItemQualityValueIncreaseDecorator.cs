using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ItemQualityValueIncreaseDecorator : ValueCalculatorDecorator
    {
        public ItemQualityValueIncreaseDecorator(ValueCalculator calc): base(calc)
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