using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.CustomeException;
using VendingMachine.Service;
using Xunit;

namespace VendingMachineUnitTests.Service
{
    public class VendingMachineServiceTests
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(-1, 1, 1)]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_Order_Number_Invalid(int orderNumber, int quantity, decimal price)
        {
            void Action()
            {
                var cut = new VendingMachineService();
                cut.Purchase(orderNumber, quantity, price);
            }

            Assert.Throws<PurchaseException>((Action) Action);
        }

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(1, -1, 1)]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_quantity_Invalid(int orderNumber, int quantity, decimal price)
        {
            void Action()
            {
                var cut = new VendingMachineService();
                cut.Purchase(orderNumber, quantity, price);
            }

            Assert.Throws<PurchaseException>((Action) Action);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(1, 1, -1)]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_price_Invalid(int orderNumber, int quantity, decimal price)
        {
            void Action()
            {
                var cut = new VendingMachineService();
                cut.Purchase(orderNumber, quantity, price);
            }

            Assert.Throws<PurchaseException>((Action) Action);
        }

        [Fact]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_purchased_quantity_not_valid()
        {
            void Action()
            {
                var cut = new VendingMachineService();
                cut.Purchase(1, 2, 1);
            }

            Assert.Throws<PurchaseException>((Action) Action);
        }

        [Fact]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_quantity_is_greater_that_total_item()
        {
            void Action()
            {
                var cut = new VendingMachineService();
                cut.Purchase(1, 200, 1);
            }

            Assert.Throws<PurchaseException>((Action) Action);
        }

        [Theory]
        [InlineData(1, 1, 1.25)]
        [InlineData(2, 1, 1.89)]
        [InlineData(3, 1, .89)]
        [InlineData(4, 1, 2.05)]
        public void VendingMachineServiceTests_should_Purchase_the_product(int orderNumber, int quantity, decimal price)
        {
            var cut = new VendingMachineService();
            var actual = cut.Purchase(orderNumber, quantity, price);
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 2, 1.25 * 2, 10)]
        [InlineData(2, 3, 1.89 * 3, 15)]
        [InlineData(3, 5, .89 * 5, 5)]
        [InlineData(4, 7, 2.05 * 7, 7)]
        public void VendingMachineServiceTests_should_Purchase_the_product_and_quantity_should_be_decrement(int orderNumber, int quantity, decimal price, int totalQuantity)
        {
            var cut = new VendingMachineService();
            var actual = cut.Purchase(orderNumber, quantity, price);
            var getProductMap = cut.GetProductMap();
            var product = getProductMap[orderNumber];

            actual.Should().BeTrue();
            product.TotalItem.Should().Be(totalQuantity - quantity);
        }

        [Fact]
        public void VendingMachineServiceTests_should_populated_the_items()
        {
            var cut = new VendingMachineService();
            var actual = cut.GetProductMap();
            actual.Should().NotBeNull();
            actual.Count.Should().BeGreaterThan(0);
        }
    }
}
