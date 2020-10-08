using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Water : VendingMachineItem
    {
        public Water(int orderNumber, string productName, decimal price, int totalItem)
           : base(orderNumber, productName, price, totalItem)
        {

        }
    }
}
