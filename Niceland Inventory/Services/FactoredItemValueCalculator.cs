using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class FactoredQualityValueCalculator : ItemValueDefaultCalculator
    {
        int qualityValueFactor;
        public FactoredQualityValueCalculator(Item item, int qvFactor): base(item)
        {
            qualityValueFactor = qvFactor;
        }

        public override int GetQualityValueFactor()
        {
            return qualityValueFactor;
        }
    }
}