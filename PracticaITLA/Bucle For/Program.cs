using System;

class Program
{
    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Seleccione una opción del menú:");
            Console.WriteLine("1. Contar triángulos cuya área excede un valor límite");
            Console.WriteLine("2. Contar números divisibles por 3 o por 5");
            Console.WriteLine("3. Sumar los últimos 5 números de un conjunto de 10");
            Console.WriteLine("4. Salir");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        ContarTriangulosExcedenLimite();
                        break;
                    case 2:
                        ContarNumerosDivisibles();
                        break;
                    case 3:
                        SumarUltimosCincoNumeros();
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

    static void ContarTriangulosExcedenLimite()
    {
        Console.WriteLine("Ingrese el número de triángulos:");
        int numeroTriangulos;
        if (int.TryParse(Console.ReadLine(), out numeroTriangulos))
        {
            Console.WriteLine("Ingrese el valor límite del área:");
            double limiteArea;
            if (double.TryParse(Console.ReadLine(), out limiteArea))
            {
                int contadorExcedenLimite = 0;

                for (int i = 0; i < numeroTriangulos; i++)
                {
                    Console.WriteLine($"Ingrese la base del triángulo {i + 1}:");
                    double baseTriangulo;
                    if (double.TryParse(Console.ReadLine(), out baseTriangulo))
                    {
                        Console.WriteLine($"Ingrese la altura del triángulo {i + 1}:");
                        double alturaTriangulo;
                        if (double.TryParse(Console.ReadLine(), out alturaTriangulo))
                        {
                            double area = (baseTriangulo * alturaTriangulo) / 2;

                            if (area > limiteArea)
                            {
                                contadorExcedenLimite++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Por favor, ingrese una altura válida.");
                            i--; // Reintentar la entrada actual
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Por favor, ingrese una base válida.");
                        i--; // Reintentar la entrada actual
                    }
                }

                Console.WriteLine($"El número de triángulos cuya área excede {limiteArea} es: {contadorExcedenLimite}");
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un valor límite válido.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido de triángulos.");
        }
    }

    static void ContarNumerosDivisibles()
    {
        int contadorDivisibles = 0;

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Ingrese el número {i}:");
            int numero;
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                if (numero % 3 == 0 || numero % 5 == 0)
                {
                    contadorDivisibles++;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
                i--; // Reintentar la entrada actual
            }
        }

        Console.WriteLine($"La cantidad de números divisibles por 3 o por 5 es: {contadorDivisibles}");
    }

    static void SumarUltimosCincoNumeros()
    {
        int[] numeros = new int[10];
        int sumaUltimosCinco = 0;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Ingrese el número {i + 1}:");
            if (int.TryParse(Console.ReadLine(), out numeros[i]))
            {
                if (i >= 5)
                {
                    sumaUltimosCinco += numeros[i];
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
                i--; // Reintentar la entrada actual
            }
        }

        Console.WriteLine($"La suma de los últimos 5 números ingresados es: {sumaUltimosCinco}");
    }
}

