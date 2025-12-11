# CREAR PROYECTOS C# DESDE CMD/POWERSHELL A VISUAL STUDIO CODE

## PARTE 1: PREPARACIÓN INICIAL

### Paso 1.1: Verificar que tienes .NET instalado

Abre PowerShell y verifica que .NET está instalado:

```powershell
dotnet --version
```

**Resultado esperado:**
```
8.0.0  (o la versión que tengas)
```

Si no está instalado, descárgalo desde: https://dotnet.microsoft.com/download

---

## PARTE 2: CREAR PROYECTO DESDE PowerShell

### Paso 2.1: Crear carpeta del proyecto

```powershell
# Navega a donde quieres crear el proyecto
cd "C:\Users\quiar\Downloads"

# Crea una carpeta nueva
mkdir MiProyecto

# Entra a la carpeta
cd MiProyecto
```

### Paso 2.2: Crear estructura del proyecto

**Opción A: Crear un proyecto console (RECOMENDADO)**

```powershell
# Crea un proyecto console automáticamente
dotnet new console -f net10.0 --name MiProyecto

# Resultado: Se crean archivos automáticamente
# - MiProyecto.csproj    (archivo de configuración)
# - Program.cs           (punto de entrada)
# - obj/                 (carpeta de compilación)
```

**Opción B: Crear estructura manual (si quieres aprender)**

```powershell
# Solo crea la carpeta raíz
cd "C:\Users\quiar\Downloads\MiProyecto"

# Crea manualmente los archivos necesarios (veremos después)
```

### Paso 2.3: Ver qué se creó

```powershell
# Ver contenido del proyecto
Get-ChildItem

# Resultado esperado:
# Mode                 LastWriteTime         Length Name
# ----                 -------------         ------ ----
# -a---          Program.cs
# -a---          MiProyecto.csproj
# d----          obj
```

---

## PARTE 3: ARCHIVOS NECESARIOS

### Paso 3.1: Archivo `.csproj` (Configuración del proyecto)

**Ubicación:** `MiProyecto.csproj`

**Contenido recomendado:**
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

**Explicación:**
- `OutputType>Exe</OutputType>` → Ejecutable (programa)
- `TargetFramework>net10.0</TargetFramework>` → Versión de .NET
- `ImplicitUsings>enable</ImplicitUsings>` → Importa automáticamente namespaces comunes
- `Nullable>enable</Nullable>` → Controla valores null estrictamente

### Paso 3.2: Archivo `Program.cs` (Punto de entrada)

**Ubicación:** `Program.cs` en la raíz del proyecto

**Contenido básico:**
```csharp
namespace MiProyecto
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Hola desde C#!");
        }
    }
}
```

**Estructura de carpetas recomendada:**
```
MiProyecto/
├── MiProyecto.csproj      (configuración)
├── Program.cs              (punto de entrada)
├── Models/                 (carpeta para clases)
│   ├── Estudiante.cs
│   └── Datos.cs
├── Services/               (servicios)
│   └── CalculadoraService.cs
└── obj/                    (generado automáticamente)
```

---

## PARTE 4: CREAR PROYECTO COMPLETO (PASO A PASO)

### Paso 4.1: Crear proyecto desde PowerShell

```powershell
# 1. Crear carpeta
mkdir "C:\Users\quiar\Downloads\MiApp"
cd "C:\Users\quiar\Downloads\MiApp"

# 2. Crear proyecto
dotnet new console -f net10.0 --name MiApp
```

### Paso 4.2: Compilar desde PowerShell (opcional)

```powershell
# Compilar para verificar que no hay errores
dotnet build

# Resultado esperado:
# MiApp net10.0 correcto (0,5s) → bin\Debug\net10.0\MiApp.dll
```

### Paso 4.3: Ejecutar desde PowerShell (opcional)

```powershell
# Ejecutar el programa
dotnet run

# Resultado esperado:
# ¡Hola desde C#!
```

---

## PARTE 5: ABRIR EN VISUAL STUDIO CODE

### Paso 5.1: Abrir el proyecto en VS Code

**Opción A: Desde PowerShell**
```powershell
# Estando en la carpeta del proyecto
code .
```

**Opción B: Desde VS Code**
- Click en `File` → `Open Folder`
- Selecciona la carpeta del proyecto

**Opción C: Desde Windows**
- Click derecho en la carpeta
- `Abrir con Code` (si tienes la opción)

### Paso 5.2: Verificar estructura en VS Code

En el panel izquierdo (Explorer) deberías ver:
```
MiApp
 ├── Program.cs
 ├── MiApp.csproj
 └── obj/
```

---

## PARTE 6: CREAR TUS ARCHIVOS EN VS CODE

### Paso 6.1: Crear una clase (Archivo .cs nuevo)

**Dentro de VS Code:**

1. Click derecho en el panel izquierdo
2. `New File`
3. Nombre: `Estudiante.cs`
4. Escribe el código:

```csharp
namespace MiApp
{
    public class Estudiante
    {
        public string nombre { get; set; }
        public int edad { get; set; }
        public string[] telefonos { get; set; }

        public Estudiante(string nombre, int edad, string[] telefonos)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.telefonos = telefonos;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Edad: {edad}");
            Console.WriteLine($"Teléfonos: {string.Join(", ", telefonos)}");
        }
    }
}
```

