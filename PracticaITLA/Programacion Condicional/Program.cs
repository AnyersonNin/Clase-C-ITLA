
using System;

class Program
{
    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Seleccione una opción del menú:");
            Console.WriteLine("1. Calcular suma/resta o producto/cociente");
            Console.WriteLine("2. Calcular promedio de calificaciones");
            Console.WriteLine("3. Calcular nivel del postulante");
            Console.WriteLine("4. Salir");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        CalcularSumaORestaOProductoOCociente();
                        break;
                    case 2:
                        CalcularPromedio();
                        break;
                    case 3:
                        DeterminarNivel();
                        break;
                    case 4:
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

    static void CalcularSumaORestaOProductoOCociente()
    {
        int numero1, numero2;

        Console.WriteLine("Ingrese el primer número:");
        if (int.TryParse(Console.ReadLine(), out numero1))
        {
            Console.WriteLine("Ingrese el segundo número:");
            if (int.TryParse(Console.ReadLine(), out numero2))
            {
                if (numero1 > numero2)
                {
                    int suma = numero1 + numero2;
                    int resta = numero1 - numero2;
                    Console.WriteLine($"La suma es: {suma}");
                    Console.WriteLine($"La resta es: {resta}");
                }
                else
                {
                    int producto = numero1 * numero2;
                    double cociente = (double)numero1 / numero2;
                    Console.WriteLine($"El producto es: {producto}");
                    Console.WriteLine($"El cociente es: {cociente:F2}");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
        }
    }

    static void CalcularPromedio()
    {
        double calificacion1, calificacion2, calificacion3;

        Console.WriteLine("Ingrese la primera calificación:");
        if (double.TryParse(Console.ReadLine(), out calificacion1))
        {
            Console.WriteLine("Ingrese la segunda calificación:");
            if (double.TryParse(Console.ReadLine(), out calificacion2))
            {
                Console.WriteLine("Ingrese la tercera calificación:");
                if (double.TryParse(Console.ReadLine(), out calificacion3))
                {
                    double promedio = (calificacion1 + calificacion2 + calificacion3) / 3;
                    Console.WriteLine($"El promedio es: {promedio:F2}");

                    if (promedio >= 7)
                    {
                        Console.WriteLine("El alumno ha aprobado.");
                    }
                    else
                    {
                        Console.WriteLine("El alumno no ha aprobado.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese una calificación válida.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese una calificación válida.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese una calificación válida.");
        }
    }

    static void DeterminarNivel()
    {
        int totalPreguntas, respuestasCorrectas;

        Console.WriteLine("Ingrese el número total de preguntas:");
        if (int.TryParse(Console.ReadLine(), out totalPreguntas))
        {
            Console.WriteLine("Ingrese el número de respuestas correctas:");
            if (int.TryParse(Console.ReadLine(), out respuestasCorrectas))
            {
                double porcentaje = (double)respuestasCorrectas / totalPreguntas * 100;
                Console.WriteLine($"El porcentaje de aciertos es: {porcentaje:F2}%");

                if (porcentaje >= 90)
                {
                    Console.WriteLine("Nivel máximo.");
                }
                else if (porcentaje >= 75)
                {
                    Console.WriteLine("Nivel medio.");
                }
                else if (porcentaje >= 50)
                {
                    Console.WriteLine("Nivel regular.");
                }
                else
                {
                    Console.WriteLine("Fuera de nivel.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
        }
    }
}
