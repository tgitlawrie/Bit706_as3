using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bit706_as2
{

    public abstract class Account
    {
        protected static int nextID = 1;
        protected int id;
        protected int customerId;
        protected decimal balance;

        public List<string> history = new List<string>();

        public Account()
        {
            id = nextID;
            nextID++;
        }

        public Account(int customerId) : this()
        {
            this.customerId = customerId;
        }

        public Account(int customerId, decimal newBalance) : this(customerId)
        {
            balance = newBalance;
        }

        public int ID { get => id; set => id = value; }// this will be needed for serialisation later
        public decimal Balance { get => balance; set => balance = value; }
        public int CustomerID { get => customerId; set => customerId = value; }

        public void Deposit(decimal amount)
        {
            if (amount < 0) { throw new FailedWithdrawalException("Deposit amount must be positive"); }
            balance += amount;
            //TODO add history
        }

        public virtual bool Withdraw(decimal amount)
        {
            // check amount is positive, front end should validate before it gets here
            if (amount < 0) { throw new FailedWithdrawalException("Withdrawal amount must be positive"); }
            //check if sufficient funds
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            else
            {
                throw new FailedWithdrawalException("Insufficient Funds");
                //return false;
            }
        }

        public void Transfer(Account from, Account to, decimal amount)
        {
            if (amount < 0) { throw new FailedWithdrawalException("amount must be positive"); }

                from.balance -= amount;
                to.balance += amount;
        }

        public void RecordTransaction(string transaction)
        {
            history.Insert(0, transaction); //insert to start of list to preserve order
            if (history.Count > 5)
            {
                history.RemoveAt(5); //Remove the oldest transaction
            }
        }

        public virtual string Info()
        {
            return "Balance $" + Math.Round(balance, 2).ToString();
        }
   
        public string Summary // a property to return a summary of the account
        {
            get
            {
                string type = ""; // a variable to store the type of the account
                if (this is Investment) // check if the account is an investment account
                {
                    type = "Investment"; // set the type to investment
                }
                else if (this is Omni) // check if the account is an omni account
                {
                    type = "Omni"; // set the type to omni
                }
                else if (this is Everyday) // check if the account is an everyday account
                {
                    type = "Everyday"; // set the type to everyday
                }
                return $"Account ID: {ID}, Type: {type}, Balance: ${Balance}"; // return a summary string with the ID, type and balance of the account
            }
        }
    }
}
