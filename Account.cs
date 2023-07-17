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
        protected decimal balance;

        public List<string> history = new List<string>();

        public Account()
        {
            id = nextID;
            nextID++;
        }

        public Account(decimal newBalance) : this()
        {
            balance = newBalance;
        }

        public int ID { get => id; set => id = value; }// this will be needed for serialisation later
        public decimal Balance { get => balance; set => balance = value; }
       

        public void Deposit(decimal amount)
        {
            balance += amount;
            //TODO add history
        }

        public virtual bool Withdraw(decimal amount)
        {
            //check if sufficient funds
            if(amount <= balance) {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
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
    }
}
