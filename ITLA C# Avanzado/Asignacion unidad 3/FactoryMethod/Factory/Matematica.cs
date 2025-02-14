using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Matematica : Tarea
    {
        public override int CuantasTareasExisten()
        {
            return 10;
        }
    }
}
