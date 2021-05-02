using Niceland_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Repository
{
    // Repository of Items - for test purpose assuming the hard coded values instead of fetching from the database
    public class ItemsRepository : IItemsRepository
    {
        public List<string> GetAll()
        {
            List<string> Items = new List<string>() { "Aged Brie", "Christmas Crackers", "Fresh Item", "Frozen Item", "Soap"};

            return Items;
        }

        public Item GetItem(String name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            List<string> items = GetAll();
            if (items.Contains(name))
            {
                return new Item(name);
            } else
            {
                return null;
            }
        }
    }
}