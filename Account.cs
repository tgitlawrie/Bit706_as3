using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bit706_as2
{
    [Serializable]
    public abstract class Account
    {
        
        protected int id;
        protected int customerId;
        protected decimal balance;

        public FeeStrategy FeeStrategy { get; set; }

        public List<string> history = new List<string>();

        public Account()
        {
            id = AccountData.NextId;
        }

        public Account(int customerId) : this()
        {
            this.customerId = customerId;
        }

        public Account(int customerId, decimal newBalance) : this(customerId)
        {
            balance = newBalance;
        }

        public int ID { get => id;}
        public decimal Balance { get => balance; set => balance = value; }
        public int CustomerID { get => customerId; set => customerId = value; }

        public bool Deposit(decimal amount)
        {
            if (amount < 0) { 
                throw new FailedTransactionException("Deposit amount must be positive");
            }
            balance += amount;
            return true;
            //TODO add history
        }

        public virtual bool Withdraw(decimal amount)
        {
            // check amount is positive, front end should validate before it gets here
            if (amount < 0) { throw new FailedTransactionException("Withdrawal amount must be positive"); }
            //check if sufficient funds
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
                throw new FailedTransactionException("Insufficient Funds");
            }
        }

        public void Transfer(Account from, Account to, decimal amount)
        {
            if (amount < 0) { throw new FailedTransactionException("amount must be positive"); }

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
   
        public string Summary 
        {
            get
            {
                string type = "";
                if (this is Investment) 
                {
                    type = "Investment"; 
                }
                else if (this is Omni)
                {
                    type = "Omni"; 
                }
                else if (this is Everyday) 
                {
                    type = "Everyday"; 
                }
                return $"Account ID: {ID}, Type: {type}, Balance: ${Math.Round(Balance, 2)}"; 
            }
        }
    }
}
