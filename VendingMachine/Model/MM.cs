using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class MM : VendingMachineItem
    {
        public MM(int orderNumber, string productName, decimal price, int totalItem)
           : base(orderNumber, productName, price, totalItem)
        {

        }
    }
}
