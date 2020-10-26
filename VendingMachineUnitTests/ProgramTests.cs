using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace VendingMachineUnitTests
{
    public class ProgramTests
    {

        //[Fact]
        public void Program_should_run_the_application_and_close()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var testInputQuit = new StringReader("x");
            Console.SetIn(testInputQuit);

            VendingMachine.Program.Main(null);
            output.ToString().Should().NotBeNullOrEmpty();
        }
    }
}
