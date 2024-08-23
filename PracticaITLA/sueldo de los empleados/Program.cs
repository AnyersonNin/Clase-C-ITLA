
int sueldoMini = 100;
int sueldoMax = 500;
int sueldo = 0;
int sueldoTotal = 0;
int cantidadEmpleado = 0;
string empleado;
int index = 1;
int cantidadMas = 0;
int cantidadMenos = 0;

try
{
    Console.WriteLine("          __Bienvenidos a la Empresa__");

    Console.WriteLine("Introduce la cantiadad de Empleados tiene la empresa");
    cantidadEmpleado = int.Parse(Console.ReadLine());

    while (index <= cantidadEmpleado)
    {
        Console.WriteLine("");
        while (true) 
        {
            Console.Write($"Introduce el Nombre del empleado #{index}: ");
            empleado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(empleado))
            {
                break;
            }
            else
            {
                Console.WriteLine("Error: El nombre del empleado no puede estar vacío. Por favor, ingrese un nombre válido.");
            }
        }
        while (true) 
        {
            try
            {
                Console.Write("Introduce el Sueldo del empleado: ");
                sueldo = int.Parse(Console.ReadLine());
                break; 
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingresó un valor no válido. Por favor, ingrese un número válido para el sueldo.");
            }
        }
        Console.WriteLine("");
        if (sueldo >= sueldoMini && sueldo <= sueldoMax)
        {
            Console.WriteLine($"Nombre del Empleado: {empleado}");
            Console.WriteLine($"Sueldo del Empleado: ${sueldo}");

            if (sueldo >= 300)
            {
                Console.WriteLine("Sueldo de $300 o mas");
                cantidadMas++;

            }
            else
            {
                Console.WriteLine("sueldo es menos de $300");
                cantidadMenos++;
            }
        }
        else
        {
            Console.WriteLine($"El sueldo de {empleado} esta fuera del rango");
            Console.WriteLine($"");

        }

        sueldoTotal += sueldo;
        index++;
    }
    Console.WriteLine($"");
    Console.WriteLine($"Importe que gasta la empresa en sueldos al personal: ");
    Console.WriteLine($"-----------------------------------------------------");
    Console.WriteLine($"Empleados con sueldos de $100 a $300 {cantidadMenos}");
    Console.WriteLine($"Empleados con sueldo de $300 o mas {cantidadMas}");
    Console.WriteLine($"Importe total ${sueldoTotal}");
}

catch (FormatException ex)
{
    Console.WriteLine("Error: Ingresó un formato no válido. Por favor, ingrese un número válido.");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
}