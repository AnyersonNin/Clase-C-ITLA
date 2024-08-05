//Ejercicio #1
int num1, num2, Resultado;
Console.WriteLine("Introdusca dos numeros");
Console.WriteLine("");
Console.Write("Introdusca el primer numero: ");
num1 = int.Parse(Console.ReadLine());
Console.Write("Introdusca el segundo numero: ");
num2 = int.Parse(Console.ReadLine());

if (num1 >= num2)
{
    Resultado = num1 + num2;
    Console.WriteLine($"El resultado de la suma es {Resultado}");
    Resultado = num1 - num2;
    Console.WriteLine($"La diferencia es {Resultado}");
}
else
{
    Resultado = num1 * num2;
    Console.WriteLine($"El producto es {Resultado}");
    Resultado = num1 / num2;
    Console.WriteLine($"La divicion es {Resultado}");
}

//Ejercicio #2 y #3

int nota1, nota2, nota3, promedio;

Console.WriteLine("introdusca 3 notas del 0 al 10 para ver el promedio de su alumno");


Console.Write("Nota numero 1: ");
nota1 = int.Parse(Console.ReadLine());

Console.Write("Nota numero 2: ");
nota2 = int.Parse(Console.ReadLine());

Console.Write("Nota numero 3: ");
nota3 = int.Parse(Console.ReadLine());

promedio = nota1 + nota2 + nota3 / 3;

if (promedio >= 7)
{
    Console.WriteLine($"Promocionado {promedio}");
}
else if (promedio >= 4 && promedio < 7)
{
    Console.WriteLine($"Regular {promedio}");
}
else
{
    Console.WriteLine($"Reprobado {promedio}");
}
