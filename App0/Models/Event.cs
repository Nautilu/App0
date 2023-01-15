using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App0.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Result { get; set; }
        public string Info { get; set; }
        public EForm Form { get; set; }
        public string FormName { get { return Form != null ? Form.Name : null; } }
        public Status Status { get; set; }
        public string StatusName { get { return Status != null ? Status.Name : null; } }
        public Event()
        {
        }
        public Event(int ID, string Name, string StartTime, string EndTime, string Info, string Result,
            EForm Form, Status Status)
        {
            this.ID = ID;
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Info = Info;
            this.Result = Result;
            this.Form = Form;
            this.Status = Status;
        }
    }
}
