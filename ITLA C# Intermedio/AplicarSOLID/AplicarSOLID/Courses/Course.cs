using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicarSOLID.Courses
{
    public abstract class Course
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

    }
}
