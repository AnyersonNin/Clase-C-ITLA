using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace punto_en_el_plano
{

    public class Ejercicio1
    {

        private int x; private int y;

        public void guardaValor(int x, int y)
        {
            this.x = x; this.y = y;

        }

        public void imprimeValores()
        {
            if (x > 0 && y > 0)
            {
                Console.WriteLine("El punto se encuentra en el primer cuadrante");
            }
            else if (x < 0 && y > 0)
            {
                Console.WriteLine("El punto se encuentra en el segundo cuadrante");
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine("El punto se encuentra en el tercer cuadrante");
            }
            else if (x > 0 && y < 0)
            {
                Console.WriteLine("El punto se encuentra en el cuarto cuadrante");
            }
            else if (x == 0 && y != 0)
            {
                Console.WriteLine("El punto se encuentra en el eje Y.");
            }
            else if (x != 0 && y == 0)
            {
                Console.WriteLine("El punto se encuentra en el eje X.");
            }
            else
            {
                Console.WriteLine("El punto se encuentra en el origen.");
            }
        }
    }
}
