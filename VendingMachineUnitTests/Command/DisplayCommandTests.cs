using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Commands;

namespace VendingMachineUnitTests.Command
{
    public class DisplayCommandTests
    {
        public void DisplayCommand_should_exceute()
        {
            var cut = new DisplayCommand("inv");
            var actual = cut.Execute();

            actual.Should().BeTrue();
        }
    }
}
