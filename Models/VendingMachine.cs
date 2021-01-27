using System;
using System.Collections.Generic;

namespace Capstone.Models
{
    public class VendingMachine : VendingMachineCLI
    {
        private Dictionary<string, List<VendingItem>> vendingItems = new ItemDictionary().StockVendingMachine();
        private List<VendingItem> purchasedItems = new List<VendingItem>();
        private decimal balance = 0.00M;

        public Dictionary<string, List<VendingItem>> VendingItems
        {
            get
            {
                return this.vendingItems;
            }
        }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
        }


        public void PurchaseMenu()
        {
            while (true)
            {
                ResetColor();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render("PURCHASE MENU:"));
                SetColor(ConsoleColor.Magenta);
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");

                Console.WriteLine($"\n\tCurrent Money Provided: ${this.balance} ");
                SetColor(ConsoleColor.Green);
                Console.Write("What option do you want to select: ");
                SetColor(ConsoleColor.Magenta);
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    SetColor(ConsoleColor.Magenta);
                    Console.WriteLine(Figgle.FiggleFonts.Small.Render("FEED MONEY"));
                    SetColor(ConsoleColor.White);
                    //Console.WriteLine("Feed Money");
                    Console.Write("Please deposit money in either $1, $2, $5, or $10: ");
                    SetColor(ConsoleColor.Green);
                    Console.Write("$");
                    string amountDepositedString = Console.ReadLine(); // fixed crash
                    ResetColor();
                    decimal amountDeposited;
                    try
                    {
                        amountDeposited = decimal.Parse(amountDepositedString);
                        {
                            if (amountDeposited < 0)
                            {
                                SetColor(ConsoleColor.Red);
                                Console.WriteLine("You can't insert negative money, that's not how vending machines work!");
                                Console.ReadLine();
                            }
                            else
                            {
                                if ((amountDeposited != 1) && (amountDeposited != 2) && (amountDeposited != 5) && (amountDeposited != 10))
                                {
                                    SetColor(ConsoleColor.Red);
                                    Console.WriteLine("Please deposit a valid bill!");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    this.FeedMoney(amountDeposited);
                                    SetColor(ConsoleColor.Gray);
                                    Console.WriteLine($"You inserted a ");
                                    SetColor(ConsoleColor.Green);
                                    Console.Write($"${amountDeposited}");
                                    SetColor(ConsoleColor.Gray);
                                    Console.Write(" dollar bill.");
                                    Console.WriteLine();
                                    SetColor(ConsoleColor.DarkGray);
                                    Console.WriteLine("Press enter to return to the purchase menu...");
                                    ResetColor();
                                    Console.ReadLine();
                                }

                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine($"{amountDepositedString} is not a valid deposit amount!");
                        Console.ReadLine();
                    }
                    catch (OverflowException)
                    {
                        Console.Clear();
                        Console.WriteLine($"Wrong amount!");
                        Console.WriteLine("Please deposit $1, $2, $5, or $10!");
                        Console.ReadLine();
                    }

                    Console.Clear();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    // Display current inventory
                    SetColor(ConsoleColor.Cyan);
                    DisplayItems();
                    SetColor(ConsoleColor.Magenta);
                    // Select product
                    Console.WriteLine("Select Product");
                    Console.Write("Which slot are you choosing from?: ");
                    SetColor(ConsoleColor.Green);

                    string selection = Console.ReadLine().ToUpper();
                    try
                    {
                        if (selection.Contains(""))
                            this.Purchase(selection);
                    }
                    catch (KeyNotFoundException)
                    {
                        SetColor(ConsoleColor.Red);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Not a valid selection, please try again!");
                        Console.ReadLine();
                        ResetColor();
                    }


                }
                else if (input == "3")
                {
                    Console.Clear();
                    SetColor(ConsoleColor.Magenta);
                    Console.WriteLine(Figgle.FiggleFonts.Small.Render("Finishing Transaction..."));
                    //Console.WriteLine("Finishing Transaction...");
                    Console.WriteLine();
                    Console.WriteLine();
                    ResetColor();
                    this.CompleteTransaction();
                    break;


                }
                else
                {
                    SetColor(ConsoleColor.Red);
                    Console.WriteLine("Not a selectable option, please try again.");
                    Console.ReadLine();
                    ResetColor();
                    Console.Clear();

                }


            }
        }

        public void FeedMoney(decimal dollars)
        {
            Log log = new Log();
            string formattedDollars = String.Format("{0:C}", dollars);
            log.WriteToLog($"FEED MONEY: {formattedDollars} ${balance + dollars}"); // Needs to write with two trailing digits
            this.balance += dollars;
        }

        public VendingItem Purchase(string fields)
        {
            if (!IsSoldOut(fields))
            {
                if (vendingItems[fields][0].Price <= this.balance)
                {
                    VendingItem selection = vendingItems[fields][0];
                    Log log = new Log();
                    // log.WriteToLog($"{vendingItems[fields][0].Name}  {fields}   $" + balance + "  $" + (balance - vendingItems[fields][0].Price));
                    log.WriteToLog($"{vendingItems[fields][0].Name}  {fields}   ${balance}   $ {(balance - vendingItems[fields][0].Price)}");

                    balance -= vendingItems[fields][0].Price;
                    purchasedItems.Insert(0, vendingItems[fields][0]);
                    vendingItems[fields].Remove(vendingItems[fields][0]);


                    foreach (VendingItem e in purchasedItems)// bug found where Consume will continue same message as first purchased item.
                    {

                        for (int i = 0; i < e.Consume().Length; i++)  // Writes out the string char by char, simply for effect
                        {
                            Console.Write(e.Consume()[i]);
                            System.Threading.Thread.Sleep(60);
                        }

                        //Console.WriteLine(e.Consume());
                        Console.WriteLine();
                        SetColor(ConsoleColor.DarkGray);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        ResetColor();

                        break;
                    }
                    return selection;
                }
                else
                {
                    SetColor(ConsoleColor.Red);
                    Console.WriteLine("Insufficient funds. Please insert more money!");
                    Console.ReadLine();
                    Console.Clear();
                    ResetColor();

                    return null;   // return nothing because not enough money!
                }
            }
            else
            {
                SetColor(ConsoleColor.Red);
                Console.WriteLine("Item is sold out. Please select something else.");
                Console.ReadLine();
                ResetColor();
                Console.Clear();

                return null;    //return nothing because it is sold out
            }
        }

        public void DisplayItems()
        {
            foreach (KeyValuePair<string, List<VendingItem>> kvp in this.vendingItems)
            {
                string temp = "";
                decimal tempPrice = 0;

                if (kvp.Value.Count == 0)
                {
                    temp = "Sold Out!";        // checks to see whether slot is empty & changes display if yes
                }
                else
                {
                    tempPrice = kvp.Value[0].Price;
                    temp = kvp.Value[0].Name;  // if not empty, display name of product
                }

                Console.WriteLine($"{kvp.Key, -10} {temp, 20} {tempPrice.ToString(), -10} Quantity: {kvp.Value.Count}");
            }
        }

        public void CompleteTransaction()
        {
            ChangeMaker c = new ChangeMaker(this.balance);
            c.MakeChange();
            Log log = new Log();
            log.WriteToLog($"Give Change: ${balance} $0.00");
            this.balance = 0;
            purchasedItems.Clear();

        }

        public bool IsSoldOut(string fields)
        {
            return vendingItems[fields].Count == 0;
        }

    }
}
