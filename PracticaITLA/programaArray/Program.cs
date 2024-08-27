using System;
using System.Runtime.InteropServices;

namespace programaArray
{
    
    internal class Program
    {
  
        static void Main(string[] args)
        {
            Array1();
        }

        static void Array1()
        {
            try
            {
                int[] matriz = new int[20];

                for (int i = 0; i < matriz.Length; i++)
                {
                    matriz[i] = i * 5;

                }

                foreach (int item in matriz)
                {
                    Console.WriteLine(item);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }
        }
    }
}
