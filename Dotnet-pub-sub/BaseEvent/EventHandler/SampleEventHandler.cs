using BaseEvent.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEvent.EventHandler
{
    public class SampleEventHandler : IEventHandler<SampleEvent>
    {
        public void Run(SampleEvent data)
        {
            Console.WriteLine("Run " + data.Text);
        }

        public Task RunAsync(SampleEvent data)
        {
            return Task.Run(() =>
            {
                Run(data);
            });
        }
    }
}
