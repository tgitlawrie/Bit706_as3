using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    [Serializable]
    internal class AccountData
    {
        private int nextId;
        private static AccountData accountData;

        private AccountData() { }

        public static AccountData Get()
        {
            if (accountData == null)
            {
                accountData = new AccountData();
            }
            return accountData;
        }

        public static int NextId
        {
            get
            {
                Get().nextId++;
                return Get().nextId;
            }
        }
        public static void Set(AccountData a)
        {
            accountData = a;
        }
    }
}
