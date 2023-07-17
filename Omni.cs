using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;


namespace Bit706_as2
{
    public class Omni : Account
    {
        //Omni
        //• Interest rates paid only on balances over $1000; specified overdraft permitted; fee
        //for failed transactions

        private readonly string accountType = "Omni";
        // account parameters set here as defaults
        private decimal interestRate = 4.0m;
        private decimal fee = 20.0m; //set fee for failed transaction
        private decimal overdraft = 1000.0m; //set overdraft limit

        public Omni(decimal newBalance) : base(newBalance) { }

        public Omni(decimal newBalance, decimal newInterestRate): this(newBalance)
        {
            this.interestRate = newInterestRate;
        }

        public Omni(decimal newBalance, decimal newInterestRate,decimal newFee): this(newBalance, newInterestRate)
        {
            this.fee = newFee;
        }

        public Omni(decimal newBalance, decimal newInterestRate,decimal newFee, decimal newOverdraft): this(newBalance,newInterestRate,newFee) 
        {
            this.overdraft = newOverdraft;
        }

        public override bool Withdraw(decimal amount)
        {
            if(balance - amount >= -overdraft)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public decimal AddInterest()
        {
            if (balance >= 1000)
            {
                decimal interest = balance * (interestRate / 100);
                balance += interest;
                return interest;
            }
            return 0;
        }

        public void ApplyFee()
        {
            //do something to apply the fees
            balance -= fee;
        }
        public override string Info()
        {
            return accountType
                + " " + id
                + "\nInterest Rate: " + interestRate + "% on balances over $1000"
                + "\nOverdraft Limit $" + overdraft
                + "\nFailed transaction fee: $" + fee
                + "\n" + base.Info(); //check - overdraft works to display overdraft as a positive amount
        }
    }
}
