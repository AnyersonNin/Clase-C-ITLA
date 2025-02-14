using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Registro
    {
     public const int MATEMATICA = 1;
     public const int HISTORIA = 2;
     public const int PROGRAMACION = 3;
    

    public static Tarea registroMateria(int materia)
    {
            switch (materia)
            {
                case MATEMATICA:
                    return new Matematica();
                case HISTORIA:
                    return new Matematica();
                case PROGRAMACION:
                    return new Matematica();
                default: return null;
            }
        }
    }
}
