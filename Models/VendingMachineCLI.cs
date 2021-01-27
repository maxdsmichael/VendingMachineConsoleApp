using System;

namespace Capstone.Models
{
    public class VendingMachineCLI
    {
        static private ConsoleColor originalForegroundColor = Console.ForegroundColor;
        static private ConsoleColor originalBackgroundColor = Console.BackgroundColor;
        public void DisplayMenu()
        {
            VendingMachine vendingMachine = new VendingMachine();

            ResetColor();           
            SetColor(ConsoleColor.White);
            while (true)
            {
                Console.Clear();
                PrintHeader();
                Console.WriteLine();
                SetColor(ConsoleColor.Magenta);
                Console.WriteLine("(1) >> Display Vending Machine Items");
                Console.WriteLine("(2) >> Purchase");
                Console.WriteLine("(3) >> Exit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                SetColor(ConsoleColor.Green);
                Console.Write("What option do you want to select? ");
                SetColor(ConsoleColor.Magenta    );
                string input = Console.ReadLine();
                ResetColor();

                if (input == "1")
                {
                    Console.Clear();
                    SetColor(ConsoleColor.Green);
                    Console.WriteLine("Displaying items: ");
                    //DisplayItems(vendingMachine); 
                    SetColor(ConsoleColor.Cyan);
                    vendingMachine.DisplayItems();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    SetColor(ConsoleColor.DarkGray);
                    Console.WriteLine("Press enter to return to the main menu...");
                    ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    vendingMachine.PurchaseMenu();
                }
                else if (input == "3")
                {
                    SetColor(ConsoleColor.DarkYellow);
                    Console.Clear();
                    Console.WriteLine("Thank you, please come again!");
                    Console.ReadLine();
                    ResetColor();
                    break;



                }


                // TODO: If time allows, compelte sales report
                //
                //else if (input == "4")
                //{
                //    Console.WriteLine("Press enter to generate sales report...");
                //    Console.ReadLine();
                //}


                else
                {
                    SetColor(ConsoleColor.DarkRed);
                    Console.WriteLine("Invalid entry. Please try again...");
                    Console.ReadLine();
                    ResetColor();
                    Console.Clear();
                }
            }
        }

        #region Helper Methods
        private void PrintHeader()
        {

            SetColor(ConsoleColor.White);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("MAIN MENU"));
        }

        static public void SetColor(ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
        }

        static public void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        static public void ResetColor()
        {
            Console.ForegroundColor = originalForegroundColor;
            Console.BackgroundColor = originalBackgroundColor;
        }

        #endregion

    }
}


