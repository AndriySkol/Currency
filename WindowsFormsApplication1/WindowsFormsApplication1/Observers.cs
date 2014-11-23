using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IObserver
    {
        void UpdatedObservable();
    }
    public interface IObservable
    {
        void Subscribe(IObserver observ);
        void Unscribe(IObserver observ);
        void NotifyMessengers();
    }
}
