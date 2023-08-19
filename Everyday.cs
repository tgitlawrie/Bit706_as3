using System;

namespace Bit706_as2
{
    [Serializable]
    public class Everyday : Account
    {
        //Everyday
        //• No interest, no overdraft, no fees

        private readonly string accountType = "Everyday";

        public Everyday(int customerId, decimal newBalance) : base(customerId,newBalance) { }

        public override string Info()
        {
            return accountType + " " 
                + id
                + "\n" + base.Info();
        }
    }//end of everydayclass
}
