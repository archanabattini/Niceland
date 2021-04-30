using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niceland_Inventory.Services
{
    interface IValueCalculator
    {

        // Updates Factor by which SellValue of Item decreases past 1 day
        void UpdateSellValueFactor();

        // Updates Factor by which QualityValue of Item decreases past 1 day
        void UpdateQualityValueFactor();
        // Updates Value by which SellValue of an Item changes past 1 day
        void UpdateSellValueChange();

        // Updates Value by which QualityValue of an Item changes past 1 day
        void UpdateQualityValueChange();
    }
}
