using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public abstract class ValueCalculatorDecorator : ValueCalculator
    {
        protected ValueCalculator baseCalculator;

        public ValueCalculatorDecorator(ValueCalculator calc): base(calc.InventoryItem)
        {
            baseCalculator = calc;
        }
    }
}