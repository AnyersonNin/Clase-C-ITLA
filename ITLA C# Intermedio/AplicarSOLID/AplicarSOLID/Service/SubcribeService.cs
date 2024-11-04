using AplicarSOLID.Repository.RepoStudent;
using AplicarSOLID.Courses;
using AplicarSOLID.Entities;

namespace AplicarSOLID.Service
{
    public class SubcribeService
    {

        private readonly IStudent _student;
        private readonly IPayment _payment;
        private readonly Dictionary<string, ICourse> _course;

        public SubcribeService(IStudent student , IPayment payment)
        {
            _student = student;
            _payment = payment;
            _course = new Dictionary<string, ICourse>
            {
                { "Online", new CouseOnline() },
                { "Live", new CourseOnside() }
            };
        }

        public void Subcribe (Student student,Course course)
        {
            if (_course.TryGetValue(course.Type, out var Valor) && Valor.Validate(student, course))
            {
                _payment.ProcessPayment(student, course);
                Console.WriteLine($"Suscripción completada para el curso {course.Type}");
                _student.Save(student);

                Console.WriteLine("");
                Console.WriteLine("Datos del Estudiante:");
                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Nombre: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Email: {student.email}");
                Console.WriteLine($"Dirección: {student.Address1}, {student.City}, {student.State} - {student.Zipcode}");

                Console.WriteLine("\nDatos del Curso:");
                Console.WriteLine($"Nombre del Curso:{course.Name}");
                Console.WriteLine($"Tipo de Curso: {course.Type}");
                Console.WriteLine($"Precio del Curso: {course.Price:C}");
            }
            else
            {
                Console.WriteLine("No se pudo completar la suscripción debido a fallos de validación.");
            }

        }
    }
}
