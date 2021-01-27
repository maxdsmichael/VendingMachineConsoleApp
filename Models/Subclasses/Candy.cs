using System;
using System.Diagnostics.SymbolStore;

namespace Capstone.Models
{
    public class Candy : VendingItem
    {

        public override string Consume()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return "Munch Munch, Yum!";
        }

        public Candy(decimal price, string name) : base(price, name)
        {

        }
        //public const string messageText = "Munch Munch, Yum!";
        //public Candy(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, messageText)
        //{

        //}
    }
}
