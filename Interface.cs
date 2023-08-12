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
}
