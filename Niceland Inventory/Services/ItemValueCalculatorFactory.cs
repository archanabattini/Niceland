using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ItemValueCalculatorFactory : IItemValueCalculatorFactory
    {
        public IValueCalculator CreateValueCalculator(Item item)
        {
            if (item == null)
            {
                return null;
            }
            IValueCalculator calc;
            switch(item.Name)
            {
                case "Aged Brie":
                    calc = new ItemQualityValueIncreaseCalculator(item);
                    break;
                case "Christmas Crackers":
                    calc = new ChristmasQualityValueIncreaseDecorator(new ItemQualityValueIncreaseCalculator(item));
                    break;
                case "Fresh Item":
                    calc = new FactoredQualityValueCalculator(item, 2);
                    break;
                case "Frozen Item":
                    calc = new ItemValueDefaultCalculator(item);
                    break;
                case "Soap":
                    calc = new ItemNoValueChangeCalculator(item);
                    break;
                default:
                    calc = null;
                    break;
            }
            return calc;
        }
    }
}