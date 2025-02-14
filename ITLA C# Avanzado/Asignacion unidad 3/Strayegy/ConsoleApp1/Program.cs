namespace StrategyPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            EvaluacionContext evaluacionContext = new EvaluacionContext();
            evaluacionContext.evaluar(EvaluacionContext.Comportamiento.Aprobada);
            Console.WriteLine("");
            evaluacionContext.evaluar(EvaluacionContext.Comportamiento.Pendiente);
            Console.WriteLine("");
            evaluacionContext.evaluar(EvaluacionContext.Comportamiento.Reprobada);


        }
    }
}
