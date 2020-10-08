using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public abstract class VendingMachineItem
    {
        public int OrderNumber { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int TotalItem { get; private set; }

        public VendingMachineItem(int orderNumber, string productName, decimal price, int totalItem)
        {
            this.OrderNumber = orderNumber;
            this.ProductName = productName;
            this.Price = price;
            this.TotalItem = totalItem;
        }

        public bool DecrementItem(int purchaseQuantity)
        {
            if (TotalItem > 0)
            {
                TotalItem -= TotalItem - purchaseQuantity;
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is VendingMachineItem item &&
                   OrderNumber == item.OrderNumber &&
                   ProductName == item.ProductName &&
                   Price == item.Price &&
                   TotalItem == item.TotalItem;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderNumber, ProductName, Price, TotalItem);
        }
    }
}
