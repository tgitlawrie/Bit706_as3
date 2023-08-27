using System;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;

namespace Bit706_as2
{
    [Serializable]
    public class Investment : Account
    {

        //Investment
        //• Interest rates(varied) paid on all funds, no overdraft allowed, fee incurred for failed
        //transaction

        private readonly string accountType = "Investment";
        private decimal interestRate = 4.0m; //hardcoded for this assessment
        private decimal fee = 10.0m; //set default fee for failed transaction

        public Investment(int customerId, decimal newBalance) : base(customerId, newBalance) { }
        public Investment(int customerId, decimal newBalance, decimal newInterestRate) : this(customerId, newBalance)
        {
            this.interestRate = newInterestRate;
        }

        public Investment(int customerId, decimal newBalance, decimal newInterestRate, decimal newFee) : this(customerId, newBalance, newInterestRate)
        {
            this.fee = newFee;
        }

        public decimal InterestRate { get => interestRate; set => interestRate = value; }
        public decimal Fee { get => fee; set => fee = value; }

        public decimal AddInterest()
        {
            decimal interest = balance * (interestRate / 100);
            balance += interest;
            this.RecordTransaction($"Added {this.InterestRate}% to {this.Summary}");
            return interest;
        }

        // gets the strategy and applies fee
        public void ApplyFee()
        {
            decimal rate = FeeStrategy.FeeRate();
            balance -= fee * rate;
        }

        public override string Info()
        {
            return accountType
                + " " + id
                + "\nInterest Rate: " + interestRate + "%"
                + "\nFailed transaction fee: $" + fee
                + "\n" + base.Info(); //check - overdraft works to display overdraft as a positive amount
        }
    }
}
