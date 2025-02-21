
namespace AsignacionFuncionesExtensiones
{
    public static class FuncionesPuras
    {
        public static void EjecutarFuncionesPuras()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("      FUNCIONES PURAS        ");
            Console.WriteLine("=============================");

            Console.Write("Ingrese un número para sumar sus dígitos: ");
            if (int.TryParse(Console.ReadLine(), out int num1))
            {
                Console.WriteLine($"Suma de los dígitos de {num1}: {FuncionesPuras.SumaDigitos(num1)}");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }

            Console.WriteLine();
            Console.Write("Ingrese un número para verificar si es palíndromo: ");
            if (int.TryParse(Console.ReadLine(), out int num2))
            {
                Console.WriteLine($"¿{num2} es un palíndromo?: {FuncionesPuras.EsPalindromo(num2)}");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }

            Console.WriteLine();
            Console.Write("Ingrese números separados por comas para calcular el promedio: ");
            try
            {
                List<int> numeros = Console.ReadLine().Split(',').Select(int.Parse).ToList();
                Console.WriteLine($"Promedio de la lista: {FuncionesPuras.Promedio(numeros)}");
            }
            catch
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        public static int SumaDigitos(int num1)
        {
            int suma = 0;
            while (num1 > 0)
            {
                suma += num1 % 10;
                num1 /= 10;
            }
            return suma;
        }
        public static string EsPalindromo(int num2)
        {
            
            int original = num2, reverso = 0;

            while (num2 > 0)
            {
                reverso = reverso * 10 + num2 % 10;
                num2 /= 10;
            }

            if (original == reverso)
            {
               return ("es un palindromo ");
            }

            return ("No es un palindromo");
        }
        public static double Promedio(List<int> num3)
        {
            int suma = 0, cantidad = num3.Count;
            foreach (int nummero in num3)
            {
                suma += nummero;
            }
            return cantidad > 0 ? (double)suma / cantidad : 0;
        }
    }
}
