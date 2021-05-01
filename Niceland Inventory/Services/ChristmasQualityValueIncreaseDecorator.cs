using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ChristmasQualityValueIncreaseDecorator : ValueCalculatorDecorator
    {
        public ChristmasQualityValueIncreaseDecorator(ValueCalculator calc): base(calc)
        {

        }
        public override int GetQualityValueChange()
        {
            if (InventoryItem.SellValue > 10)
                return 1;
            else if (InventoryItem.SellValue <= 10 && InventoryItem.SellValue > 5)
                return 2;
            else if (InventoryItem.SellValue <= 5 && InventoryItem.SellValue >= 0)
                return 3;
            else
                return 0;
        }

        public override int GetQualityValueFactor()
        {
            if (InventoryItem.SellValue >= 0)
                return 1;
            else
                return 0;
        }

        public override int GetSellValueChange()
        {
            return baseCalculator.GetSellValueChange();
        }

        public override int GetSellValueFactor()
        {
            return baseCalculator.GetSellValueFactor();
        }

        // Updates SellValue and QualityValue of Item past 1 day
        public override void UpdateValue()
        {
            InventoryItem.SellValue += GetSellValueChange() * GetSellValueFactor();
            if (InventoryItem.SellValue >= 0)
                InventoryItem.QualityValue += GetQualityValueChange() * GetQualityValueFactor();
            else
                InventoryItem.QualityValue = 0;
        }
    }
}