using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionFuncionesExtensiones
{
    public static class Extensiones
    {

       public static void EjecutarExtensiones()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("    EXTENSIONES DE MÉTODOS   ");
            Console.WriteLine("=============================");

            Console.Write("Ingrese un texto para capitalizar: ");
            string texto = Console.ReadLine();
            Console.WriteLine($"Texto capitalizado: {texto.CapitalizeWords()}");

            Console.WriteLine();
            Console.Write("Ingrese números separados por comas para calcular la mediana: ");
            try
            {
                List<int> numeros = Console.ReadLine().Split(',').Select(int.Parse).ToList();
                Console.WriteLine($"Mediana de la lista: {numeros.Mediana()}");
            }
            catch
            {
                Console.WriteLine("Entrada inválida.");
            }

            Console.WriteLine();
            Console.Write("Ingrese una fecha en formato DD/MM/YYYY para verificar si es fin de semana: ");
            string entrada = Console.ReadLine();
            if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                Console.WriteLine($"¿Es fin de semana {fecha:dd/MM/yyyy}?: {fecha.EsFinDeSemana()}");
            }
            else
            {
                Console.WriteLine("Formato de fecha inválido.");
            }
        }

        public static string CapitalizeWords(this string texto)
        {
            return string.Join(" ", texto.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1)));
        }
        public static double Mediana(this List<int> numeros)
        {
            var sorted = numeros.OrderBy(n => n).ToList();
            int count = sorted.Count;
            return count % 2 == 1 ? sorted[count / 2] : (sorted[count / 2 - 1] + sorted[count / 2]) / 2.0;
        }
        public static bool EsFinDeSemana(this DateTime fecha)
        {
            return fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday;
        }
    }
 }

