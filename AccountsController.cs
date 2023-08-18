using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public class AccountsController : ISubject
    {
        public List<Account> accounts = new List<Account>();
        public List<IObserver> observers = new List<IObserver>(); //change

        private string errorMessage;

        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        public bool CreateAccount(string accountType, int customerID, decimal initialBalance = 0)
        {
            Account newAccount;
            switch (accountType)
            {
                case "Everyday":
                    newAccount = new Everyday(customerID, initialBalance);
                    accounts.Add(newAccount);
                        break;
                case "Investment":
                    newAccount = new Investment(customerID, initialBalance);
                    accounts.Add(newAccount);
                    break;
                case "Omni":
                    newAccount = new Omni(customerID, initialBalance);
                    accounts.Add(newAccount);
                    break;
                default:
                    throw new AccountException("Account Creation Error");
            }
            NotifyObservers(newAccount);
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

        public string GetAccountSummary(int accountId)
        {
            Account account = FindAccountById(accountId);
            if (account is Investment investment) { return $"{account.ID} : Investment : Balance: ${account.Balance}"; }
            else if (account is Omni omni) { return $"{account.ID} : Omni : Balance: ${account.Balance}"; }
            else if (account is Everyday everyday) { return $"{account.ID} : Everyday : Balance: ${account.Balance}"; }
            return null;
        }

        public void AttachObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(Account a)
        {
            foreach(IObserver obs in observers)
            {
                obs.Update(a);
            }
        }
    }
}
