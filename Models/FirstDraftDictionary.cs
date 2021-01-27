//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Capstone.Models
//{
//    public class ItemDictionary2
//    {
//        private const int Pos_itemSlotID = 0;
//        private const int Pos_itemName = 1;
//        private const int Pos_itemPrice = 2;
//        private const int Pos_itemType = 3;


//        public Dictionary<string, VendingItem> VendingDictionary()
//        {
//            Dictionary<string, VendingItem> vendingItems = new Dictionary<string, VendingItem>();

//            string directory = Environment.CurrentDirectory;
//            string file = "vendingmachine.csv";
//            string filePath = Path.Combine(directory, file);

//            using (StreamReader sr = new StreamReader(filePath))
//            {
//                while (!sr.EndOfStream)
//                {
//                    string line = sr.ReadLine();

//                    string[] itemDetails = line.Split("|");

//                    string itemName = itemDetails[Pos_itemName];

//                    if (!decimal.TryParse(itemDetails[Pos_itemPrice], out decimal itemPrice))
//                    {
//                        itemPrice = 0M;
//                    }

//                    //string itemPrice = itemDetails[Pos_itemPrice];
//                    int itemsRemaining = 5;

//                    VendingItem item;

//                    switch (itemDetails[Pos_itemType])
//                    {
//                        case "Chip":
//                            item = new Chips(itemName, itemPrice, itemsRemaining);
//                            break;
//                        case "Drink":
//                            item = new Drink(itemName, itemPrice, itemsRemaining);
//                            break;
//                        case "Gum":
//                            item = new Gum(itemName, itemPrice, itemsRemaining);
//                            break;
//                        case "Candy":
//                            item = new Candy(itemName, itemPrice, itemsRemaining);
//                            break;
//                        default:
//                            item = new Drink(itemName, itemPrice, itemsRemaining);
//                            break;
//                    }
//                    vendingItems.Add(itemDetails[Pos_itemSlotID], item);

//                }
//            }
//            return vendingItems;
//        }

//    }
//}





