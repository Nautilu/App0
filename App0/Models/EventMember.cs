using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App0.Models
{
    public class EventMember
    {
        public Event Event { get; set; }
        public string EventName { get { return Event != null ? Event.Name : null; } }
        public Member Member { get; set; }
        public string MemberName { get { return Member != null ? Member.FIO : null; } }
    }
}
