using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App0.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Member() { }
        public Member(int ID, string Name, string PhoneNumber, string Email)
        {
            this.ID = ID;
            this.FIO = Name;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }
    }
}
