using System;
using System.ComponentModel.Design;



char opcion; bool salir = false;
while(!salir)
    {
    Console.WriteLine("              .....:!!Bienvenidos!!:.....                    ");
    Console.WriteLine("calcula la base, altura y área de un triangulo");
    Console.WriteLine("para empezar presione (y) para continuar o (n) para salir");

 

    if (char.TryParse(Console.ReadLine(), out opcion)){
        switch (opcion)
        {
            case 'y':
                triangulos();
                break;
            case 'n':
                salir = true;
                Console.WriteLine("Saliendo del programa...");
                break;

            default:
                Console.WriteLine("Entrada no válida. Por favor, ingrese una letra (y o n).");
                break;
        }
    }
    else
    {
        Console.WriteLine("Opción no válida. Intente de nuevo.");
    }

    Console.WriteLine();
}
    static void triangulos()
{
    int cantidadTriangulo = 0;
    int index = 1;
    int Base, altura, area, cantidad = 0;

    try
    {
        Console.WriteLine("Ingrese la cantidad de triangulos que deseas calcular");
        cantidadTriangulo = int.Parse(Console.ReadLine());

        while (index <= cantidadTriangulo)
        {
            Console.WriteLine($"");

            Console.WriteLine($"..:Triangulo numero #{index}:..");

            Console.Write("Ingrese la Base del triangulo: ");
            Base = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la Altura del triangulo: ");
            altura = int.Parse(Console.ReadLine());

            area = (Base * altura) / 2;

            Console.WriteLine($"La base del triangulos es {Base} su altura es {altura} y su area es {area}");
            if (area > 12)
            {
                Console.WriteLine("Es superior a 12 unidades cuadradas");
                cantidad++;
            }
            index++;
        }

        Console.WriteLine($"");
        Console.WriteLine($"La cantidad en total {cantidad}");

    }

    catch (FormatException ex)
    {
        Console.WriteLine("Error: Ingresó un formato no válido. Por favor, ingrese un número válido.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
    }
}