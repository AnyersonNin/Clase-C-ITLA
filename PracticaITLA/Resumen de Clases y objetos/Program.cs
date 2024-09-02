/*// Fig. 4.1: LibroCalificaciones.cs
// Declaración de una clase con un método.

using static System.Runtime.InteropServices.JavaScript.JSType;

public class LibroCalificaciones
 {
    // muestra un mensaje de bienvenida para el usuario de LibroCalificaciones
 public void MostrarMensaje()
{
 Console.WriteLine("¡Bienvenido al Libro de calificaciones!");
 } // fin del método MostrarMensaje
} // fin de la clase LibroCalificaciones www.FreeLibros


// Fig. 4.2: PruebaLibroCalificaciones.cs
public class PruebaLibroCalificaciones
 {
     // El método Main comienza la ejecución del programa
public static void Main(string[] args)
{
         // crea un objeto LibroCalificaciones y lo asigna a miLibroCalificaciones
 LibroCalificaciones miLibroCalificaciones = new LibroCalificaciones();
        
 // llama al método MostrarMensaje de miLibroCalificaciones
 miLibroCalificaciones.MostrarMensaje();
       } // fin de Main
     } // fin de la clase PruebaLibroCalificaciones



// Fig. 4.4: LibroCalificaciones.cs
// Declaración de la clase con un método que tiene un parámetro.


public class LibroCalificaciones
 {
     // muestra un mensaje de bienvenida para el usuario del LibroCalificaciones
 public void MostrarMensaje(string nombreCurso)
 {
         Console.WriteLine("¡Bienvenido al libro de calificaciones para\n{0}!",
        nombreCurso);
        } // fin del método MostrarMensaje
    } // fin de la clase LibroCalificaciones

// Fig. 4.5: LibroPruebaCalificaciones.cs
// Crea objeto LibroCalificaciones y pasa una cadena a

public class LibroPruebaCalificaciones
{
    // El método Main comienza la ejecución del programa
public static void Main(string[] args)
{
        // crea un objeto LibroCalificaciones y lo asigna a miLibroCalificaciones
LibroCalificaciones miLibroCalificaciones = new LibroCalificaciones();
        
 // pide el nombre del curso y lo recibe como entrada
Console.WriteLine("Por favor escriba el nombre del curso:");
        string nombreDelCurso = Console.ReadLine(); // lee una línea de texto
        Console.WriteLine(); // imprime en pantalla una línea en blanco
        
// llama al método MostrarMensaje de miLibroCalificaciones
// y pasa nombreDelCurso como argumento
miLibroCalificaciones.MostrarMensaje(nombreDelCurso);
        } // fin de Main
    } // fin de la clase LibroPruebaCalificaciones

// Fig. 4.7: LibroCalificaciones.cs
// Clase LibroCalificaciones que contiene una variable de instancia cursoNombre
// y una propiedad para obtener (get) y establecer (set) su valor.


public class LibroCalificaciones
{
    private string nombreCurso; // nombre del curso para este LibroCalificaciones

 // propiedad para obtener (get) y establecer (set) el nombre del curso
 public string NombreCurso
{
    get
 {
        return nombreCurso;
        } // fin de get
    set
 {
        nombreCurso = value;
        } // fin de set
     } // fin de la propiedad NombreCurso

// muestra un mensaje de bienvenida para el usuario de LibroCalificaciones
public void MostrarMensaje()
 {
    // usa la propiedad NombreCurso para obtener el
 // nombre del curso que representa este LibroCalificaciones
 Console.WriteLine("¡Bienvenido al libro de calificaciones para\n{0}!",
 NombreCurso); // muestra la propiedad NombreCurso
     } // fin del método MostrarMensaje
} // fin de la clase LibroCalificaciones

// Fig. 4.8: PruebaLibroCalificaciones.cs
// Creación y manipulación de un objeto LibroCalificaciones.

public class PruebaLibroCalificaciones
 {
   // El método Main comienza la ejecución del programa
public static void Main(string[] args)
 {
         // crea un objeto LibroCalificaciones y lo asigna a miLibroCalificaciones
 LibroCalificaciones miLibroCalificaciones = new LibroCalificaciones();
        
 // muestra el valor inicial de NombreCurso
Console.WriteLine("El nombre inicial del curso es: '{0}'\n",
miLibroCalificaciones.NombreCurso);
        
// pide y lee el nombre del curso
Console.WriteLine("Por favor escriba el nombre del curso:");
        string elNombre = Console.ReadLine(); // lee una línea de texto
         miLibroCalificaciones.NombreCurso = elNombre; // establece el nombre usando una propiedad
 Console.WriteLine(); // imprime en pantalla una línea en blanco
        
 // muestra el mensaje de bienvenida después de especificar el nombre del curso
 miLibroCalificaciones.MostrarMensaje();
         } // fin de Main
     } // fin de la clase PruebaLibroCalificaciones


// Fig. 4.12: LibroCalificaciones.cs
// La clase LibroCalificaciones con un constructor para inicializar el nombre del curso.


public class LibroCalificaciones
{
    private string nombreCurso; // nombre del curso para este LibroCalificaciones

// el constructor inicializa nombreCurso con el objeto string suministrado como argumento
public LibroCalificaciones(string nombre)
 {
     NombreCurso = nombre; // inicializa nombreCurso usando la propiedad
     } // fin del constructor

// propiedad para obtener (get) y establecer (set) el nombre del curso
 public string NombreCurso
 {
     get
 {
         return nombreCurso;
         } // fin de get
     set
 {
         nombreCurso = value;
         } // fin de set
     } // fin de la propiedad NombreCurso

// muestra un mensaje de bienvenida para el usuario del LibroCalificaciones
 public void MostrarMensaje()
 {
    // usa la propiedad NombreCurso para obtener el
// nombre del curso que representa este LibroCalificaciones
 Console.WriteLine("Bienvenido al libro de calificaciones para\n{0}!",
NombreCurso);
    } // fin del método MostrarMensaje
} // fin de la clase LibroCalificaciones

// Fig. 4.13: PruebaLibroCalificaciones.cs
// El constructor LibroCalificaciones se utiliza para especificar el nombre del
// curso cada vez que se crea un objeto LibroCalificaciones.

public class PruebaLibroCalificaciones
{
    // El método Main comienza la ejecución del programa
 public static void Main(string[] args)
{
         // crea el objeto LibroCalificaciones
LibroCalificaciones libroCalificaciones1 = new LibroCalificaciones( // invoca al constructor
 "CS101 Introducción a la programación en C#");
        LibroCalificaciones libroCalificaciones2 = new LibroCalificaciones( // invoca al  constructor
        "CS102 Estructuras de datos en C#");
        
 // muestra el valor inicial de nombreCurso para cada LibroCalificaciones
Console.WriteLine("El nombre del curso de libroCalificaciones1 es: {0}",
 libroCalificaciones1.NombreCurso);
         Console.WriteLine("El nombre del curso de libroCalificaciones2 es: {0}",
         libroCalificaciones2.NombreCurso);
        } // fin de Main
     } // fin de la clase PruebaLibroCalificaciones
*/
// Fig. 4.15: Cuenta.cs
// La clase Cuenta con un constructor para
// inicializar la variable de instancia saldo.

