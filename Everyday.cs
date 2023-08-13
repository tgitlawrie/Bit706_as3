namespace Bit706_as2
{
    public class Everyday : Account
    {
        //Everyday
        //• No interest, no overdraft, no fees

        private readonly string accountType = "Everyday";

        public Everyday(int customerId, decimal newBalance) : base(customerId,newBalance) { }

        public string AccountType => accountType;

        public override string Info()
        {
            return AccountType + " " 
                + id
                + "\n" + base.Info();
        }
    }//end of everydayclass
}
