# ERRORES MÁS COMUNES EN C# - Guía Completa

## 1. ERRORES DE PUNTO DE ENTRADA (Main)

### Error: CS5001 - El programa no contiene un método Main

**Síntoma:**
```
CS5001: El programa no contiene ningún método 'Main' estático adecuado para un punto de entrada
```

**Causas:**
- El método se llama `main` en lugar de `Main` (C# es sensible a mayúsculas)
- El método no es `static`
- El método no devuelve `void` o `int`
- No hay argumentos `string[] args`

**Soluciones:**

❌ **Incorrecto:**
```csharp
public class Program
{
    static void main(string[] args)  // main en minúscula
    {
        Console.WriteLine("Hola");
    }
}
```

✅ **Correcto:**
```csharp
public class Program
{
    static void Main(string[] args)  // Main con mayúscula
    {
        Console.WriteLine("Hola");
    }
}
```

**Reparar con PowerShell:**
```powershell
(Get-Content Program.cs) -replace 'static void main', 'static void Main' | Set-Content Program.cs
dotnet build
```

---

## 2. ERRORES DE NAMESPACES

### Error: CS0246 - El nombre del tipo no se encontró

**Síntoma:**
```
CS0246: El nombre del tipo o del espacio de nombres 'Datos' no se encontró
```

**Causas más comunes:**

#### 2.1 Clase en namespace diferente
```csharp
// Program.cs
namespace MiApp
{
    // Intenta usar Datos, pero Datos está en namespace "datos"
    Datos obj = new Datos();
}

// Datos.cs
namespace datos  // ← Diferente namespace
{
    public class Datos { }
}
```

**Solución 1: Igualar namespaces**
```csharp
// Ambos en el mismo namespace
namespace MiApp
{
    public class Datos { }
}

namespace MiApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Datos obj = new Datos();
        }
    }
}
```

**Solución 2: Usar `using`**
```csharp
// Program.cs
using datos;  // Importar el namespace

namespace MiApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Datos obj = new Datos();  // Ahora encuentra la clase
        }
    }
}
```

#### 2.2 Conflicto: Nombre namespace = Nombre clase
```csharp
namespace Estudiante
{
    public class Estudiante  // ← Mismo nombre que el namespace
    {
        public int edad { get; set; }
    }
}

// En Program.cs
namespace Estudiante
{
    public class Program
    {
        static void Main()
        {
            Estudiante est = new Estudiante();  // Ambiguo
        }
    }
}
```

**Solución: Renombrar namespace o clase**
```csharp
// Opción A: Renombrar namespace
namespace MiApp
{
    public class Estudiante
    {
        public int edad { get; set; }
    }
}

// Opción B: Renombrar clase
namespace Estudiante
{
    public class Alumno  // Nombre diferente
    {
        public int edad { get; set; }
    }
}

namespace Estudiante
{
    public class Program
    {
        static void Main()
        {
            Alumno alumno = new Alumno();
        }
    }
}
```

---

## 3. ERRORES DE CONSTRUCTORES

### Error: CS1729 - El constructor no toma N argumentos

**Síntoma:**
```
CS1729: 'Datos' no contiene un constructor que tome 3 argumentos
```

**Causa:** Los tipos de parámetros no coinciden

**Ejemplo problemático:**
```csharp
// Datos.cs
public class Datos
{
    public Datos(string id, string nombre, string[] telefonos)
    {
        // Constructor espera: string, string, string[]
    }
}

// Program.cs
int[] telefonos = { 900471951, 0900934305 };  // int[], no string[]
Datos d = new Datos("123", "Carlos", telefonos);  // ❌ Tipos no coinciden
```

**Solución:**
```csharp
// Cambiar int[] por string[]
string[] telefonos = { "900471951", "0900934305" };  // ✅ string[]
Datos d = new Datos("123", "Carlos", telefonos);
```

**Otro caso: Falta el constructor**
```csharp
public class Persona
{
    public string nombre { get; set; }
    // NO hay constructor
}

// En Program.cs
Persona p = new Persona("Carlos", 25);  // ❌ Constructor no existe
```

**Solución: Crear el constructor**
```csharp
public class Persona
{
    public string nombre { get; set; }
    public int edad { get; set; }
    
    // Agregar constructor
    public Persona(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }
}
```

---

## 4. ERRORES DE TIPOS (TYPE MISMATCH)

### Error: CS0029 - No se puede asignar el tipo

**Síntoma:**
```
CS0029: No se puede asignar el tipo 'int' a 'string'
```

**Causa:** Intentar asignar un tipo a una variable de tipo diferente

❌ **Incorrecto:**
```csharp
string nombre = 123;  // int a string
int edad = "25";      // string a int
bool activo = "sí";   // string a bool
```

✅ **Correcto:**
```csharp
string nombre = "Juan";
int edad = 25;
bool activo = true;

// O convertir explícitamente:
string nombre = 123.ToString();        // int → string
int edad = int.Parse("25");            // string → int
bool activo = bool.Parse("true");      // string → bool
```

### Error: CS0030 - No se puede convertir el tipo

**Síntoma:**
```
CS0030: No se puede convertir el tipo 'int' a 'bool'
```

❌ **Incorrecto:**
```csharp
bool resultado = 1;  // int no se convierte automáticamente a bool
```

✅ **Correcto:**
```csharp
bool resultado = (1 == 1);  // Comparación devuelve bool
bool resultado = true;      // Asignación directa
```

---

## 5. ERRORES DE ARRAYS

### Error: CS1025 - Inicializador de array inválido

**Síntoma:**
```
CS1025: Inicializador de array inválido
```

❌ **Incorrecto:**
```csharp
int[] numeros = { 1, 2, "tres" };  // Mezclar tipos en array int[]
string[] nombres = { "Juan", 25, true };  // Mezclar tipos en array string[]
```

✅ **Correcto:**
```csharp
int[] numeros = { 1, 2, 3 };
string[] nombres = { "Juan", "María", "Pedro" };
object[] varios = { 1, "Juan", true, 3.14 };  // object[] permite tipos mixtos
```

### Error: System.IndexOutOfRangeException - Índice fuera de rango

**Síntoma (en tiempo de ejecución):**
```
System.IndexOutOfRangeException: El índice estaba fuera de los límites de la matriz
```

❌ **Incorrecto:**
```csharp
string[] nombres = { "Juan", "María", "Pedro" };  // 3 elementos (0, 1, 2)
Console.WriteLine(nombres[3]);  // ❌ No existe índice 3
Console.WriteLine(nombres[10]); // ❌ No existe índice 10
```

✅ **Correcto:**
```csharp
string[] nombres = { "Juan", "María", "Pedro" };
Console.WriteLine(nombres[0]);  // Juan
Console.WriteLine(nombres[1]);  // María
Console.WriteLine(nombres[2]);  // Pedro

// Usar un bucle para no exceder el límite
for (int i = 0; i < nombres.Length; i++)
{
    Console.WriteLine(nombres[i]);
}
```

---

## 6. ERRORES DE PROPIEDADES

### Error: CS0103 - El nombre no existe en el contexto actual

**Síntoma:**
```
CS0103: El nombre 'edad' no existe en el contexto actual
```

❌ **Incorrecto:**
```csharp
public class Persona
{
    // La propiedad no está declarada
}

// En Program.cs
Persona p = new Persona();
p.edad = 25;  // ❌ La propiedad no existe
```

✅ **Correcto:**
```csharp
public class Persona
{
    public int edad { get; set; }  // Declarar la propiedad
}

// En Program.cs
Persona p = new Persona();
p.edad = 25;  // ✅ Ahora existe
```

---

## 7. ERRORES DE SINTAXIS

### Error: CS1002 - Se esperaba ;

**Síntoma:**
```
CS1002: Se esperaba ;
```

❌ **Incorrecto:**
```csharp
int numero = 5  // Falta punto y coma
string nombre = "Juan"

Console.WriteLine(numero)
```

✅ **Correcto:**
```csharp
int numero = 5;      // Cada instrucción termina con ;
string nombre = "Juan";

Console.WriteLine(numero);
```

### Error: CS1513 - Se esperaba }

**Síntoma:**
```
CS1513: Se esperaba }
```

❌ **Incorrecto:**
```csharp
public class Persona
{
    public string nombre { get; set; }
    
    public void Saludar()
    {
        Console.WriteLine("Hola");
    }
    // Falta la llave de cierre de la clase
}
```

✅ **Correcto:**
```csharp
public class Persona
{
    public string nombre { get; set; }
    
    public void Saludar()
    {
        Console.WriteLine("Hola");
    }
}  // Llave de cierre
```

---

## 8. ERRORES DE MÉTODOS

### Error: CS0161 - No todas las rutas de código devuelven un valor

**Síntoma:**
```
CS0161: No todas las rutas de código devuelven un valor
```

❌ **Incorrecto:**
```csharp
public int ObtenerEdad(bool adulto)
{
    if (adulto)
    {
        return 18;
    }
    // Falta return para cuando adulto es false
}
```

✅ **Correcto:**
```csharp
public int ObtenerEdad(bool adulto)
{
    if (adulto)
    {
        return 18;
    }
    else
    {
        return 0;
    }
}

// O más simple:
public int ObtenerEdad(bool adulto)
{
    return adulto ? 18 : 0;
}
```

### Error: CS0115 - Método no puede implementar un método base

**Síntoma:**
```
CS0115: 'Clase.Metodo()' no contiene una definición para 'Metodo'
```

❌ **Incorrecto:**
```csharp
public class Persona
{
    public string nombre { get; set; }
}

// En Program.cs
Persona p = new Persona();
p.Saludar();  // ❌ El método no existe
```

✅ **Correcto:**
```csharp
public class Persona
{
    public string nombre { get; set; }
    
    public void Saludar()  // Declarar el método
    {
        Console.WriteLine($"Hola, soy {nombre}");
    }
}

// En Program.cs
Persona p = new Persona() { nombre = "Juan" };
p.Saludar();  // ✅ Ahora funciona
```

---

## 9. ERRORES CON VARIABLES

### Error: CS0165 - Variable local usada sin asignación

**Síntoma:**
```
CS0165: Uso de la variable local no asignada 'variable'
```

❌ **Incorrecto:**
```csharp
int edad;
Console.WriteLine(edad);  // ❌ edad no tiene valor
```

✅ **Correcto:**
```csharp
int edad = 25;  // Asignar valor
Console.WriteLine(edad);

// O inicializar después
int edad;
edad = 25;
Console.WriteLine(edad);
```

### Error: CS0128 - La variable local ya se ha declarado

**Síntoma:**
```
CS0128: Se ha declarado previamente una variable local denominada 'nombre'
```

❌ **Incorrecto:**
```csharp
string nombre = "Juan";
string nombre = "María";  // ❌ Ya existe una variable nombre
```

✅ **Correcto:**
```csharp
string nombre = "Juan";
nombre = "María";  // Reasignar valor, no redeclarar
```

---

## 10. ERRORES DE ACCESO

### Error: CS0122 - Miembro inaccesible

**Síntoma:**
```
CS0122: '...' es inaccesible debido a su nivel de protección
```

❌ **Incorrecto:**
```csharp
public class Persona
{
    private string nombre;  // private: solo accesible dentro de la clase
}

// En Program.cs
Persona p = new Persona();
p.nombre = "Juan";  // ❌ No se puede acceder a private
```

✅ **Correcto:**
```csharp
public class Persona
{
    public string nombre { get; set; }  // public: accesible desde cualquier lugar
}

// En Program.cs
Persona p = new Persona();
p.nombre = "Juan";  // ✅ Se puede acceder

// O usar métodos:
public class Persona
{
    private string nombre;
    
    public void SetNombre(string n)
    {
        nombre = n;
    }
    
    public string GetNombre()
    {
        return nombre;
    }
}

Persona p = new Persona();
p.SetNombre("Juan");
Console.WriteLine(p.GetNombre());
```

---

## 11. ERRORES DE CONVERSIÓN

### Error: CS0266 - No se puede convertir implícitamente

**Síntoma:**
```
CS0266: No se puede convertir implícitamente el tipo 'double' en 'int'
```

❌ **Incorrecto:**
```csharp
int numero = 3.14;  // ❌ double a int sin conversión
```

✅ **Correcto:**
```csharp
// Opción 1: Conversión explícita (cast)
int numero = (int)3.14;  // Resultado: 3 (se pierden decimales)

// Opción 2: Usar double
double numero = 3.14;

// Opción 3: Redondear
int numero = (int)Math.Round(3.14);  // Resultado: 3
```

---

## 12. ERRORES DE COMPARACIÓN

### Error: CS0019 - Operador no se puede aplicar

**Síntoma:**
```
CS0019: El operador '==' no se puede aplicar a los operandos de tipo 'int' e 'string'
```

❌ **Incorrecto:**
```csharp
int edad = 25;
if (edad == "25")  // ❌ Comparar int con string
{
    Console.WriteLine("Correcto");
}
```

✅ **Correcto:**
```csharp
int edad = 25;

// Opción 1: Comparar tipos iguales
if (edad == 25)
{
    Console.WriteLine("Correcto");
}

// Opción 2: Convertir string a int
if (edad == int.Parse("25"))
{
    Console.WriteLine("Correcto");
}

// Opción 3: Comparar como string
if (edad.ToString() == "25")
{
    Console.WriteLine("Correcto");
}
```

---

## 13. ERRORES DE BUCLES

### Error: Bucle infinito

**Síntoma:**
```
El programa se queda esperando (se cuelga)
```

❌ **Incorrecto:**
```csharp
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    // Falta i++, el bucle nunca termina
}
```

✅ **Correcto:**
```csharp
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++;  // Incrementar para que termine
}
```

### Error: Array index out of bounds en bucle

❌ **Incorrecto:**
```csharp
string[] nombres = { "Juan", "María" };  // 2 elementos
for (int i = 0; i <= nombres.Length; i++)  // ❌ <= debería ser <
{
    Console.WriteLine(nombres[i]);  // Cuando i=2, falla
}
```

✅ **Correcto:**
```csharp
string[] nombres = { "Juan", "María" };
for (int i = 0; i < nombres.Length; i++)  // ✅ <, no <=
{
    Console.WriteLine(nombres[i]);
}
```

---

## 14. ERRORES CON VALORES NULOS

### Error: CS0019 - Operación sobre referencia nula

**Síntoma (en tiempo de ejecución):**
```
System.NullReferenceException: La referencia del objeto no está establecida en una instancia de un objeto.
```

❌ **Incorrecto:**
```csharp
Persona p = null;
Console.WriteLine(p.nombre);  // ❌ p es null, no se puede acceder
```

✅ **Correcto:**
```csharp
// Opción 1: Inicializar el objeto
Persona p = new Persona() { nombre = "Juan" };
Console.WriteLine(p.nombre);

// Opción 2: Verificar si es null
Persona p = null;
if (p != null)
{
    Console.WriteLine(p.nombre);
}
else
{
    Console.WriteLine("Persona es nula");
}

// Opción 3: Usar operador de navegación segura (?.):
Persona p = null;
Console.WriteLine(p?.nombre ?? "Sin nombre");
```

---

## 15. ERRORES DE COMPILACIÓN COMUNES

### Error: CS8981 - Nombre solo en minúsculas

**Síntoma:**
```
CS8981: El nombre de tipo 'datos' solo contiene caracteres ASCII en minúsculas. 
Estos nombres pueden quedar reservados para el idioma.
```

❌ **Incorrecto:**
```csharp
public class datos  // Toda en minúsculas
{
    public string nombre { get; set; }
}
```

✅ **Correcto:**
```csharp
public class Datos  // PascalCase (primera letra mayúscula)
{
    public string nombre { get; set; }
}
```

---

## TABLA RÁPIDA DE REFERENCIA

| Error | Causa | Solución |
|-------|-------|----------|
| CS5001 | `main` en minúsculas | Cambiar a `Main` |
| CS0246 | Tipo no encontrado | Verificar namespace, usar `using` |
| CS1729 | Constructor no coincide | Verificar tipos de parámetros |
| CS0029 | Tipos incompatibles | Convertir o asignar tipo correcto |
| CS1025 | Array con tipos mixtos | Verificar que todos los elementos sean del mismo tipo |
| IndexOutOfRange | Índice fuera de rango | Usar `i < array.Length` en bucles |
| CS0103 | Propiedad no existe | Declarar la propiedad en la clase |
| CS1002 | Falta `;` | Agregar punto y coma al final |
| CS0165 | Variable no inicializada | Asignar un valor antes de usar |
| NullReferenceException | Objeto null | Inicializar antes de usar, verificar con `if` |

---

## CONSEJOS PARA EVITAR ERRORES

1. **Lee el número de error (CS####)**
   - Cada código de error tiene un significado específico

2. **Verifica línea y columna**
   - El error muestra exactamente dónde está el problema

3. **Usa IntelliSense de VS Code**
   - Presiona `Ctrl + Space` para ver sugerencias
   - Pasa el ratón sobre los errores rojos para ver detalles

4. **Compila frecuentemente**
   - No esperes a terminar todo el código
   - Compila después de cada cambio importante

5. **Sigue convenciones de nombres**
   - Clases: PascalCase (`Persona`, `Datos`)
   - Variables: camelCase (`nombre`, `edad`)
   - Constantes: UPPER_CASE (`PI`, `MAX_SIZE`)

6. **Inicializa siempre**
   - Variables deben tener valor antes de usarse
   - Objetos deben crearse con `new`

7. **Limpia caché después de cambios**
   - `rm -r bin, obj`
   - `dotnet build`

---

**Última actualización:** 11 de Diciembre de 2025  
**Propósito:** Referencia rápida para errores comunes en C#
