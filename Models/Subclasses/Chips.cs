using System;

namespace Capstone.Models
{
    public class Chips : VendingItem
    {

        public override string Consume()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return "Crunch Crunch, Yum!";
        }

        public Chips(decimal price, string name) : base(price, name)
        {

        }


        //public const string messageText = "Crunch Crunch, Yum!";
        //public Chips(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, messageText)
        //{

        //}
    }
}
