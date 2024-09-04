using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Alumno
{
    public class Ejercicio3
    {
        private string _nombre;
        private string _matricula;
        private string _carrera;
        private int _promedio;
        private int[] _calificaciones;

        public void guardaDatos(string Nombre, string Matricula, string Carrera, int[] Calificaciones)
        {
            this._nombre = Nombre;
            this._matricula = Matricula;
            this._carrera = Carrera;
        
            this._calificaciones = Calificaciones;
        }

        public double carcularPromedio()
        {
          if (_calificaciones.Length == null || _calificaciones.Length == 0)
              return 0;
          
         int promedio = 0;
            foreach (int calificacion in _calificaciones)
            {
              promedio += calificacion;
            }
         
            return (double) promedio / _calificaciones.Length;

        }

        public void mostrarInformacion()
        {
            Console.WriteLine("Datos del estudiante");
            Console.WriteLine($"Nombre: {_nombre}");
            Console.WriteLine($"Matricula: {_matricula}");
            Console.WriteLine($"Carrera: {_matricula}");
            Console.WriteLine($"Promedio: {carcularPromedio()}");
        }



    }
}
