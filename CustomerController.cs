using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class CustomerController
    {
        private string errorMessage;

        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        public List<Customer> customerList = new List<Customer>();
        private CustomerValidator validator = new CustomerValidator();

        public bool AddCustomer(string firstName, string lastName)
        {
            firstName = firstName.Trim().ToLower();
            lastName = lastName.Trim().ToLower();
            try
            {
                validator.ValidateName(firstName, lastName);
                customerList.Add(new Customer(firstName, lastName));
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }

        public Customer FindCustomerByID(string customer)
        {
            string[] inputs = customer.Split('|'); //seperates the id number from the name
            int id = int.Parse(inputs[0]); //grab the id number from the inputs array

            Customer foundCustomer = customerList.FirstOrDefault(c => c.ID == id);
            if (foundCustomer != null)
            {
                return foundCustomer;
            }

            return null;
        }

        public bool EditCustomer(Customer customer)
        {
            Customer foundCustomer = customerList.FirstOrDefault(c => c.ID == customer.ID);
            if (foundCustomer == null) { return false; }
            try
            {
                //validate name
                validator.ValidateName(customer.FirstName, customer.LastName);

                foundCustomer.FirstName = customer.FirstName;
                foundCustomer.LastName = customer.LastName;
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                customerList.Remove(customer);
                return true;
            }
            catch (Exception e)
            {
                errorMessage = ($"Customer not found\n{e.Message}");
                return false;
            }

        }
    }
}
