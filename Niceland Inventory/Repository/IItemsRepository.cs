using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niceland_Inventory.Repository
{
    public interface IItemsRepository
    {
        IEnumerable<string> GetAll();
        Item GetItem(String name);
    }
}
