using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ItemNoValueChangeDecorator : ValueCalculatorDecorator
    {
        public ItemNoValueChangeDecorator(ValueCalculator calc): base(calc)
        {
            baseCalculator = calc;
        }

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