using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class TareaPendiente : IEstatus
    {
        public void notas()
        {
            Console.WriteLine("No has enviado la tarea pendiente.");
        }
    }
}
