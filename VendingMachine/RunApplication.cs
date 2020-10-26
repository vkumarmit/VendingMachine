using System;
using VendingMachine.CustomeException;
using VendingMachine.Service;

namespace VendingMachine
{
    public class RunApplication
    {
        //We can use Auto fac to resolve the dependency.
        private readonly IVendingMachineService _vendingMachineService;

        public RunApplication()
        {
            _vendingMachineService = new VendingMachineService();
        }

        public void Run()
        {

            while (true)
            {
                try
                {
                    PrintHeader();
                    Console.WriteLine();
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("1 or Inv] Display Vending Machine Items");
                    Console.WriteLine("2] Purchase");
                    Console.WriteLine("X] Close");
                    Console.WriteLine();
                    Console.Write("What option do you want to select? ");

                    var input = Console.ReadLine() ?? "X";

                    if (input == "1" || input.Equals("inv", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Displaying Items");
                        DisplayProducts(_vendingMachineService);
                    }
                    else if (input == "2")
                    {
                        DisplayProducts(_vendingMachineService);
                        Console.WriteLine();
                        Console.WriteLine("Please enter the purchase order example: order <amount> <item_number> <quantity>");
                        var purchaseCommand = Console.ReadLine();

                        var commandArgs = purchaseCommand?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (commandArgs?.Length != 4 ||
                            string.IsNullOrWhiteSpace(commandArgs[0]) ||
                            string.IsNullOrWhiteSpace(commandArgs[1]) ||
                            string.IsNullOrWhiteSpace(commandArgs[2]) ||
                            string.IsNullOrWhiteSpace(commandArgs[3]))
                        {
                            Console.WriteLine("Invalid command. Please try again.");
                            Console.WriteLine();
                            continue;
                        }

                        if (!string.IsNullOrWhiteSpace(commandArgs[0]) && !commandArgs[0].Equals("order", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Invalid command. Please try again.");
                            Console.WriteLine();
                            continue;
                        }

                        Purchase(commandArgs, _vendingMachineService);
                    }
                    else if (input.ToUpper() == "X")
                    {
                        Console.WriteLine("Are you sure you want to close the vending machine? press Y to close else N.");

                        var closeInput = Console.ReadLine() ?? "Y";

                        if (closeInput.ToUpper() == "N")
                        {
                            Console.WriteLine();
                            continue;
                        }
                        else if (closeInput.ToUpper() == "Y")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Please try again.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Please try again.");
                        Console.WriteLine();
                    }

                    Console.ReadLine();
                    Console.Clear();
                }
                catch (PurchaseException ex)
                {
                    //PurchaseException is a custom exception so ex.Message controls the purchase messages for the user.
                    //PurchaseException should not contains the any technical or exception messages.
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("There is problem with Test Vending Machine.Sorry for inconvenience. we will fix shortly.");
                }
            }
        }

        public void Purchase(string[] commandArgs, IVendingMachineService vendingMachineService)
        {
            decimal.TryParse(commandArgs[1], out var priceOut);

            int.TryParse(commandArgs[2], out var orderNumberOut);

            int.TryParse(commandArgs[3], out var quantityOut);

            if (vendingMachineService.Purchase(orderNumberOut, quantityOut, priceOut))
            {
                Console.WriteLine("Your order is successful enjoy!!");
                Console.WriteLine();
                Console.WriteLine("Thank You!!");
                Console.WriteLine();
            }
        }
        private void DisplayProducts(IVendingMachineService vendingMachineService)
        {
            foreach (var vendingMachineItem in vendingMachineService.GetProductMap())
            {
                Console.WriteLine(vendingMachineItem.Value.TotalItem > 0
                    ? $"{vendingMachineItem.Key} {vendingMachineItem.Value.ProductName} ({vendingMachineItem.Value.TotalItem}): ${vendingMachineItem.Value.Price}"
                    : $"{vendingMachineItem.Key} {vendingMachineItem.Value.ProductName} ({vendingMachineItem.Value.TotalItem}): ${vendingMachineItem.Value.Price}: is out of stock.");
            }
        }
        private static void PrintHeader()
        {
            Console.WriteLine("*******************Welcome To The Best Vending Machine*******************");
        }
    }
}