### Paso 6.2: Usar la clase en Program.cs

En `Program.cs`, reemplaza el contenido:

```csharp
namespace MiApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Crear objeto
            string[] telefonos = { "900471951", "0900934305" };
            Estudiante est = new Estudiante("Carlos", 20, telefonos);

            // Usar el objeto
            est.Mostrar();
        }
    }
}
```

---

## PARTE 7: COMPILAR Y EJECUTAR EN VS CODE

### Paso 7.1: Compilar el proyecto

**Opción A: Usar la terminal de VS Code**

1. Abre la terminal: `Ctrl + ´` (o `Terminal` → `New Terminal`)
2. Escribe:
```powershell
dotnet build
```

**Opción B: Crear una tarea en VS Code**

1. `Terminal` → `Configure Tasks`
2. Elige `Create tasks.json from template`
3. Selecciona `.NET: build`
4. Se creará el archivo automáticamente

### Paso 7.2: Ejecutar el proyecto

**Desde la terminal:**
```powershell
dotnet run
```

**Resultado esperado:**
```
Nombre: Carlos
Edad: 20
Teléfonos: 900471951, 0900934305
```

---

## PARTE 8: ESTRUCTURA COMPLETA (PROYECTO REAL)

### Paso 8.1: Crear carpetas organizadas

En VS Code, click derecho en el panel izquierdo:

```
MiApp/
├── Models/
│   ├── Estudiante.cs
│   ├── Profesor.cs
│   └── Curso.cs
├── Services/
│   ├── EstudianteService.cs
│   └── CursoService.cs
├── Program.cs
├── MiApp.csproj
└── obj/
```

### Paso 8.2: Crear archivos en carpetas

```csharp
// Models/Estudiante.cs
namespace MiApp.Models
{
    public class Estudiante
    {
        public string nombre { get; set; }
        public int edad { get; set; }
    }
}

// Services/EstudianteService.cs
using MiApp.Models;

namespace MiApp.Services
{
    public class EstudianteService
    {
        public void Registrar(Estudiante est)
        {
            Console.WriteLine($"Registrando a {est.nombre}...");
        }
    }
}

// Program.cs
using MiApp.Models;
using MiApp.Services;

namespace MiApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var est = new Estudiante { nombre = "Juan", edad = 20 };
            var service = new EstudianteService();
            service.Registrar(est);
        }
    }
}
```

---

## PARTE 9: CONFIGURACIÓN DE VS CODE PARA C#

### Paso 9.1: Instalar extensiones recomendadas

1. Click en `Extensions` (Ctrl + Shift + X)
2. Busca e instala:
   - **C# Dev Kit** (Microsoft)
   - **Code Runner** (opcional, para ejecutar directamente)
   - **.NET Install Tool** (Microsoft)

### Paso 9.2: Configurar settings.json

1. `Ctrl + ,` (Settings)
2. Busca "C#" y configura:

```json
{
    "[csharp]": {
        "editor.defaultFormatter": "ms-dotnettools.csharp",
        "editor.formatOnSave": true,
        "editor.formatOnPaste": true
    },
    "omnisharp.autoStart": true,
    "omnisharp.useModernNet": true
}
```

### Paso 9.3: Crear archivo de tareas (tasks.json)

En VS Code, presiona `Ctrl + Shift + B` para crear tareas de compilación.

**Archivo `.vscode/tasks.json`:**
```json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "process",
            "args": ["build"],
            "problemMatcher": "$msCompile",
            "group": {
                "kind": "build",
                "isDefault": true
            }
        },
        {
            "label": "run",
            "command": "dotnet",
            "type": "process",
            "args": ["run"],
            "group": {
                "kind": "test",
                "isDefault": true
            },
            "dependsOn": "build"
        }
    ]
}
```

---

## PARTE 10: WORKFLOW COMPLETO (RESUMEN)

### Flujo desde PowerShell hasta ejecutar:

```powershell
# 1. CREAR PROYECTO
mkdir MiProyecto
cd MiProyecto
dotnet new console -f net10.0 --name MiProyecto

# 2. ABRIR EN VS CODE
code .

# 3. EN VS CODE:
#    - Crear archivos .cs
#    - Escribir código
#    - Guardar (Ctrl + S)

# 4. EN TERMINAL DE VS CODE (Ctrl + ´):
dotnet build    # Compilar
dotnet run      # Ejecutar

# 5. VER RESULTADO
# El programa ejecuta en la terminal
```

---

## PARTE 11: SOLUCIÓN DE PROBLEMAS

### Error: "dotnet no se reconoce"

```powershell
# Cierra PowerShell completamente
# Abre una NUEVA ventana de PowerShell
# Intenta de nuevo

dotnet --version
```

### Error: "No se encontró el archivo o la carpeta"

```powershell
# Verifica que estés en la carpeta correcta
Get-Location

# Deberías ver algo como:
# Path
# ----
# C:\Users\quiar\Downloads\MiProyecto

# Si no, navega:
cd "C:\Users\quiar\Downloads\MiProyecto"
```

