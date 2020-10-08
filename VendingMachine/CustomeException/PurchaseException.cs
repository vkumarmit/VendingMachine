using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.CustomeException
{
    public class PurchaseException : Exception
    {
        public PurchaseException(string exceptionMessage) : base(exceptionMessage)
        {

        }

        public PurchaseException(string exceptionMessage, Exception innerException) : base(exceptionMessage, innerException)
        {

        }
    }
}
