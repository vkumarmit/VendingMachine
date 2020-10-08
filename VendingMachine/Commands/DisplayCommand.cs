using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Commands
{
    public class DisplayCommand : ICommand
    {
        private string _commandParam;
        public DisplayCommand(string commandparam)
        {
            _commandParam = commandparam;
        }
        public BaseParam Params => new BaseParam() { CommandParam = _commandParam };

        public bool Execute()
        {
            if (!_commandParam.Equals("inv"))
                throw new Exception("Invalid command");

            return true;
        }
    }
}
