using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class FailedTransactionException : Exception
    {
        public FailedTransactionException() { }
        public FailedTransactionException(string message) : base(message){ }

    }
}
