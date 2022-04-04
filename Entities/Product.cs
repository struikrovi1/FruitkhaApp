﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }    

        public string? Description { get; set; }

        public bool IsFeatured { get; set; }

        public decimal Price { get; set; }  

        public bool Available { get; set; }   

        public string PhotoUrl { get; set; }

        public int CategoryId { get; set; } 

        public virtual Category Category { get; set; }  
    }
}
