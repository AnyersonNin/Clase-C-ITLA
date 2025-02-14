namespace Factory
{
    public class Program
    {
        static void Main(string[] args)
        {
           Tarea tarea = Registro.registroMateria(Registro.MATEMATICA);
            Console.WriteLine(tarea.CuantasTareasExisten());
        }
    }
}
