using System;

namespace Capstone.Models
{
    public class Gum : VendingItem
    {
        //    public const string messageText = "Chew Chew, Yum!";
        //    public Gum(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, messageText)
        //    {

        //    }
        public override string Consume()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return "Chew Chew, Yum!";
        }

        public Gum(decimal price, string name) : base(price, name)
        {

        }
    }


}
