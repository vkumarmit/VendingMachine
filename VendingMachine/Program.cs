using System;
using VendingMachine.Commands;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Invalid command.");
            }

            var runApplication = new RunApplication();

            if (args.Length == 1)
            {
                if (string.IsNullOrWhiteSpace(args[0]))
                {
                    Console.WriteLine("Invalid command.");
                }

                var command = new DisplayCommand(args[0]);
                runApplication.Run(command);
            }

            else if (args.Length == 4)
            {
                if (string.IsNullOrWhiteSpace(args[0]) ||
                    string.IsNullOrWhiteSpace(args[1]) ||
                    string.IsNullOrWhiteSpace(args[2]) ||
                    string.IsNullOrWhiteSpace(args[3]))
                {
                    Console.WriteLine("Invalid command.");
                }
                //string orderPrefix, decimal price, int itemNumber, int quantity)
                decimal priceOut;
                var price = decimal.TryParse(args[1], out priceOut);

                int lineNumberOut;
                var lineNumber = int.TryParse(args[2], out lineNumberOut);


                int quantityOut;
                var quanity = int.TryParse(args[3], out quantityOut);

                var command = new PurchaseCommand(args[0], priceOut, lineNumberOut, quantityOut);
                runApplication.Run(command);
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}
