using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class Customer
    {
        private static int nextID = 1;
        private int iD;
        private string firstName;
        private string lastName;

        private CustomerValidator validator = new CustomerValidator();

        public Customer(string firstName, string lastName)
        {
           

            //validate customer name before creating
            validator.ValidateName(firstName, lastName);
           
            //id generation placed here instead of using overloaded constructors
            //to ensure id numbers are only assigned to valid customers
            iD = nextID;
            nextID++;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int ID { get => iD; set => iD = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        //returns the customers information
        public string CustomerInfo()
        {
            return iD.ToString() + " | " + firstName + " " + lastName;
        }

        public override string ToString() { return firstName + " " + lastName; }
    }
}
