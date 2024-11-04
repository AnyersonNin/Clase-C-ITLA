using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicarSOLID.Entities;
namespace AplicarSOLID.Courses
{
    public interface ICourse
    {
        bool Validate(Student student, Course course);
    }
}
