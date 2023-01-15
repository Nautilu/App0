using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App0.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
        public Department Department { get; set; }
        public string DepartmentName { get { return Department != null ? Department.Name : null; } }
        public Job Job { get; set; }
        public string JobName { get { return Job != null ? Job.Name : null; } }
        public Worker() { }
        public Worker(int ID, string FIO, string PhoneNumber, Department Department, Job Job )
        {
            this.ID = ID;
            this.FIO = FIO;
            this.PhoneNumber = PhoneNumber;
            this.Department = Department;
            this.Job = Job;
        }
    }
}
