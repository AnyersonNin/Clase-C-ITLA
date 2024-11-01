
using punto_en_el_plano;

Ejercicio1 ejercicio1 = new Ejercicio1();
try
{
    Console.WriteLine("Bienvenidos al Plano Carteciano");
    Console.WriteLine("-------------------------------");
    Console.WriteLine("");
    Console.WriteLine("Ubica a cualquier punto en el plano");
    Console.Write("Ingrece el valor de X: ");
    int x = int.Parse(Console.ReadLine());

    Console.Write("Ingrece el valor de Y: ");
    int y = int.Parse(Console.ReadLine());
    Console.WriteLine("");
    ejercicio1.guardaValor(x, y);

    ejercicio1.imprimeValores();
}
catch (FormatException ex)
{
    Console.WriteLine("Error: Ingresó un formato no válido. Por favor, ingrese un número válido.");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
}