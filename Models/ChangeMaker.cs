using System;
using System.Collections.Generic;

namespace Capstone.Models
{
    public class ChangeMaker : VendingMachineCLI
    {
        private decimal balance;

        private int quarters;

        private int dimes;

        private int nickles;


        public int Quarters
        {
            get
            {
                return this.quarters;
            }
        }
        public int Dimes
        {
            get
            {
                return this.dimes;
            }
        }
        public int Nickles
        {
            get
            {
                return this.nickles;
            }
        }
        public ChangeMaker(decimal balance)
        {
            this.balance = balance;
        }

        public List<int> MakeChange()
        {
            List<int> coinCount = new List<int>();
            while (balance > 0)
            {
                int t = (int)(balance * 100);
                quarters = (int)t / 25;
                t = t % 25;
                dimes = (int)t / 10;
                t = t % 10;
                nickles = (int)t / 5;
                t = t % 5;
                balance = (int)t;
            }
            coinCount.AddRange(new List<int> { quarters, dimes, nickles });// added WriteLine instead of Write to make it look better
            ResetColor();
            SetColor(ConsoleColor.Gray);
            Console.WriteLine("Dispensing...");
            SetColor(ConsoleColor.DarkRed);
            Console.WriteLine($"{quarters} \tQuarters");
            SetColor(ConsoleColor.DarkBlue);
            Console.WriteLine($"{dimes} \tDimes");
            SetColor(ConsoleColor.DarkGreen);
            Console.WriteLine($"{nickles} \tNickles");
            Console.WriteLine();
            Console.WriteLine();
            SetColor(ConsoleColor.DarkGray);
            Console.WriteLine("Press enter to return to the main menu...");
            ResetColor();
             Console.ReadLine(); // Can't solve how to have tests run without getting rid of the 
            // waiting for enter. Not sure how to simulate a keystroke like "enter" in the test method
            // Same problem for vendingmachinetests
            return coinCount;

           

        }
    }
}
