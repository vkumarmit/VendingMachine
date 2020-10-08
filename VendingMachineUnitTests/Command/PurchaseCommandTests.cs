using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Commands;

namespace VendingMachineUnitTests.Command
{
    public class PurchaseCommandTests
    {
        public void PurchaseCommand_should_exceute()
        {
            var cut = new PurchaseCommand("order", 1.25M, 1, 1);
            var actual = cut.Execute();
            actual.Should().BeTrue();
        }
    }
}
