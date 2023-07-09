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

        public Customer(string firstName, string lastName)
        {
            int nameMaxLength = 20;
            bool containsOnlyLetters = Regex.IsMatch(firstName + lastName, @"^[a-zA-Z]+$");
            firstName = firstName.Trim().ToLower();
            lastName = lastName.Trim().ToLower();

            //validation guard clauses
            if (firstName == "") { throw new Exception("You must enter a first name!"); }
            if (lastName == "") { throw new Exception("You must enter a last name!"); }
            if (firstName.Length > nameMaxLength)
            {
                throw new Exception($"First name must be less than {nameMaxLength} characters long");
            }
            if (lastName.Length > nameMaxLength)
            {
                throw new Exception($"Last name must be less than {nameMaxLength} characters long");
            }
            if (!containsOnlyLetters) { throw new Exception("Customer name must not have special characters or numbers"); }

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
