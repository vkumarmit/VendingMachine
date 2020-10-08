using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Aggregator
{
    public interface IAggregateRoot
    {
        Guid ProductId => Guid.NewGuid();
    }

}
