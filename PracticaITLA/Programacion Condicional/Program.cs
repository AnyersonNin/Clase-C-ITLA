//Ejercicio #1
try
{
    Console.Write("Ingrese el primer número: ");
    int num1 = int.Parse(Console.ReadLine());

    Console.Write("Ingrese el segundo número: ");
    int num2 = int.Parse(Console.ReadLine());

    int resultado;

    if (num1 > num2)
    {
        resultado = num1 + num2;
        Console.WriteLine($"El resultado de la suma es {resultado}");

        resultado = num1 - num2;
        Console.WriteLine($"La diferencia es {resultado}");
    }
    else
    {
        resultado = num1 * num2;
        Console.WriteLine($"El producto es {resultado}");

        if (num2 != 0)
        {
            resultado = num1 / num2;
            Console.WriteLine($"La división es {resultado}");
        }
        else
        {
            Console.WriteLine("Error: División por cero.");
        }
    }
}
catch (FormatException)
{
    Console.WriteLine("Error: Entrada no válida. Ingrese números enteros.");
}

// Ejercicio #2
try
{
    Console.WriteLine("Introduzca 3 notas del 0 al 10 para ver el promedio de su alumno:");

    Console.Write("Nota número 1: ");
    int nota1 = int.Parse(Console.ReadLine());

    Console.Write("Nota número 2: ");
    int nota2 = int.Parse(Console.ReadLine());

    Console.Write("Nota número 3: ");
    int nota3 = int.Parse(Console.ReadLine());

    // Calcular promedio
    double promedio = (nota1 + nota2 + nota3) / 3.0; // Asegurarse de que el promedio sea un double

    Console.WriteLine($"Promedio: {promedio:F2}");

    if (promedio >= 7)
    {
        Console.WriteLine("¡Promocionado!");
    }
    else if (promedio >= 4)
    {
        Console.WriteLine("Regular");
    }
    else
    {
        Console.WriteLine("Reprobado");
    }
}
catch (FormatException)
{
    Console.WriteLine("Error: Entrada no válida. Ingrese notas numéricas.");
}

// Ejercicio #3
try
{
    Console.Write("Ingrese el número total de preguntas: ");
    int totalPreguntas = int.Parse(Console.ReadLine());

    Console.Write("Ingrese el número de respuestas correctas: ");
    int respuestasCorrectas = int.Parse(Console.ReadLine());

    if (totalPreguntas <= 0)
    {
        Console.WriteLine("Error: El número total de preguntas debe ser mayor a cero.");
        return;
    }

    double porcentaje = (respuestasCorrectas / (double)totalPreguntas) * 100;
    Console.WriteLine($"Porcentaje de aciertos: {porcentaje:F2}%");

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
catch (FormatException)
{
    Console.WriteLine("Error: Entrada no válida. Ingrese números enteros.");
}