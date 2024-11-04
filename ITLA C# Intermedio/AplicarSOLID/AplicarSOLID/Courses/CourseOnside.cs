using AplicarSOLID.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicarSOLID.Courses
{
    public class CourseOnside : Course , ICourse
    {
        public bool Validate(Student student, Course course)
        {
            // Implementación de validación para cursos en vivo
            Console.WriteLine("Validando curso en vivo...");
            return true;
        }
    }
}
