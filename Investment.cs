using System;
using System.Drawing.Text;
using System.Runtime.InteropServices.ComTypes;

namespace Bit706_as2
{
    public class Investment : Account
    {
  
        //Investment
        //• Interest rates(varied) paid on all funds, no overdraft allowed, fee incurred for failed
        //transaction

        private readonly string accountType = "Investment";
        private decimal interestRate; //
        private decimal fee = 40.0m; //set default fee for failed transaction

        public Investment(decimal newBalance) : base(newBalance) { }
        public Investment(decimal newBalance, decimal newInterestRate) : this(newBalance)
        {
            this.interestRate = newInterestRate;
        }

        public Investment(decimal newBalance, decimal newInterestRate, decimal newFee) : this(newBalance, newInterestRate)
        {
            this.fee = newFee;
        }

        public decimal AddInterest()
        {
            decimal interest = balance * (interestRate / 100);
            balance += interest;
            return interest;
        }

        public void ApplyFee()
        {
            balance -= fee;
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
