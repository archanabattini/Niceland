using Niceland_Inventory.Models;
using Niceland_Inventory.Repository;
using Niceland_Inventory.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niceland_Inventory.Services
{
    public class ItemValueService : IItemValueService
    {
        private IItemsRepository repo;
        private IItemValueCalculatorFactory factory;
        public ItemValueService(IItemsRepository repo, IItemValueCalculatorFactory factory)
        {
            this.repo = repo;
            this.factory = factory;
        }
        public List<string> CalculateInventoryValueChange(List<string> items)
        {
            List<string> itemsToReturn = null;
            if (items != null)
            {
                itemsToReturn = new List<string>();
                foreach (string itemInput in items)
                {
                    try
                    {
                        Item itemObj = GetItem(itemInput);
                        factory.CreateValueCalculator(itemObj).UpdateValue();
                        itemsToReturn.Add(
                            string.Join(" ", new string[] { itemObj.Name, itemObj.SellValue.ToString(), itemObj.QualityValue.ToString() })
                        );
                    } catch (InvalidItemInputFormatException ife)
                    {
                        itemsToReturn.Add("INVALID INPUT FORMAT");
                    }
                    catch (NoSuchItemException nsie)
                    {
                        itemsToReturn.Add("NO SUCH ITEM");
                    }
                }
            }

            return itemsToReturn;
        }

        private Item GetItem(string itemInput)
        {
            string[] tokens = itemInput.Split();
            if (tokens.Length <= 2) //Atleast 3 tokens expected one for name, then sell value and then quality value.
            {
                throw new InvalidItemInputFormatException();
            }
            int qualityValue = 0;
            int sellValue = 0;
            try
            {
                qualityValue = int.Parse(tokens[tokens.Length - 1]);

            } catch (FormatException fe)
            {
                throw new InvalidItemInputFormatException();
            }

            try
            {
                sellValue = int.Parse(tokens[tokens.Length - 2]);
            }
            catch (FormatException fe)
            {
                throw new InvalidItemInputFormatException();
            }

            string itemName = string.Join(" ", tokens.Take(tokens.Length - 2));//Form item name excluding sell value & quality value.
            Item item = repo.GetItem(itemName);
            if (item == null)
            {
                throw new NoSuchItemException();
            }
            item.SellValue = sellValue;
            item.QualityValue = qualityValue;

            return item;
        }
    }
}