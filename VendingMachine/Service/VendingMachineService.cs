using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;
using VendingMachine.CustomeException;
using VendingMachine.Model;
using VendingMachine.Repository;

namespace VendingMachine.Service
{
    public class VendingMachineService : IVendingMachineService
    {
        //We can use the Autofac to resolve the dependcy
        private readonly IRepository _inMemoryRepository;
        private readonly ConcurrentDictionary<int, VendingMachineItem> _vendingMachineMap = new ConcurrentDictionary<int, VendingMachineItem>();
        public VendingMachineService()
        {
            _inMemoryRepository = new InMemoryProductRepository();
            _inMemoryRepository.Init();
            PopulateVendingItem();
        }

        public bool Purchase(int orderNumber, int quantity, decimal price)
        {
            if (orderNumber <= 0)
                throw new PurchaseException($"{nameof(orderNumber)} can not be zero or negative.");

            if (quantity <= 0)
                throw new PurchaseException($"{nameof(quantity)} can not be zero or negative.");

            if (price <= 0)
                throw new PurchaseException($"{nameof(price)} can not be zero or negative.");

            VendingMachineItem vendingMachineItemOut;
            _vendingMachineMap.TryGetValue(orderNumber, out vendingMachineItemOut);

            if (vendingMachineItemOut.TotalItem < quantity)
                throw new PurchaseException($"There is not enough quantity available for the order number:{orderNumber}");

            var purchaseQauntity = vendingMachineItemOut.Price * quantity;

            if (purchaseQauntity != price)
                throw new PurchaseException($"Invalid price, Please provide the exact change or price for the order number:{orderNumber}");

            vendingMachineItemOut.DecrementItem(quantity);

            return true;
        }

        public ImmutableDictionary<int, VendingMachineItem> GetProductMap()
        {
            return _vendingMachineMap.ToImmutableDictionary();
        }

        private void PopulateVendingItem()
        {
            foreach (var product in _inMemoryRepository.GetProducts())
            {
                VendingMachineItem vendingMachineItem;

                switch (product.ProductCode)
                {
                    //orderNumber, productName, price, totalItem
                    case "COKE":
                        vendingMachineItem = new Coke(product.OrderNumber, product.Name, product.Price, product.Quantity);
                        _vendingMachineMap.TryAdd(product.OrderNumber, vendingMachineItem);
                        break;

                    case "MM":
                        vendingMachineItem = new MM(product.OrderNumber, product.Name, product.Price, product.Quantity);
                        _vendingMachineMap.TryAdd(product.OrderNumber, vendingMachineItem);
                        break;

                    case "WATER":
                        vendingMachineItem = new Water(product.OrderNumber, product.Name, product.Price, product.Quantity);
                        _vendingMachineMap.TryAdd(product.OrderNumber, vendingMachineItem);
                        break;

                    case "SNICKER":
                        vendingMachineItem = new Snickers(product.OrderNumber, product.Name, product.Price, product.Quantity);
                        _vendingMachineMap.TryAdd(product.OrderNumber, vendingMachineItem);
                        break;

                    default:
                        throw new InvalidOperationException($"Inavlid product code {product.ProductCode} vending machine does not support.");
                }
            }
        }
    }
}
