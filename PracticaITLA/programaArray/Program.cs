using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace programaArray
{
    
    internal class Program
    {
  
        static void Main(string[] args)
        {
            //Array1();
            Array2();
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

        static void Array2()
        {
         bool bobo = false;
            try
          {

                Console.WriteLine("Ingresa los elementos de la primera matriz separados por comas:");
                string linea1 = Console.ReadLine();
                int[] matriz1 = Array.ConvertAll(linea1.Split(','), int.Parse);

               
                Console.WriteLine("Ingresa los elementos de la segunda matriz separados por comas:");
                string linea2 = Console.ReadLine();
                int[] matriz2 = Array.ConvertAll(linea2.Split(','), int.Parse);


                if (matriz1.Length == matriz2.Length)
                {
                  bobo = true;
                
                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz1[i] != matriz2[i])
                        {
                            bobo = false;
                            break;
                        }
                    }
                    if (bobo)
                    {
                        Console.WriteLine("Las matrices son iguales.");
                    }
                    else
                    {
                        Console.WriteLine("Las matrices no son iguales.");
                    }
                }
                else
                {
                    Console.WriteLine("Las matrices tienen longitudes diferentes, por lo tanto, son diferentes.");
                }

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
    }
}
