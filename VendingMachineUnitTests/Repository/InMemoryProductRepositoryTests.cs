using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Aggregator;
using VendingMachine.Repository;
using Xunit;

namespace VendingMachineUnitTests.Repository
{
    public class InMemoryProductRepositoryTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Product_Code_Is_Null_or_empty()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.ProductCode = string.Empty;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Name_Is_Null_or_empty()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.Name = string.Empty;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_description_Is_Null_or_empty()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.Description = string.Empty;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Quantity_Is_negative()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.Quantity = -1;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Quantity_Is_zero()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.Quantity = 0;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Price_Is_negative()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.Price = -1;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Price_Is_zero()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.Price = 0;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Actual_Cost_Is_negative()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.ActualCost = -1;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_throw_the_Argument_Exception_When_Actual_Cost_Is_zero()
        {
            var testProduct = _fixture.Create<Product>();

            Action action = () =>
            {
                var cut = new InMemoryProductRepository();
                testProduct.ActualCost = 0;

                cut.AddProduct(testProduct);
            };

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void InMemoryProductRepository_should_init_the_Product()
        {
            var cut = new InMemoryProductRepository();
            cut.Init();

            var actual = cut.GetProducts();
            actual.Should().NotBeNull();
            actual.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void InMemoryProductRepository_should_Return_the_product_by_filter_product_code()
        {
            var testCokeProduct = new Product()
            {
                ProductCode = "COKE",
                Name = "Coke",
                OrderNumber = 1,
                ActualCost = 1.25M,
                Price = 1.25M,
                Description = "Diet Coke",
                Quantity = 10
            };

            var cut = new InMemoryProductRepository();
            cut.Init();

            var actual = cut.GetProductByProductCode("COKE");
            actual.Should().NotBeNull();

            actual.Should().Be(testCokeProduct);
        }

        [Fact]
        public void InMemoryProductRepository_should_add_the_given_product()
        {
            var testCokeProduct = _fixture.Create<Product>();
            var cut = new InMemoryProductRepository();

            cut.AddProduct(testCokeProduct);
            var actual = cut.GetProductByProductCode(testCokeProduct.ProductCode);
           
            actual.Should().NotBeNull();
            actual.Should().Be(testCokeProduct);
        }
    }
}
