using AplicarSOLID.Courses;
using AplicarSOLID.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicarSOLID.Service
{
    public class PaymentService: IPayment
    {
        public void ProcessPayment(Student student, Course course)
        {
            Console.WriteLine($"Procesando pago de {course.Price:C} para el estudiante {student.FirstName} {student.LastName}");
            // Implementación de pago
        }
    }
}
