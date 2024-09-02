using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;

namespace programaArray
{
    
    internal class Program
    {
  
        static void Main(string[] args)
        {
            //Array1();
            //Array2();
            Array3();
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
         bool Matriz = false;
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
                  Matriz = true;
                
                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz1[i] != matriz2[i])
                        {
                            Matriz = false;
                            break;
                        }
                    }
                    if (Matriz)
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

        static void Array3()
        {
            try
            {
                Console.Write("Ponga la cantidad de numeros que deses Ingresar: ");
                int cantidad = int.Parse(Console.ReadLine());

                int[] numeros = new int[cantidad];

                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine($"Ingresa el numero #{i + 1}");
                    numeros[i] = int.Parse(Console.ReadLine());
                }

                int valorMin = numeros[0];
                for (int i = 1; i < numeros.Length; i++)
                {
                    if (numeros[i] < valorMin)
                    {
                        valorMin = numeros[i];
                    }
                }

                int conteo = 0;
            bool retidos = false;

             for (int i = 0; i < numeros.Length; i++)
             { 
               for (int j = i + 1; j < numeros.Length; j++) 
               { 
                 if(numeros[i] == numeros[j])
                  {
                  conteo = numeros[i];
                  retidos = true;
                    break;  
                  }                              
               } 
               
               if (retidos)
                 break;           
              }
                Console.WriteLine($"El Menor valor es: {valorMin}");
             
             if (retidos)
             {
               Console.WriteLine($"Este valor {conteo}, se repite al menos una vez");
             }
             else
             {
              Console.WriteLine("No hay valores repetidos.");
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
