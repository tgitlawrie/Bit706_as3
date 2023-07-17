namespace Bit706_as2
{
    public class Everyday : Account
    {
        //Everyday
        //• No interest, no overdraft, no fees

        private readonly string accountType = "Everyday";

        public Everyday(decimal newBalance) : base(newBalance) { }

        public override string Info()
        {
            return accountType + " " 
                + id
                + "\n" + base.Info();
        }
    }//end of everydayclass
}
