using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Snickers : VendingMachineItem
    {
        public Snickers(int orderNumber, string productName, decimal price, int totalItem)
            : base(orderNumber, productName, price, totalItem)
        {

        }
    }
}
