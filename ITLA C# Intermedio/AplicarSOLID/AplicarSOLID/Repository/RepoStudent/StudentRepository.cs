using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicarSOLID.Entities;

namespace AplicarSOLID.Repository.RepoStudent
{
    public class StudentRepository : IStudent
    {
        public void Save(Student student)
        {
            Console.WriteLine("Guardando estudiante en la base de datos...");
            // Implementación de Entity Framework u otra
        }

        public void Delete(Student student)
        {
            Console.WriteLine("Eliminando estudiante de la base de datos...");
            // Implementación de borrado, con verificación de suscripciones
        }
    }
}
