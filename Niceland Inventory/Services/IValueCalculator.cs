using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niceland_Inventory.Services
{
    public interface IValueCalculator
    {

        // Get Factor by which SellValue of Item decreases past 1 day
        int GetSellValueFactor();

        // Get Factor by which QualityValue of Item decreases past 1 day
        int GetQualityValueFactor();
        // Get Value by which SellValue of an Item changes past 1 day
        int GetSellValueChange();

        // Get Value by which QualityValue of an Item changes past 1 day
        int GetQualityValueChange();

        // Updates SellValue and QualityValue of Item past 1 day
        void UpdateValue();

        // Updates SellValue and QualityValue of Item past given input number of days
        void UpdateValue(int days);
    }
}
