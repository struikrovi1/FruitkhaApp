using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }   

        public string? NewsText { get; set; }    

        public string PhotoUrl { get; set; }    

        public int Views { get; set; }

        public DateTime PublishDate { get; set; }   

       public string MyUserId { get; set; }   

        public MyUser MyUser { get; set; }


    }
}
