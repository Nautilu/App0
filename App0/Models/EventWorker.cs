using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App0.Models
{
    public class EventWorker
    {
        public Worker Worker { get; set; }
        public string WorkerName { get { return Worker != null ? Worker.FIO : null; } }
        public Event Event { get; set; }
        public string EventName { get { return Event != null ? Event.Name : null; } }
    }
}
