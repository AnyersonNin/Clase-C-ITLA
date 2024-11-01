using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libro
{
    public class Ejercicio2
    {
        private string _Titulo;
        private string _Autor;
        private int _Pagina;

        public void guardaInfo(string titulo, string autor,int pagina)
        {
            this._Titulo = titulo;
            this._Autor = autor;
            this._Pagina = pagina;
        }
        
        public void MostrarInformacion()
        {
            Console.WriteLine("");
            Console.WriteLine("Informacion del Libro");
            Console.WriteLine("---------------------");
            Console.WriteLine($"El libro se titula: {_Titulo}");
            Console.WriteLine($"Su autor es: {_Autor} ");
            Console.WriteLine($"Cantidad de paginas: {_Pagina}");
        }


        public bool EsLargo()
        {
          return _Pagina > 500;
        }
    }
}
