using System;

class Program
{
    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Seleccione una opción del menú:");
            Console.WriteLine("1. Calcular suma y promedio de 10 números");
            Console.WriteLine("2. Contar piezas de hierro aptas para fabricar perfiles");
            Console.WriteLine("3. Salir");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        CalcularSumaYPromedio();
                        break;
                    case 2:
                        ContarPiezasAptas();
                        break;
                    case 3:
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }

            Console.WriteLine();
        }
    }

    static void CalcularSumaYPromedio()
    {
        int contador = 0;
        int suma = 0;

        Console.WriteLine("Ingrese 10 números enteros:");

        while (contador < 10)
        {
            Console.Write($"Número {contador + 1}: ");
            int numero;
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                suma += numero;
                contador++;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
            }
        }

        double promedio = (double)suma / 10;

        Console.WriteLine($"La suma de los números es: {suma}");
        Console.WriteLine($"El promedio de los números es: {promedio:F2}");
    }

    static void ContarPiezasAptas()
    {
        double longitudMinima = 1.20;
        double longitudMaxima = 1.30;
        int contarPiezasAptas = 0;
        double longitud = 0;
        int cantidad = 0;
        int index = 1;

        try { 
        Console.WriteLine("Ingrese la Cantidad de piezas: ");
        cantidad = int.Parse(Console.ReadLine());


        while (index <= cantidad)
        {

            Console.WriteLine("Ingrese la longitud de la siguiente pieza: ");
            longitud = double.Parse(Console.ReadLine());

            if (longitud >= longitudMinima && longitud <= longitudMaxima)
            {
                contarPiezasAptas++;
            }
            index++;
        }

        Console.WriteLine($"El número de piezas aptas para fabricar perfiles es: {contarPiezasAptas}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Ingresó un formato no válido. Por favor, ingrese un número válido.");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error: El número ingresado es demasiado grande o demasiado pequeño.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
        }
    }
}