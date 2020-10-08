using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Model;

namespace VendingMachine.Model
{
    public class Coke : VendingMachineItem
    {
        public Coke(int orderNumber, string productName, decimal price, int totalItem)
            : base(orderNumber, productName, price, totalItem)
        {

        }
    }
}
