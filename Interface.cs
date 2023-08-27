using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit706_as2
{
    public interface IObserver
    {
        void Update(Account a);//change
    }
    public interface ISubject
    {
        void AttachObserver(IObserver observer);
        void NotifyObservers(Account a);
    }

    public interface FeeStrategy
    {
        decimal FeeRate();
    }

    [Serializable]
    public class StaffFeeStrategy : FeeStrategy
    {
        public decimal FeeRate()
        {
            return 0.5m;
        }
    }
    [Serializable]
    public class StandardFeeStrategy : FeeStrategy 
    {
        public decimal FeeRate() 
        {
            return 1;
        }
    }
}
