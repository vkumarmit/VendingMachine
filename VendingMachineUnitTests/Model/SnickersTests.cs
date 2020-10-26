using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using FluentAssertions;
using VendingMachine.Model;
using Xunit;

namespace VendingMachineUnitTests.Model
{
    public class SnickersTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Coke_should_build_the_VendingMachineItem()
        {
            var testOrderNumber = _fixture.Create<int>();
            var testProductName = _fixture.Create<string>();
            var testPrice = _fixture.Create<decimal>();
            var testTotalItem = _fixture.Create<int>();

            var cut = new Snickers(testOrderNumber, testProductName, testPrice, testTotalItem);

            cut.OrderNumber.Should().Be(testOrderNumber);
            cut.ProductName.Should().Be(testProductName);
            cut.Price.Should().Be(testPrice);
            cut.TotalItem.Should().Be(testTotalItem);
        }

        [Fact]
        public void VendingMachineItem_should_decrement_the_Quantity()
        {
            var testOrderNumber = _fixture.Create<int>();
            var testProductName = _fixture.Create<string>();
            var testPrice = _fixture.Create<decimal>();
            var testTotalItem = _fixture.Create<int>();

            var testPurchaseQuantity = 1;

            var cut = new Snickers(testOrderNumber, testProductName, testPrice, testTotalItem);

            cut.DecrementItem(testPurchaseQuantity);

            cut.TotalItem.Should().Be(testTotalItem - testPurchaseQuantity);
        }
    }
}
