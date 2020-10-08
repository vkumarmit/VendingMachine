using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Aggregator
{
    public class Product : IAggregateRoot
    {
        //default constructor
        public Product()
        {

        }
        private int _orderNumber;
        private string _productCode;
        private string _name;
        private string _description;
        private int _quantity;
        private decimal _price;
        private decimal _actualCost;

        public virtual int OrderNumber
        {
            get => _orderNumber;
            set => _orderNumber = value;
        }
        public virtual string ProductCode
        {
            get => _productCode;
            set => _productCode = value;
        }

        public virtual string Name
        {
            get => _name;
            set => _name = value;
        }

        public virtual string Description
        {
            get => _description;
            set => _description = value;
        }

        public virtual int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public virtual decimal Price
        {
            get => _price;
            set => _price = value;
        }
        public virtual decimal ActualCost
        {
            get => _actualCost;
            set => _actualCost = value;
        }

        public Product(int orderNumber, string productCode, string name, string description, int quantity, decimal price, decimal actualCost)
        {
            _orderNumber = orderNumber;
            _productCode = productCode;
            _name = name;
            _description = description;
            _quantity = quantity;
            _price = price;
            _actualCost = actualCost;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   _orderNumber == product._orderNumber &&
                   _productCode == product._productCode &&
                   _name == product._name &&
                   _description == product._description &&
                   _quantity == product._quantity &&
                   _price == product._price &&
                   _actualCost == product._actualCost &&
                   OrderNumber == product.OrderNumber &&
                   ProductCode == product.ProductCode &&
                   Name == product.Name &&
                   Description == product.Description &&
                   Quantity == product.Quantity &&
                   Price == product.Price &&
                   ActualCost == product.ActualCost;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(_orderNumber);
            hash.Add(_productCode);
            hash.Add(_name);
            hash.Add(_description);
            hash.Add(_quantity);
            hash.Add(_price);
            hash.Add(_actualCost);
            hash.Add(OrderNumber);
            hash.Add(ProductCode);
            hash.Add(Name);
            hash.Add(Description);
            hash.Add(Quantity);
            hash.Add(Price);
            hash.Add(ActualCost);
            return hash.ToHashCode();
        }
    }
}
