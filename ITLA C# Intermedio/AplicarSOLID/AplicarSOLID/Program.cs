using AplicarSOLID.Courses;
using AplicarSOLID.Entities;
using AplicarSOLID.Repository.RepoStudent;
using AplicarSOLID.Service;

public class Program
{
    private static void Main(string[] args)
    {
        var studentRepository = new StudentRepository();
        var paymentService = new PaymentService();
        var subscriptionService = new SubcribeService(studentRepository, paymentService);

        var student = new Student
        {
            StudentId = 1,
            FirstName = "Anyerson",
            LastName = "Nin",
            DoB = new DateTime(2002,2,5),
            email = "ninmisael@gmail.com",
            Address1 = "casa",
            Address2 = "Trabajo",
            City = "Santo Domingo",
            State = "Dominicana",
            Zipcode = "0414556"


        };

        var course = new CouseOnline {Name ="C# Intermedio" ,Type = "Online", Price = 500.90m };

        subscriptionService.Subcribe(student, course);
    }
}