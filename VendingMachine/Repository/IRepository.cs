using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Aggregator;

namespace VendingMachine.Repository
{
    public interface IRepository
    {
        void Init();
        void AddProduct(Product product);

        IEnumerable<Product> GetProducts();

        Product GetProductByProductCode(string productCode);
    }
}
