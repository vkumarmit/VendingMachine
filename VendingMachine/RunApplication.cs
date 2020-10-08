using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VendingMachine.Commands;
using VendingMachine.CustomeException;
using VendingMachine.Service;
using ICommand = VendingMachine.Commands.ICommand;

namespace VendingMachine
{
    public class RunApplication
    {
        public void Run(ICommand command)
        {

            try
            {
                var vendingMachineService = new VendingMachineService();

                try
                {
                    Console.WriteLine("Wecome to the test vending machine.");
                    if (command is DisplayCommand)
                    {
                        if (command.Execute() && command.Params.CommandParam.Equals("inv"))
                        {
                            DisplayProducts(vendingMachineService);
                        }
                    }
                    else if (command is PurchaseCommand)
                    {
                        if (command.Execute() && command.Params.CommandParam.Equals("order"))
                        {
                            if (vendingMachineService.Purchase(command.Params.OrderNumberCommandParam, command.Params.QuantityCommandParam, command.Params.PriceCommandParam))
                            {
                                Console.WriteLine($"Your oder is sucessfull enjoy!!");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid command");
                    }
                }
                catch (PurchaseException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("There is problem with Test Vending Machine.Sorry for inconvience. we willfix shortly.");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("There is problem with Test Vending Machine.Sorry for inconvience. we will fix shortly.");
            }
        }

        private void DisplayProducts(VendingMachineService vendingMachineService)
        {
            foreach (var vendingMachineItem in vendingMachineService.GetProductMap())
            {
                if (vendingMachineItem.Value.TotalItem > 0)
                {
                    Console.WriteLine($"{vendingMachineItem.Key} {vendingMachineItem.Value.ProductName} ({vendingMachineItem.Value.TotalItem}): ${vendingMachineItem.Value.Price}");
                }
                else
                {
                    Console.WriteLine($"{vendingMachineItem.Key}: {vendingMachineItem.Value.ProductName} is out of stock.");
                }
            }
        }
    }
}

