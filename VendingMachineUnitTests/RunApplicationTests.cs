using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using VendingMachine;
using VendingMachine.Service;
using Xunit;

namespace VendingMachineUnitTests
{
    public class RunApplicationTests
    {

        [Fact]
        public void RunApplication_with_command_press_x()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var testInputQuit = new StringReader("x");
            Console.SetIn(testInputQuit);

            var cut = new RunApplication();
            cut.Run();

            output.ToString().Should().Be(ExpectedHeaderText_With_X_Command());
        }

        [Theory]
        [InlineData("inv")]
        [InlineData("Inv")]
        [InlineData("1")]
        public void RunApplication_with_command_press_Inv_or_1(string command)
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var testInputInv = new StringReader(command);
            Console.SetIn(testInputInv);

            var cut = new RunApplication();
            cut.Run();

            output.ToString().Should().Contain(ExpectedHeaderText_With_Inv_Command());
        }

        [Fact]
        public void RunApplication_with_command_press_2()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var testInputQuit = new StringReader("2");
            Console.SetIn(testInputQuit);

            var cut = new RunApplication();
            cut.Run();

            output.ToString().Should().Contain("Invalid command. Please try again.");
        }

        [Fact]
        public void RunApplication_with_with_purchase_command()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var testPurchaseCommand = "order 1.25 1 1".Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cut = new RunApplication();
            cut.Purchase(testPurchaseCommand, new VendingMachineService());

            output.ToString().Should().Be(Purchase_Item_Success_Message());
        }


        private string ExpectedHeaderText_With_X_Command()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("*******************Welcome To The Best Vending Machine*******************");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Main Menu");
            stringBuilder.AppendLine("1 or Inv] Display Vending Machine Items");
            stringBuilder.AppendLine("2] Purchase");
            stringBuilder.AppendLine("X] Close");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("What option do you want to select? Are you sure you want to close the vending machine? press Y to close else N.");
            return stringBuilder.ToString();
        }

        private string ExpectedHeaderText_With_Inv_Command()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("*******************Welcome To The Best Vending Machine*******************");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Main Menu");
            stringBuilder.AppendLine("1 or Inv] Display Vending Machine Items");
            stringBuilder.AppendLine("2] Purchase");
            stringBuilder.AppendLine("X] Close");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("What option do you want to select? Displaying Items");
            stringBuilder.AppendLine("1 Coke (10): $1.25");
            stringBuilder.AppendLine("2 M&M's (15): $1.89");
            stringBuilder.AppendLine("3 Water (5): $0.89");
            stringBuilder.AppendLine("4 Snicker (7): $2.05");
            return stringBuilder.ToString();
        }

        private string Purchase_Item_Success_Message()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your order is successful enjoy!!");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Thank You!!");
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }
}
