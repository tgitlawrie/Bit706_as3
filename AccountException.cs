using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class AccountException : Exception
    {
        public AccountException() { }
        public AccountException(string message) : base(message) { }
    }
}
