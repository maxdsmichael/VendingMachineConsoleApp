using System;

namespace Capstone.Models
{
    public class Drink : VendingItem
    {
        public override string Consume()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return "Glug Glug, Yum!";
        }

        public Drink(decimal price, string name) : base(price, name)
        {

        }


        //public const string messageText = "Glug Glug, Yum!";
        //public Drink(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, messageText)
        //{

        //}
    }
}
