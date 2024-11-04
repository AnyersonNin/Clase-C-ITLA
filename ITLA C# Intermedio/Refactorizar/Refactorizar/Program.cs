using System;
using System.Collections.Generic;
using System.Linq;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int CantidadStock { get; set; }
}

public class Inventario
{
    private List<Producto> productos = new List<Producto>();

    // Crear nuevo producto
    public void CrearProducto(int id,string nombre, decimal precio, int cantidadStock)
    {
        productos.Add(new Producto { ID = id, Nombre = nombre, Precio = precio, CantidadStock = cantidadStock });
        Console.WriteLine("Producto añadido exitosamente.");
    }

    // Mostrar lista de productos
    public void MostrarProductos()
    {
        Console.WriteLine("Lista de Productos:");
        foreach (var producto in productos)
        {
            Console.WriteLine($"ID: {producto.ID}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.CantidadStock}");
        }
    }

    // Buscar producto por nombre
    public Producto BuscarProductoPorNombre(string nombre)
    {
        return productos.FirstOrDefault(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
    }

    // Actualizar precio del producto
    public void ActualizarPrecioProducto(int id, decimal nuevoPrecio)
    {
        var producto = productos.FirstOrDefault(p => p.ID == id);
        if (producto != null)
        {
            producto.Precio = nuevoPrecio;
            Console.WriteLine($"El precio del producto con ID {producto.ID} ha sido actualizado a {nuevoPrecio:C}.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
    public void CrearActualizar(int id)
    {
            var productoExistente = productos.FirstOrDefault(p => p.ID == id);
            if (productoExistente != null)
            {
                Console.WriteLine("Ingrese el nuevo precio:");
                decimal nuevoPrecio = Convert.ToDecimal(Console.ReadLine());
                ActualizarPrecioProducto(id, nuevoPrecio);
            }
            else // Si no existe el ID, crea un nuevo producto
            {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Producto no encontrado. Se creará uno nuevo.");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Ingrese el nombre del producto: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese el precio: ");
                decimal precio = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Ingrese la cantidad en stock: ");
                int cantidadStock = Convert.ToInt32(Console.ReadLine());
                CrearProducto(id, nombre, precio, cantidadStock);
            Console.WriteLine("");
            }
        
     
    }
}

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();

        // Crear productos (simplificado)
        inventario.CrearProducto(1, "Laptop", 1500, 10);
        inventario.CrearProducto(2, "Mouse", 20, 100);

        // Mostrar productos
        inventario.MostrarProductos();

        Console.WriteLine("");
        // Buscar producto
        Console.WriteLine("Ingrese el nombre del producto a buscar:");
        string nombreProducto = Console.ReadLine();
        var producto = inventario.BuscarProductoPorNombre(nombreProducto);
        if (producto != null)
        {
            Console.WriteLine($"Producto encontrado: {producto.Nombre} - Precio: {producto.Precio:C}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
        Console.WriteLine("");
        // Actualizar precio
        Console.WriteLine("Ingrese el ID del producto para crear o actualizar:");
        int idProducto = Convert.ToInt32(Console.ReadLine());
        inventario.CrearActualizar(idProducto);

        Console.WriteLine("");
        // Mostrar productos actualizados
        inventario.MostrarProductos();
    }
}
