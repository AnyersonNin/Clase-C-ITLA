using Libro;
using System.Timers;

Ejercicio2 ejercicio2 = new Ejercicio2();

try
{
    Console.WriteLine("Bienvenidos a la Biblioteca");
    Console.WriteLine("---------------------------");
    Console.Write("Ingrece el Titulo: ");
    string titulo = Console.ReadLine();

    Console.Write("Ingrece el Autor: ");
    string autor = Console.ReadLine();

    Console.Write("Ingrese las paginas: ");
    int pagina = int.Parse(Console.ReadLine());
    Console.WriteLine("");


    ejercicio2.guardaInfo(titulo, autor, pagina);

    ejercicio2.MostrarInformacion();

    if (ejercicio2.EsLargo())
    {
        Console.WriteLine("El libro de 500 o mas paginas");
    }
    else
    {
        Console.WriteLine("El libro tiene menos de 500 paginas");
    }

}
catch (FormatException ex)
{
    Console.WriteLine("Error: Ingresó un formato no válido. Por favor, ingrese un número válido.");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
}