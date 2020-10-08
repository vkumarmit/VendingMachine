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
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_Order_Number_Invalid()
        {
            Action action = () =>
            {
                var cut = new VendingMachineService();
                cut.Purchase(-1, 1, 1.1M);
            };

            Assert.Throws<PurchaseException>(action);
        }


        [Fact]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_quantity_Invalid()
        {
            Action action = () =>
            {
                var cut = new VendingMachineService();
                cut.Purchase(1, 0, 1.1M);
            };

            Assert.Throws<PurchaseException>(action);
        }

        [Fact]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_price_Invalid()
        {
            Action action = () =>
            {
                var cut = new VendingMachineService();
                cut.Purchase(1, 1, -1);
            };

            Assert.Throws<PurchaseException>(action);
        }

        [Fact]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_purchased_quantity_not_valid()
        {
            Action action = () =>
            {
                var cut = new VendingMachineService();
                cut.Purchase(1, 2, 1);
            };

            Assert.Throws<PurchaseException>(action);
        }

        [Fact]
        public void VendingMachineServiceTests_should_throw_the_PurchaseException_when_quantity_is_greater_that_total_item()
        {
            Action action = () =>
            {
                var cut = new VendingMachineService();
                cut.Purchase(1, 200, 1);
            };

            Assert.Throws<PurchaseException>(action);
        }

        [Fact]
        public void VendingMachineServiceTests_should_Purchase_the_product()
        {
            var cut = new VendingMachineService();
            var actual = cut.Purchase(1, 1, 1.25M);
            actual.Should().BeTrue();
        }

        [Fact]
        public void VendingMachineServiceTests_should_return_the_GetProductMap()
        {
            var cut = new VendingMachineService();
            var actual = cut.GetProductMap();
            actual.Should().NotBeNull();
            actual.Count.Should().BeGreaterThan(0);
        }
    }
}
