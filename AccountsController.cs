using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class AccountsController
    {
        private List<Account> accounts = new List<Account>();

        private string errorMessage;

        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        public bool CreateAccount(string accountType, int customerID, decimal initialBalance = 0)
        {
            switch (accountType)
            {
                case "Everyday":
                    accounts.Add(new Everyday(customerID, initialBalance)); 
                        break;
                case "Investment":
                    accounts.Add(new Investment(customerID, initialBalance));
                    break;
                case "Omni":
                    accounts.Add(new Omni(customerID, initialBalance));
                    break;
                default:
                    throw new AccountException("Account Creation Error");
            }
           
            return true;
        }

        private Account FindAccountById(int accountId)
        {
            Account account = accounts.Find(a => a.ID == accountId);
            return account;
        }

        /// <summary>
        /// finds all accounts owned by customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>a list of accounts</returns>
        public List<Account> FindAccountByCustomer(int customerID) {
            return accounts.Where(a => a.CustomerID == customerID).ToList();
        }

        public bool Deposit(int accountId, decimal amount)
        {
            Account account = FindAccountById(accountId);
            account.Deposit(amount);
            return true;
        }

        public bool Withdraw(int accountId, decimal amount) {
            Account account = FindAccountById(accountId);
            account.Withdraw(amount);
            return true;
        }

        /// <summary>
        /// calls add interest on appropriate accounts
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>true if successfull</returns>
        /// <exception cref="Exception">returns exception if account is not omni or investment</exception>
        public bool AddInterest(int accountId)
        {
            Account account = FindAccountById(accountId);
            if (account is Investment investment) { 
                investment.AddInterest(); 
                return true;
            }
            if(account is Omni omni)
            {
                omni.AddInterest();
                return true;
            }
            throw new Exception("Account does not have interest");
        }

        public bool ApplyFee(int accountId)
        {
            Account account = FindAccountById(accountId);
            if (account is Investment investment)
            {
                investment.ApplyFee();
                return true;
            }
            if (account is Omni omni)
            {
                omni.ApplyFee();
                return true;
            }
            throw new Exception("Account does not have interest");
        }

        public string GetAccountInfo(int accountId)
        {
            Account account = FindAccountById(accountId);
            return account.Info();
        }
    }
}
