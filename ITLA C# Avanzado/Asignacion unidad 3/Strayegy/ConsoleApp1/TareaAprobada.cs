﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class TareaAprobada : IEstatus
    {
        public void notas()
        {
            Console.WriteLine("Cumpliste con la tarea requerida.");
        }
    }
}
