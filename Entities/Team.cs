﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Team : BaseEntity
    {

        public string Name { get; set; }

        public string? Position { get; set; }

        public string PhotoUrl { get; set; }    
    }
}
