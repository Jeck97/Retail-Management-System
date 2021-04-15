using System;

namespace Retail_Management_System
{
    public class UpdatedItem
    {
        public String ID { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public double Discount { get; private set; }

        public UpdatedItem(String ID, double Price, int Quantity, double Discount)
        {
            this.ID = ID;
            this.Price = Price;
            this.Quantity = Quantity;
            this.Discount = Discount;
        }
    }
}
