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

        public Investment(int customerId, decimal newBalance) : base(customerId, newBalance) { }
        public Investment(int customerId, decimal newBalance, decimal newInterestRate) : this(customerId, newBalance)
        {
            this.interestRate = newInterestRate;
        }

        public Investment(int customerId, decimal newBalance, decimal newInterestRate, decimal newFee) : this(customerId, newBalance, newInterestRate)
        {
            this.fee = newFee;
        }

        public string AccountType => accountType;

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
            return AccountType
                + " " + id
                + "\nInterest Rate: " + interestRate + "%"
                + "\nFailed transaction fee: $" + fee
                + "\n" + base.Info(); //check - overdraft works to display overdraft as a positive amount
        }
    }
}
