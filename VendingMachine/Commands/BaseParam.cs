using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Commands
{
    public class BaseParam
    {
        public string CommandParam { get; set; }
        public int OrderNumberCommandParam { get; set; }
        public int QuantityCommandParam { get; set; }
        public decimal PriceCommandParam { get; set; }
    }
}
