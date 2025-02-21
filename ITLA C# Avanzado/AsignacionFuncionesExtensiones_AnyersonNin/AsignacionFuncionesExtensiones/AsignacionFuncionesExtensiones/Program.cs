using System.Globalization;
using System.Security.Cryptography;

namespace AsignacionFuncionesExtensiones
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opcionPrincipal;
            do
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("        MENÚ PRINCIPAL       ");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Funciones Puras");
                Console.WriteLine("2. Extensiones de Métodos");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción (1-3): ");

                if (!int.TryParse(Console.ReadLine(), out opcionPrincipal))
                {
                    Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcionPrincipal)
                {
                    case 1:
                        FuncionesPuras.EjecutarFuncionesPuras();
                        break;
                    case 2:
                        Extensiones.EjecutarExtensiones();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (opcionPrincipal != 3);
        }
    }
}
