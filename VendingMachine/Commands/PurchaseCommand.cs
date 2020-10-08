using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Commands
{
    public class PurchaseCommand : ICommand
    {
        private string _commandParam;
        private int _orderNumaber;
        private int _quantity;
        private decimal _price;
        public PurchaseCommand(string commandParam, decimal price, int orderNumebr, int quantity)
        {
            this._commandParam = commandParam;
            this._orderNumaber = orderNumebr;
            this._quantity = quantity;
            this._price = price;
        }

        public BaseParam Params => new BaseParam() { CommandParam = _commandParam, OrderNumberCommandParam = _orderNumaber, PriceCommandParam = _price, QuantityCommandParam = _quantity };

        public bool Execute()
        {
            if (!_commandParam.Equals("order"))
                throw new Exception("Invalid command");

            return true;
        }
    }
}
