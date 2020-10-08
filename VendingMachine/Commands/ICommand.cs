using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Commands
{
    public interface  ICommand
    {
        bool Execute();

        BaseParam Params{ get; }
    }
}
