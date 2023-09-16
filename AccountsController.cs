using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bit706_as2
{
    public class AccountsController : ISubject
    {
        public List<Account> accounts = new List<Account>();
        public List<IObserver> observers = new List<IObserver>(); //change

        private string errorMessage;

        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        
        /// <summary>
        /// Creates a new account to be associated with given customer
        /// </summary>
        /// <param name="accountType">Everyday,Investment or Omni</param>
        /// <param name="Customer">customer object</param>
        /// <param name="initialBalance">Decimal initial balance, defaults to 0</param>
        /// <returns>true if creation is successful</returns>
        /// <exception cref="AccountException">thrown when an invalid account type is provided</exception>
        public bool CreateAccount(string accountType, Customer Customer, decimal initialBalance = 0)
        {
            Account newAccount;
            switch (accountType)
            {
                case "Everyday":
                    newAccount = new Everyday(Customer.ID, initialBalance);
                    accounts.Add(newAccount);
                    break;
                case "Investment":
                    newAccount = new Investment(Customer.ID, initialBalance);
                    accounts.Add(newAccount);
                    break;
                case "Omni":
                    newAccount = new Omni(Customer.ID, initialBalance);
                    accounts.Add(newAccount);
                    break;
                default:
                    throw new AccountException("Account Creation Error");
            }
            if (Customer.IsStaff) 
            { 
                newAccount.FeeStrategy = new StaffFeeStrategy();
            }
            else
            {
                newAccount.FeeStrategy = new StandardFeeStrategy();
            }


            NotifyObservers(newAccount);
            return true;
        }

        /// <summary>
        /// finds the accounts with the accountID
        /// </summary>
        /// <param name="accountId">Id number of the Account</param>
        /// <returns>the account with a matching id</returns>
        public Account FindAccountById(int accountId)
        {
            Account account = accounts.Find(a => a.ID == accountId);
            return account;
        }

        /// <summary>
        /// finds all accounts owned by customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>a list of accounts</returns>
        public List<Account> FindAccountByCustomer(int customerID)
        {
            return accounts.Where(a => a.CustomerID == customerID).ToList();
        }

        /// <summary>
        /// Deposits a specified amount into an account with a matching id
        /// </summary>
        /// <param name="accountId">account ID</param>
        /// <param name="amount">amount to deposit</param>
        /// <returns>returns true if deposit is successful</returns>
        public bool Deposit(int accountId, decimal amount)
        {
            Account account = FindAccountById(accountId);
            account.Deposit(amount);
            account.RecordTransaction($"Deposited ${amount} into {account.Summary}");
            return true;
        }

        /// <summary>
        /// Withdraws a specified amount from an account with a matching id
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <param name="amount">amount to withdraw</param>
        /// <returns>returns true if withdraw is successful</returns>
        /// <exception cref="FailedTransactionException">Throws Exception if the account balance is less than the withdraw amount</exception>
        public bool Withdraw(int accountId, decimal amount)
        {
            Account account = FindAccountById(accountId);
            if (amount <= 0)
            {
                throw new AccountException("Amount must be greater than 0");
            }
            if (!account.Withdraw(amount))
            {
                throw new FailedTransactionException("insufficient funds");
            }
            account.RecordTransaction($"Withdrew ${amount} from {account.Summary}");
            return true;
        }

        /// <summary>
        /// transfers an amount from a from account and to a to account
        /// uses withdraw()<see cref="Withdraw(int, decimal)"/> 
        /// and 
        /// Deposit() <see cref="Deposit(int, decimal)"/> 
        /// </summary>
        /// <param name="fromAccount">account to transfer from</param>
        /// <param name="toAccount">account to transfer to</param>
        /// <param name="amount">amount to transfer</param>
        /// <returns>returns true if transfer is successful</returns>
        /// <exception cref="AccountException">throws exceptions if transfer fails failure will likely be in the withdraw and deposit method</exception>
        public bool Transfer(int fromAccount, int toAccount, decimal amount)
        {
            Account from = FindAccountById(fromAccount);
            Account to = FindAccountById(toAccount);
            if (Withdraw(from.ID, amount))
            {
                if (Deposit(to.ID, amount))
                {
                    return true;
                }
            }
            else
            {
                throw new AccountException("Transfer Failed");
            }
            return false;
        }

        /// <summary>
        /// calls add interest on appropriate accounts
        /// <see cref="AddInterest(int)"/>
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>true if successfull</returns>
        /// <exception cref="Exception">returns exception if account is not omni or investment</exception>
        public bool AddInterest(int accountId)
        {
            Account account = FindAccountById(accountId);
            if (account is Investment investment)
            {
                investment.AddInterest();
                return true;
            }
            if (account is Omni omni)
            {
                omni.AddInterest();
                return true;
            }
            return true;
        }

        /// <summary>
        /// applies fees to affected accounts
        /// </summary>
        /// <param name="accountId">id of account to apply fees to</param>
        public void ApplyFee(int accountId)
        {
            Account account = FindAccountById(accountId);
            if (account is Investment investment)
            {
                investment.ApplyFee();
                account.RecordTransaction($"Fee of ${investment.Fee} charged to {account.Summary}");
            }
            if (account is Omni omni)
            {
                omni.ApplyFee();
                account.RecordTransaction($"Fee of ${omni.Fee} charged to {account.Summary}");
            }
        }

        /// <summary>
        /// gets account info based on provided account id
        /// </summary>
        /// <param name="accountId">account id</param>
        /// <returns>returns a string with account info</returns>
        public string GetAccountInfo(int accountId)
        {
            Account account = FindAccountById(accountId);
            return account.Info();
        }

        /// <summary>
        /// gets a summary of an account based on provided account id
        /// </summary>
        /// <param name="accountId">account id</param>
        /// <returns>returns a string containing account summary</returns>
        public string GetAccountSummary(int accountId)
        {
            Account account = FindAccountById(accountId);
            if (account is Investment investment) { return $"{account.ID} : Investment : Balance: ${account.Balance}"; }
            else if (account is Omni omni) { return $"{account.ID} : Omni : Balance: ${account.Balance}"; }
            else if (account is Everyday everyday) { return $"{account.ID} : Everyday : Balance: ${account.Balance}"; }
            return null;
        }

        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">The observer to be attached.</param>
        public void AttachObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// Notifies all attached observers of a change in state.
        /// </summary>
        /// <param name="a">The account that has changed state.</param>
        public void NotifyObservers(Account a)
        {
            foreach (IObserver obs in observers)
            {
                obs.Update(a);
            }
        }
    }
}
