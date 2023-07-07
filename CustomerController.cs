using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    class CustomerController
    {
        private string errorMessage;

        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        private List<Customer> customerList = new List<Customer>();

        public bool AddCustomer(string firstName, string lastName)
        {
            //do the things
            return false;
        }

        public bool FindCustomerByName(string name)
        {
            return false;
        }

        public bool EditCustomer(string firstName, string lastName)
        {
            return false;
        }

        public bool DeleteCustomer(string firstName, string lastName)
        {
            return false;
        }
    }
}
