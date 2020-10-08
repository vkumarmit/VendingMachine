using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using VendingMachine.Aggregator;

namespace VendingMachine.Repository
{
    public class InMemoryProductRepository : IRepository
    {
        // for now I am using flyweight pattern but flyweight can be replace with distributed cache.
        private readonly ConcurrentDictionary<string, Product> _inMemeoryRepository = new ConcurrentDictionary<string, Product>();

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentException($"{nameof(product)} can not be null or empty.");

            if (string.IsNullOrWhiteSpace(product.ProductCode))
                throw new ArgumentException($"{nameof(product.ProductCode)} can not be null or empty.");

            if (string.IsNullOrEmpty(product.Name))
                throw new ArgumentException($"{nameof(product.Name)} can not be null or empty.");

            if (string.IsNullOrEmpty(product.Description))
                throw new ArgumentException($"{nameof(product.Description)} can not be null or empty.");

            if (product.Quantity <= 0)
                throw new ArgumentException($"{nameof(product.Quantity)} can not be zero or negative.");

            if (product.OrderNumber <= 0)
                throw new ArgumentException($"{nameof(product.OrderNumber)} can not be zero or negative.");

            if (product.Price <= 0)
                throw new ArgumentException($"{nameof(product.Price)} can not be zero or negative.");

            if (product.ActualCost <= 0)
                throw new ArgumentException($"{nameof(product.ActualCost)} can not be zero or negative.");

            _inMemeoryRepository.TryAdd(product.ProductCode, product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _inMemeoryRepository.Values.ToImmutableList();
        }

        public Product GetProductByProductCode(string productCode)
        {
            Product productOut;
            _inMemeoryRepository.TryGetValue(productCode, out productOut);
            return productOut;
        }

        public void Init()
        {
            var cokeProduct = new Product()
            {
                ProductCode = "COKE",
                Name = "Coke",
                OrderNumber = 1,
                ActualCost = 1.25M,
                Price = 1.25M,
                Description = "Diet Coke",
                Quantity = 10
            };

            var mmProduct = new Product()
            {
                ProductCode = "MM",
                Name = "M&M's",
                OrderNumber = 2,
                ActualCost = 1.89M,
                Price = 1.89M,
                Description = "M&M's",
                Quantity = 15
            };

            var waterProduct = new Product()
            {
                ProductCode = "WATER",
                Name = "Water",
                OrderNumber = 3,
                ActualCost = .89M,
                Price = .89M,
                Description = "Water",
                Quantity = 5
            };

            var snickerProduct = new Product()
            {
                ProductCode = "SNICKER",
                Name = "Snicker",
                OrderNumber = 4,
                ActualCost = 2.05M,
                Price = 2.05M,
                Description = "Snicker",
                Quantity = 7
            };

            AddProduct(cokeProduct);
            AddProduct(mmProduct);
            AddProduct(waterProduct);
            AddProduct(snickerProduct);
        }
    }
}
