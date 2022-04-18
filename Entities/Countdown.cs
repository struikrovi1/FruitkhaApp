using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Countdown : BaseEntity
    {
 
        public string  months { get; set; }

        public string days { get; set; }

        public string year { get; set; }

        public string hours { get; set; }

        public string minutes { get; set; }

        public string seconds { get; set; }
        public decimal Discount { get; set; }   

        public string dealDescr { get; set; }  
   
        public DateTime Month { get; set; }

        

    }
}
