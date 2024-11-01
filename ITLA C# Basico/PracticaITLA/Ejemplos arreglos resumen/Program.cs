using System;

namespace Ejemplos_arreglos_resumen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ememplos de cada ejercicios:

            //usodeArreglos();
            //IniciArreglos();
            //inicializadorArreglos();
            //SumaArreglo();
            //GraficoBarras();
            TirarDado();

        }
        static void usodeArreglos()
        {

            int[] arreglo; // declara un arreglo llamado arreglo

            // crea el espacio para el arreglo y lo inicializa con ceros predeterminados
            arreglo = new int[10]; // 10 elementos int

            Console.WriteLine("{0}{1,8}", "Índice", "Valor"); // encabezados

            // imprime en pantalla el valor de cada elemento del arreglo
            for (int contador = 0; contador < arreglo.Length; contador++)
                Console.WriteLine("{0,5}{1,8}", contador, arreglo[contador]);
        }

        static void IniciArreglos()
        {
            // la lista inicializadora especifica el valor para cada elemento
             int[] arreglo = { 32, 27, 64, 18, 95, 14, 90, 70, 60, 37 };
            
            Console.WriteLine("{0}{1,8}", "Índice", "Valor"); // encabezados
            
           // imprime en pantalla el valor de cada elemento del arreglo
            for (int contador = 0; contador < arreglo.Length; contador++)
            Console.WriteLine("{0,5}{1,8}", contador, arreglo[contador]);
        }

        static void inicializadorArreglos() 
        {
            const int LONGITUD_ARREGLO = 10; // crea una constante con nombre
            int[] arreglo = new int[LONGITUD_ARREGLO]; // crea el arreglo
            
            // calcula el valor para cada elemento del arreglo
            for (int contador = 0; contador < arreglo.Length; contador++)
                 arreglo[contador] = 2 + 2 * contador;
            
            Console.WriteLine("{0}{1,8}", "Índice", "Valor"); // encabezados
            
            // imprime en pantalla el valor de cada elemento del arreglo
            for (int contador = 0; contador < arreglo.Length; contador++)
            Console.WriteLine("{0,5}{1,8}", contador, arreglo[contador]);
        }

        static void SumaArreglo()
        {
            int[] arreglo = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };
            int total = 0;
            
            // sumar el valor de cada elemento al total
           for (int contador = 0; contador < arreglo.Length; contador++)
               total += arreglo[contador];
           
            Console.WriteLine("Total de los elementos del arreglo: {0}", total);
        }

        static void GraficoBarras()
        {
          int[] arreglo = { 0, 0, 0, 0, 0, 0, 1, 2, 4, 2, 1 };
            
          Console.WriteLine("Distribución de las calificaciones:");

            // para cada elemento del arreglo, mostrar en pantalla una barra del gráfico
            for (int contador = 0; contador < arreglo.Length; contador++)
                {
                // muestra etiquetas de las barras ( "00-09: ", ..., "90-99: ", "100: " )
             if (contador == 10)
                 Console.Write(" 100: ");
                else
                    Console.Write("{0:D2}-{1:D2}: ",
                    contador * 10, contador * 10 + 9);
                
                // imprime barra de asteriscos
               for (int estrellas = 0; estrellas < arreglo[contador]; estrellas++)
                    Console.Write("*");
                
                Console.WriteLine(); // inicia una nueva línea de salida
                 } // fin de for externo
        }
       static void TirarDado()
        {
            Random numerosAleatorios = new Random(); // generador de números aleatorios
             int[] frecuencia = new int[7]; // arreglo de contadores de frecuencia
            
           // tira el dado 6000 veces; usa el valor del dado como subíndice de frecuencia
         for (int tiro = 1; tiro <= 6000; tiro++)
             ++frecuencia[numerosAleatorios.Next(1, 7)];
            
        Console.WriteLine("{0}{1,10}", "Cara", "Frecuencia");
           
         // imprime en pantalla el valor de cada elemento del arreglo
        for (int cara = 1; cara < frecuencia.Length; cara++)
            Console.WriteLine("{0,4}{1,10}", cara, frecuencia[cara]);

        }
     } 

}
    

