using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class TareaReprobada : IEstatus
    {
        public void notas()
        {
            Console.WriteLine("No completaste a tiempo la tarea pendiente.");
        }
    }
}
