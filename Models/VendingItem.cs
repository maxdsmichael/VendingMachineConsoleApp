namespace Capstone.Models
{
    public abstract class VendingItem
    {

        protected decimal price;

        public decimal Price
        {
            get
            {
                return this.price;
            }
        }
        protected string name;

        protected VendingItem(decimal price, string name)
        {
            this.price = price;
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public abstract string Consume();


    }

    //public string ItemName { get; set; }
    //public decimal ItemPrice { get; set; }
    //public int ItemsRemaining { get; set; }
    //public string PurchaseMessage { get; set; }
    //public string SoldoutMessage { get; set; }

    //public VendingItem(string itemName, decimal itemPrice, int itemsRemaining, string purchaseMessage)
    //{
    //    this.ItemName = itemName;
    //    this.ItemPrice = itemPrice;
    //    this.ItemsRemaining = itemsRemaining;
    //    this.PurchaseMessage = purchaseMessage;
    //    this.SoldoutMessage = $"Sold out of {itemName}!";
    //}
}
