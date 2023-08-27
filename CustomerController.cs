using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private AccountsController accountsController;

        public CustomerController(AccountsController accountsController)
        {
            this.accountsController = accountsController;
        }

        public bool AddCustomer(string firstName, string lastName, string address, string city, string phone, string email, bool isStaff)
        {
            firstName = firstName.Trim().ToLower();
            lastName = lastName.Trim().ToLower();
            try
            {
                validator.ValidateName(firstName, lastName);
                validator.ValidateAddress(address);
                validator.ValidateCity(city);
                validator.ValidatePhone(phone);
                validator.ValidateEmail(email);
                //TODO validate the rest of these things
                customerList.Add(new Customer(firstName, lastName, address, city, phone, email, isStaff));
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
                validator.ValidateAddress(customer.Address);
                validator.ValidateCity(customer.City);
                validator.ValidatePhone(customer.Phone);
                validator.ValidateEmail(customer.Email);

                foundCustomer.FirstName = customer.FirstName;
                foundCustomer.LastName = customer.LastName;
                foundCustomer.Address = customer.Address;
                foundCustomer.City = customer.City;
                foundCustomer.Phone = customer.Phone;
                foundCustomer.Email = customer.Email;
                foundCustomer.IsStaff = customer.IsStaff;

                //update fee strategy for all accounts
                foreach (Account account in accountsController.FindAccountByCustomer(customer.ID))
                {
                    if (customer.IsStaff)
                    {
                        account.FeeStrategy = new StaffFeeStrategy();
                    }
                    else
                    {
                        account.FeeStrategy = new StandardFeeStrategy();
                    }
                }
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
