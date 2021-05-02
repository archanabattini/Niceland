using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niceland_Inventory.Services
{
    public interface IItemValueCalculatorFactory
    {
        IValueCalculator CreateValueCalculator(Item item);
    }
}
