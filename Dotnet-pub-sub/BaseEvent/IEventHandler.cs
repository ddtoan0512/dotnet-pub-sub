using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEvent
{
    public interface IEventHandler<T> where T : EventBase
    {
        void Run(T data);
        Task RunAsync(T data);
    }
}
