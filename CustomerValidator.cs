using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bit706_as2
{
    internal class CustomerValidator
    {
        private const int nameMaxLength = 20;
        private const int addressMaxLength = 50;

        public void ValidateName(string firstName, string lastName)
        {
            IsEmpty(firstName, "First Name");
            IsEmpty(lastName, "Last Name");
            IsFirstNameTooLong(firstName);
            IsLastNameTooLong(lastName);
            ContainsOnlyLetters(firstName, "First Name");
            ContainsOnlyLetters(lastName, "Last Name");
        }

        public void ValidateAddress(string address)
        {
            IsAddressTooLong(address);
            ContainsOnlyAlphanumeric(address, "Address");
            IsEmpty(address, "Address");
        }

        public void ValidateCity(string city)
        {
            IsEmpty(city, "City");
            ContainsOnlyLetters(city, "City");
        }

        public void ValidatePhone(string phone)
        {
            IsEmpty(phone, "Phone");
            IsPhoneNumberValid(phone);
        }

        public void ValidateEmail(string email)
        {
            IsEmpty(email, "email");
            IsEmailValid(email);
        }

        //-------Generic validations------------

        private void ContainsOnlyLetters(string input, string field)
        {
            bool containsOnlyLetters = Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
            if (!containsOnlyLetters) { throw new Exception($"{field} must not have special characters or numbers"); }

        }

        private void ContainsOnlyAlphanumeric(string input, string field)
        {
            //checks for special characters
            bool containsOnlyLetters = Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$");
            if (!containsOnlyLetters) { throw new Exception($"{field} must not have special characters"); }
        }

        private void IsEmpty(string input, string field)
        {
            if (input == "") { throw new Exception($"{field} is required"); }
        }

        // _______________________ Name Validations ______________________
        private void IsLastNameTooLong(string lastName)
        {
            if (lastName.Length > nameMaxLength)
            {
                throw new Exception($"Last name must be less than {nameMaxLength} characters long");
            }
        }

        private void IsFirstNameTooLong(string firstName)
        {
            if (firstName.Length > nameMaxLength)
            {
                throw new Exception($"First name must be less than {nameMaxLength} characters long");
            }
        }

        // _______________________ Address ______________________
        public void IsAddressTooLong(string address)
        {
            if (address.Length > addressMaxLength)
            {
                throw new Exception($"Address must be less than {addressMaxLength} characters long");
            }
        }

        // _______________________ Phone ______________________

        public void IsPhoneNumberValid(string input)
        {
            //allows + at the start, and ()
            bool containsOnlyLetters = Regex.IsMatch(input, @"^\+?\d+[\d\-\(\)]*$");
            if (!containsOnlyLetters) { throw new Exception($"Phone must be a valid phone number"); }
        }
        // _______________________ Email ______________________

        public void IsEmailValid(string input)
        {
            //allows alphanumeric and checks for @ and .
            bool containsOnlyLetters = Regex.IsMatch(input, @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$");
            if (!containsOnlyLetters) { throw new Exception($"please enter a valid email"); }
        }
    }
}
