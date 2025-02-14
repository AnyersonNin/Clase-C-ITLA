using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class TareaHistoria : Tarea
    {
        public override int CuantasTareasExisten()
        {
            return 3;
        }
    }
}
