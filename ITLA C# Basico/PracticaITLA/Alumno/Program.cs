using Alumno;
using static System.Runtime.InteropServices.JavaScript.JSType;

Ejercicio3 ejercicio3 = new Ejercicio3();

try
{
    Console.WriteLine("Registro estudiantil");
    Console.WriteLine("--------------------");
    Console.Write("Ingrese el Nombre : ");
    string Nombre = Console.ReadLine();

    Console.Write("Ingrese la Matricula: ");
    string Matricula = Console.ReadLine();

    Console.Write("Ingrese la Carrera: ");
    string Carrera = Console.ReadLine();

    Console.Write("Ingrese la cantidad de calificaciones separadas por comas(,): ");
    int valoresCalificaciones = int.Parse(Console.ReadLine());

    int[] Calificaciones = new int [valoresCalificaciones];

    for (int i = 0; i < valoresCalificaciones; i++)
    {
        Console.Write($"Introduce la calificación {i + 1}: ");
        Calificaciones[i] = int.Parse(Console.ReadLine());
    }

    ejercicio3.guardaDatos (Nombre, Matricula, Carrera, Calificaciones);

    Console.WriteLine("");
    ejercicio3.mostrarInformacion();
}
catch (FormatException ex)
{
    Console.WriteLine("Error: Ingresó un formato no válido. Por favor, ingrese un número válido.");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
}