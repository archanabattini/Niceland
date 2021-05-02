using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niceland_Inventory.Services
{
    public interface IItemValueService
    {
        List<string> CalculateInventoryValueChange(List<string> items);
    }
}
