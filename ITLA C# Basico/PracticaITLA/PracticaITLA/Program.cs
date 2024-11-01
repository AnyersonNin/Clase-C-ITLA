
int num1, num2, Resultado;

Console.WriteLine("Para hacer la operacion agregue dos Numeros");
Console.WriteLine("-------------------------------------------");
Console.Write("Ingrese el primer numero: ");
 num1 = int.Parse(Console.ReadLine());

Console.Write("Ingrese el primer numero: ");
num2 = int.Parse(Console.ReadLine());

Console.WriteLine("");
Console.WriteLine("Resultados: ");

Resultado = num1 + num2; ;
Console.WriteLine($"El resultado de la suma es {Resultado}");

Resultado= num1 * num2;
Console.WriteLine($"El resultado de la multiplicacion es {Resultado}");
Console.WriteLine("Fin");

