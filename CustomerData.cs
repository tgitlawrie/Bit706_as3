using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    [Serializable]
    internal class CustomerData
    {
        private int nextId;
        private static CustomerData customerData;

        public static int NextId
        {
            get
            {
                Get().nextId++;
                return Get().nextId;
            }
        }

        public static CustomerData Get()
        {
            if (customerData == null)
            {
                customerData = new CustomerData();
            }
            return customerData;
        }

        public static void Set(CustomerData c)
        {
            customerData = c;
        }
        private CustomerData() { }
    }
}
