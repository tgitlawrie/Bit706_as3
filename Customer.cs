using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class Customer
    {
        private static int nextID = 1;
        private int iD;
        private string firstName;
        private string lastName;

        public Customer(string firstName, string lastName)
        {
            firstName = firstName.Trim().ToLower();
            lastName = lastName.Trim().ToLower();

            if (firstName == "") { throw new Exception("You must enter a first name!"); }

            if (lastName == "") { throw new Exception("You must enter a last name!"); }

            //id generation placed here instead of using overloaded constructors
            //to ensure id numbers are only assigned to valid customers
            iD = nextID;
            nextID++;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        //returns the customers information
        public string CustomerInfo()
        {
            return iD.ToString() + " | " + firstName + " " + lastName;
        }

        public override string ToString() { return firstName + " " + lastName; }
    }
}
