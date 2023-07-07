using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class Customer
    {
        private int nextID = 1;
        private int iD;
        private string firstName;
        private string lastName;

        public Customer() {
            iD = nextID;
            nextID++;
        }

        public Customer(string firstName, string lastName) :this() {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        //returns the customers information
        public string CustomerInfo()
        {
            return iD.ToString() + " | " + firstName + " " + lastName;
        }
    }
}
