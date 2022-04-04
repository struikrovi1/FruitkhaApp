using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Slider : BaseEntity
    {
        public string PhotoUrl { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string SubHeader { get; set; } = null!;

        public bool? RightText { get; set; }

        public bool? LeftText { get; set; }
        public bool IsDeleted { get; set; }

        public bool? CenterText { get; set; }
    }
}
