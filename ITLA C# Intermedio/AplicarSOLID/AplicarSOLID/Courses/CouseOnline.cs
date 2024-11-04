using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicarSOLID.Entities;
namespace AplicarSOLID.Courses
{
    public class CouseOnline: Course , ICourse
    {
        public bool Validate(Student student, Course course)
        {
            // Implementación de validación para cursos en línea
            Console.WriteLine("Validando curso en línea...");
            return true;
        }
    }
}
