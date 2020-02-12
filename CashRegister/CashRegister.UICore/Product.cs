using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.UICore
{
    public class Product
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double gesamt { get; set; }

        public Product(string productName, int amount, double price, double gesamt)
        {
            ProductName = productName;
            Amount = amount;
            Price = price;
            this.gesamt = gesamt;
        }
    }
}