### Error de compilación en VS Code

1. Abre la terminal: `Ctrl + ´`
2. Limpia el caché:
```powershell
dotnet clean
dotnet build
```

3. Si persiste, borra carpetas:
```powershell
Remove-Item -Recurse -Force bin, obj
dotnet build
```

### Intellisense no funciona

1. `Ctrl + Shift + P` → "Developer: Reload Window"
2. Espera a que recargue

---

## PARTE 12: PROYECTO EJEMPLO COMPLETO

### Paso 12.1: Crear proyecto

```powershell
mkdir MiApp
cd MiApp
dotnet new console -f net10.0 --name MiApp
code .
```

### Paso 12.2: Estructura final

```
MiApp/
├── .vscode/
│   └── tasks.json
├── Models/
│   └── Persona.cs
├── Program.cs
├── MiApp.csproj
└── obj/
```

### Paso 12.3: Archivos

**Models/Persona.cs:**
```csharp
namespace MiApp.Models
{
    public class Persona
    {
        public string nombre { get; set; }
        public int edad { get; set; }

        public Persona(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public void Saludar()
        {
            Console.WriteLine($"Hola, me llamo {nombre} y tengo {edad} años");
        }
    }
}
```

**Program.cs:**
```csharp
using MiApp.Models;

namespace MiApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Juan", 25);
            Persona p2 = new Persona("María", 23);

            p1.Saludar();
            p2.Saludar();
        }
    }
}
```

**Ejecutar:**
```powershell
dotnet run

# Resultado:
# Hola, me llamo Juan y tengo 25 años
# Hola, me llamo María y tengo 23 años
```

---

## PARTE 13: CHECKLIST ANTES DE INICIAR

✅ ¿Tengo .NET instalado?
```powershell
dotnet --version
```

✅ ¿Tengo VS Code instalado?
```powershell
code --version
```

✅ ¿Tengo extensiones C# instaladas?
- Abre VS Code → Extensions
- Busca "C#" y instala "C# Dev Kit"

✅ ¿El proyecto tiene estructura correcta?
```
MiProyecto/
├── Program.cs
├── MiProyecto.csproj
└── obj/
```

✅ ¿Compila sin errores?
```powershell
dotnet build
```

✅ ¿Se ejecuta sin errores?
```powershell
dotnet run
```

---

## TABLA RÁPIDA DE COMANDOS

| Comando | Función |
|---------|---------|
| `dotnet --version` | Ver versión de .NET |
| `dotnet new console -f net10.0 --name Nombre` | Crear nuevo proyecto |
| `dotnet build` | Compilar proyecto |
| `dotnet run` | Compilar y ejecutar |
| `dotnet clean` | Limpiar archivos compilados |
| `code .` | Abrir VS Code en carpeta actual |
| `Get-ChildItem` | Listar archivos |
| `cd carpeta` | Cambiar directorio |
| `mkdir carpeta` | Crear carpeta |

---

## FLUJO VISUAL COMPLETO

```
┌─────────────────────────────────────────────────────┐
│ 1. POWERSHELL - Crear proyecto                      │
│    mkdir MiProyecto                                 │
│    cd MiProyecto                                    │
│    dotnet new console -f net10.0 --name MiProyecto │
└─────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────┐
│ 2. POWERSHELL - Abrir en VS Code                    │
│    code .                                            │
└─────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────┐
│ 3. VS CODE - Crear archivos                         │
│    - Program.cs (editar existente)                  │
│    - Models/Clase.cs (crear nuevo)                  │
│    - Guardar (Ctrl + S)                             │
└─────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────┐
│ 4. VS CODE TERMINAL - Compilar                      │
│    Ctrl + ´                                          │
│    dotnet build                                     │
│    (o Ctrl + Shift + B)                             │
└─────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────┐
│ 5. VS CODE TERMINAL - Ejecutar                      │
│    dotnet run                                       │
│    (o Ctrl + F5)                                    │
└─────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────┐
│ 6. VER RESULTADO EN TERMINAL                        │
│    Salida del programa                              │
└─────────────────────────────────────────────────────┘
```

---

## DETALLES IMPORTANTES

### ⚠️ **Namespaces deben coincidir**
```csharp
// Si el archivo está en Models/
// El namespace DEBE ser MiApp.Models
namespace MiApp.Models
{
    public class Persona { }
}

// En Program.cs, importar:
using MiApp.Models;
```

### ⚠️ **Carpeta = namespace**
```
MiApp/
├── Models/         → namespace MiApp.Models
│   └── Persona.cs
├── Services/       → namespace MiApp.Services
│   └── PersonaService.cs
└── Program.cs      → namespace MiApp
```

### ⚠️ **Compilar antes de ejecutar**
```powershell
dotnet build   # Primero
dotnet run     # Después
```

### ⚠️ **Limpiar caché si hay problemas**
```powershell
Remove-Item -Recurse -Force bin, obj
dotnet build
```

---

**Fecha:** 11 de Diciembre de 2025  
**Propósito:** Guía completa para crear proyectos C# desde cero
