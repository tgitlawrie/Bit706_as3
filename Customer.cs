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
        protected static int nextID = 1;
        protected int iD;
        protected string firstName;
        protected string lastName;

        
        private string address;
        private string city;
        private string phone;
        private string email;
        private bool isStaff = false;

        //      Dictionary<ID,AccountObject>
        private Dictionary<int,Account> CustAccounts = new Dictionary<int,Account>();

        public Customer() {
            iD = nextID;
            nextID++;
        }
        // just this one constructor for all the fields as they are all required.
        public Customer(
            string firstName, 
            string lastName, 
            string address, 
            string city, 
            string phone, 
            string email,
            bool isStaff
            ) : this()
        {                          
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.phone = phone;
            this.email = email;
            this.isStaff = isStaff;
        }


        public int ID { get => iD; set => iD = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public bool IsStaff { get => isStaff; set => isStaff = value; }

        //returns the customers information
        public string CustomerInfo()
        {
            return iD.ToString() + " | " + firstName + " " + lastName;
        }

        public override string ToString() { return firstName + " " + lastName; }
    }
}
