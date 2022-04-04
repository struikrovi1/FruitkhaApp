using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment : BaseEntity
    {

        public string Name { get; set; }    

        public string Email { get; set; }   

        public string CommentText { get; set; } 

        public bool IsDeleted { get; set; } 

        public bool IsSuccess { get; set; } 

        public int NewsId { get; set; } 

        public News News { get; set; }  

        public DateTime CreatedDate { get; set; }   


    }
}
