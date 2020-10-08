using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using VendingMachine.Model;

namespace VendingMachine.Service
{
    public interface IVendingMachineService
    {
        bool Purchase(int orderNumber, int quantity, decimal price);

        ImmutableDictionary<int, VendingMachineItem> GetProductMap();

    }
}
