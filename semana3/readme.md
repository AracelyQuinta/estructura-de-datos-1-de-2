### Autor:
ARACELY QUINTANILLA del 3er semestre en la asignatura de estructura de datos paralelo "A" 
# Registro de Estudiante en C#
Este proyecto es un ejemplo sencillo en C# que muestra cómo crear una clase para almacenar datos de un estudiante y cómo imprimirlos en consola.
El programa utiliza conceptos básicos de Programación Orientada a Objetos (POO) como propiedades, constructores y objetos.

##  Objetivo
El objetivo del programa es:
- Definir una clase Datos que almacene información de un estudiante.
- Crear un objeto con esa información.
- Mostrar los datos en consola de forma organizada.

##  Estructura del Código
1. Clase Datos
La clase contiene las propiedades del estudiante:
- id: Identificador único.
- nombres: Nombres del estudiante.
- apellidos: Apellidos del estudiante.
- direccion: Dirección del estudiante.
- telefono: Arreglo de números de teléfono.
Además, incluye un constructor que inicializa estas propiedades al crear un objeto.
  
public class Datos
{
    public string id { get; set; }
    public string nombres { get; set; }
    public string apellidos { get; set; }
    public string direccion { get; set; }
    public string[] telefono { get; set; }

    public Datos(string _id, string _nombres, string _apellidos, string _direccion, string[] _telefono)
    {
        id = _id;
        nombres = _nombres;
        apellidos = _apellidos;
        direccion = _direccion;
        telefono = _telefono;
    }
}


2. Clase Program
En el método Main:
- Se define un arreglo con tres números de teléfono.
- Se crea un objeto Datos con la información del estudiante.
- Se imprime un encabezado y los datos en consola.
- Se recorre el arreglo de teléfonos con un bucle for para mostrarlos.
  
static void Main(string[] args)
{
    string[] telefono = { "900471951", "0900934305", "0998765432" };

    Datos datos = new Datos("1723456789", "Carlos", "Perez",
        "Av. Siempre Viva 123", telefono);

    Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");
    Console.WriteLine($"ID: {datos.id}");
    Console.WriteLine($"Nombre: {datos.nombres} {datos.apellidos}");
    Console.WriteLine($"Direccion: {datos.direccion}");

    Console.WriteLine("Telefonos:");
    for (int i = 0; i < datos.telefono.Length; i++)
    {
        Console.WriteLine($"  Telefono {i + 1}: {datos.telefono[i]}");
    }
}



### Ejemplo de Salida en Consola
Al ejecutar el programa, se obtiene:

=== REGISTRO DE ESTUDIANTE ===
ID: 1723456789
Nombre: Carlos Perez
Direccion: Av. Siempre Viva 123
Telefonos:
  Telefono 1: 900471951
  Telefono 2: 0900934305
  Telefono 3: 0998765432

<img width="540" height="278" alt="image" src="https://github.com/user-attachments/assets/d3d761c0-a5a7-45bb-9d37-b08b6491d79d" />


## Conceptos Aprendidos
- Clases y objetos en C#.
- Propiedades automáticas (get; set;).
- Constructores para inicializar datos.
- Uso de arreglos (string[]).
- Recorrido de arreglos con un bucle for.
- Impresión en consola con Console.WriteLine.

### Conclusión
Este programa es un ejemplo introductorio de cómo manejar datos en C# usando POO. Puede servir como base para proyectos más grandes, como sistemas de registro de estudiantes o aplicaciones de gestión académica.
