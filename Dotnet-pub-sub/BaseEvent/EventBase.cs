using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEvent
{
    public class EventBase
    {
        public EventBase()
        {
            CurrentDate = DateTime.Now;
        }

        public DateTime CurrentDate { get; set; }
    }
}
