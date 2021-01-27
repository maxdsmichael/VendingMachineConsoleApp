using System.Collections.Generic;
using System.IO;

namespace Capstone.Models
{
    public class ItemDictionary
    {
        public Dictionary<string, List<VendingItem>> StockVendingMachine()
        {
            Dictionary<string, List<VendingItem>> itemDictionary = new Dictionary<string, List<VendingItem>>();

            string directory = Directory.GetCurrentDirectory();
            string filename = "vendingmachine.csv";
            string filepath = Path.Combine(directory, filename);

            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    List<VendingItem> listOfItems = new List<VendingItem>();
                    string line = sr.ReadLine();
                    string[] fields = line.Split('|');

                    if (fields[0].StartsWith("A"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            listOfItems.Add(new Chips(decimal.Parse(fields[2]), fields[1]));
                        }
                        itemDictionary.Add(fields[0], listOfItems);
                    }
                    else if (fields[0].StartsWith("B"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            listOfItems.Add(new Candy(decimal.Parse(fields[2]), fields[1]));
                        }
                        itemDictionary.Add(fields[0], listOfItems);
                    }
                    else if (fields[0].StartsWith("C"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            listOfItems.Add(new Drink(decimal.Parse(fields[2]), fields[1]));
                        }
                        itemDictionary.Add(fields[0], listOfItems);
                    }
                    else if (fields[0].StartsWith("D"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            listOfItems.Add(new Gum(decimal.Parse(fields[2]), fields[1]));
                        }
                        itemDictionary.Add(fields[0], listOfItems);
                    }

                }
            }
            return itemDictionary;

        }
    }
}