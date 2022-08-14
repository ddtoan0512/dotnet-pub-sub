using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEvent.Event
{
    public class SampleEvent : EventBase
    {
        public string Text { get; set; } = string.Empty;
    }
}
