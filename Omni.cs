using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Principal;


namespace Bit706_as2
{
    [Serializable]
    public class Omni : Account
    {
        //Omni
        //• Interest rates paid only on balances over $1000; specified overdraft permitted; fee
        //for failed transactions

        private readonly string accountType = "Omni";
        // account parameters set here as defaults
        private decimal interestRate = 4.0m;
        private decimal fee = 10.0m; //set fee for failed transaction
        private decimal overdraft = 1000.0m; //set overdraft limit

        public decimal InterestRate { get => interestRate; set => interestRate = value; }
        public decimal Fee { get => fee; set => fee = value; }

        public Omni(int customerId, decimal newBalance) : base(customerId, newBalance) { }

        public Omni(int customerId, decimal newBalance, decimal newInterestRate) : this(customerId, newBalance)
        {
            this.interestRate = newInterestRate;
        }

        public Omni(int customerId, decimal newBalance, decimal newInterestRate, decimal newFee) : this(customerId, newBalance, newInterestRate)
        {
            this.fee = newFee;
        }

        public Omni(int customerId, decimal newBalance, decimal newInterestRate, decimal newFee, decimal newOverdraft) : this(customerId, newBalance, newInterestRate, newFee)
        {
            this.overdraft = newOverdraft;
        }

        public override bool Withdraw(decimal amount)
        {
            if (balance - amount >= -overdraft)
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
                this.RecordTransaction($"Added {this.InterestRate}% to {this.Summary}");
                return interest;
            }
            return 0;
        }

        // gets the FeeRate based on strategy and applies the fee
        public void ApplyFee()
        {
            decimal rate = FeeStrategy.FeeRate();
            balance -= fee * rate;
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