public class Cuenta
 {
     private decimal saldo; // variable de instancia que almacena el saldo

// constructor
public Cuenta(decimal saldoInicial)
 {
     Saldo = saldoInicial; // establece el saldo usando la propiedad
     } // fin del constructor de Cuenta

// acredita (suma) un monto a la cuenta
 public void Acredita(decimal monto)
 {
     Saldo = Saldo + monto; // suma monto al saldo
    } // fin del método Acredita

// una propiedad para obtener (get) y establecer (set) el saldo de una cuenta
 public decimal Saldo
{
     get
 {
         return saldo;
         } // end get
     set
{
         // valida que el valor sea mayor o igual a 0;
 // si no lo es, el saldo permanece sin cambios
   if (value >= 0)
             saldo = value;
         } // fin de set
     } // fin de la propiedad Saldo
} // fin de la clase Cuenta

// Fig. 4.16: PruebaCuenta.cs
 // Creación y manipulación de un objeto Cuenta.

public class PruebaCuenta
{
     // El método Main comienza la ejecución de la aplicación de C#
 public static void Main(string[] args)
{
         Cuenta cuenta1 = new Cuenta(50.00M); // crea el objeto Cuenta
         Cuenta cuenta2 = new Cuenta(-7.53M); // crea el objeto Cuenta
        
// muestra el saldo inicial de cada objeto usando una propiedad
Console.WriteLine("Saldo de cuenta1: {0:C}",
 cuenta1.Saldo); // muestra la propiedad Saldo
         Console.WriteLine("Saldo de cuenta2: {0:C}\n",
        cuenta2.Saldo); // muestra la propiedad Saldo
        
 decimal montoDeposito; // deposita la cantidad que se leyó del usuario
        
// pide y obtiene la entrada del usuario
 Console.Write("Escriba el monto a depositar para la cuenta1: ");
         montoDeposito = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("se sumó {0:C} al saldo de cuenta1\n",
         montoDeposito);
         cuenta1.Acredita(montoDeposito); // se suma al saldo de cuenta1
        
// muestra los saldos
 Console.WriteLine("Saldo de cuenta1: {0:C}",
 cuenta1.Saldo);
        Console.WriteLine("Saldo de cuenta2: {0:C}\n",
        cuenta2.Saldo);
        
// pide y obtiene la entrada del usuario
 Console.Write("Escriba la cantidad a depositar para la cuenta2: ");
        montoDeposito = Convert.ToDecimal(Console.ReadLine());
         Console.WriteLine("se sumó {0:C} al saldo de cuenta2\n",
        montoDeposito);
         cuenta2.Acredita(montoDeposito); // se suma al saldo de cuenta2
        
 // muestra los saldos
 Console.WriteLine("Saldo de cuenta1: {0:C}", cuenta1.Saldo);
         Console.WriteLine("Saldo de cuenta2: {0:C}", cuenta2.Saldo);
         } // fin de Main
     } // fin de la clase PruebaCuenta
