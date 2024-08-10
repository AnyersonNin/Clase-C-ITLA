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
        Console.WriteLine("Ingrese la longitud mínima para considerar las piezas aptas:");
        double longitudMinima;
        if (!double.TryParse(Console.ReadLine(), out longitudMinima))
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            return;
        }

        Console.WriteLine("Ingrese la longitud máxima para considerar las piezas aptas:");
        double longitudMaxima;
        if (!double.TryParse(Console.ReadLine(), out longitudMaxima))
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            return;
        }

        int contarPiezasAptas = 0;
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Ingrese la longitud de la siguiente pieza (o ingrese '0' para finalizar):");
            double longitud;
            if (double.TryParse(Console.ReadLine(), out longitud))
            {
                if (longitud == 0)
                {
                    continuar = false;
                }
                else if (longitud >= longitudMinima && longitud <= longitudMaxima)
                {
                    contarPiezasAptas++;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            }
        }

        Console.WriteLine($"El número de piezas aptas para fabricar perfiles es: {contarPiezasAptas}");
    }
}
