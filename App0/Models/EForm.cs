using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App0.Models
{
    public class EForm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public EForm(){}
        public EForm(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
