using AplicarSOLID.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicarSOLID.Courses;


namespace AplicarSOLID.Service
{
    public interface IPayment
    {
        void ProcessPayment(Student student, Course course);
    }
}
