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
        
        public void ValidateName(string firstName, string lastName)
        {
            IsFirstNameEmpty(firstName);
            IsLastNameEmpty(lastName);
            IsFirstNameTooLong(firstName);
            IsLastNameTooLong(lastName);
            NameContainsOnlyLetters(firstName, lastName);
        }

        private void NameContainsOnlyLetters(string firstName, string lastName)
        {
            bool containsOnlyLetters = Regex.IsMatch(firstName + lastName, @"^[a-zA-Z]+$");
            if (!containsOnlyLetters) { throw new Exception("Customer name must not have special characters or numbers"); }
        }

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

        private void IsLastNameEmpty(string lastName)
        {
            if (lastName == "") { throw new Exception("You must enter a last name!"); }
        }

        private void IsFirstNameEmpty(string firstName)
        {
            if (firstName == "") { throw new Exception("You must enter a first name!"); }
        }
    }
}
