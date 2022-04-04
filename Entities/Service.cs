using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Service : BaseEntity
    {
        public string IconUrl { get; set; }

        

        public string Title { get; set; }

        public string? SubTitle { get; set; }

        public bool? IsIndex { get; set; }  

    }
}
