# IMPORTANTE RECONOCER - Guía para Reparar Errores en C#

## FASE 1: IDENTIFICAR ERRORES

### Paso 1.1: Compilar el proyecto

```powershell
cd "C:\Users\quiar\Downloads\visualcode3s\semana3"
dotnet build
```

**Esto te muestra todos los errores.** Los principales encontrados fueron:

| Error | Causa | Solución |
|-------|-------|----------|
| `CS5001: El programa no contiene Main` | El método se llama `main` (minúscula) | Cambiar a `Main` |
| `CS0246: El nombre 'Clase' no se encontró` | Conflicto namespace vs clase | Renombrar o usar nombre cualificado |
| `CS1729: Constructor no toma 3 argumentos` | Tipos de parámetros no coinciden | Verificar tipos (int vs string) |

---

## FASE 2: DIAGNOSTICAR (Lee los errores)

### Ejemplo del error que vimos:
```
error CS0246: El nombre del tipo o del espacio de nombres 'Datos' no se encontró
```

**Esto significa:**
- ❌ No existe una clase llamada `Datos` en el namespace actual
- ❌ Falta un `using` para importar el namespace
- ❌ O el nombre está escrito diferente (mayúsculas/minúsculas)

### Cómo revisar:
```powershell
# Buscar si la clase existe
findstr /r "public class" *.cs

# Resultado esperado: "public class Datos"
```

---

## FASE 3: REPARAR ERRORES COMUNES

### Error 1: Método `Main` en minúsculas

**Síntoma:**
```
CS5001: El programa no contiene ningún método 'Main' estático adecuado
```

**Solución rápida (búsqueda y reemplazo):**
```powershell
# Ver el archivo
Get-Content Program.cs

# Buscar "main" en minúsculas
findstr /i "static void main" Program.cs

# Resultado: "static void main(string[] args)"  ← ESTÁ MAL
```

**Corregir en VS Code:**
- Buscar: `static void main`
- Reemplazar por: `static void Main`

**O con PowerShell:**
```powershell
(Get-Content Program.cs) -replace 'static void main', 'static void Main' | Set-Content Program.cs
```

---

### Error 2: Conflicto de nombres (namespace vs clase)

**Síntoma:**
```
CS0246: El nombre del tipo 'Estudiante' no se encontró
```

**Diagnóstico:**
```powershell
# Ver el namespace de cada archivo
findstr /r "namespace" *.cs

# Resultado:
# Program.cs: namespace Estudiante
# Estudiante.cs: namespace Estudiante
# Clase: public class Estudiante

# El problema: namespace Y clase tienen el MISMO nombre
```

**Solución opción A: Renombrar el namespace**
```powershell
# En Estudiante.cs y Program.cs, cambiar:
# De: namespace Estudiante
# A:  namespace MiApp

(Get-Content Estudiante.cs) -replace 'namespace Estudiante', 'namespace MiApp' | Set-Content Estudiante.cs
(Get-Content Program.cs) -replace 'namespace Estudiante', 'namespace MiApp' | Set-Content Program.cs
```

**Solución opción B: Renombrar la clase**
```powershell
# Cambiar: public class Estudiante
# A:       public class Alumno

(Get-Content Estudiante.cs) -replace 'public class Estudiante', 'public class Alumno' | Set-Content Estudiante.cs
(Get-Content Program.cs) -replace 'new Estudiante', 'new Alumno' | Set-Content Program.cs
```

---

### Error 3: Tipos de parámetros incorrectos

**Síntoma:**
```
CS1729: 'Datos' no contiene un constructor que tome 3 argumentos
```

**Diagnóstico:**
```powershell
# Ver el constructor en Datos.cs
findstr /r "public Datos" Datos.cs

# Ver cómo se llama en Program.cs
findstr /r "new Datos" Program.cs

# Comparar: ¿Coinciden los tipos?
```

**Ejemplo que encontramos:**
```csharp
// En Datos.cs: constructor espera string[]
public Datos(string _id, string _nombres, string _apellidos, string _direccion, string[] _telefono)

// En Program.cs: estábamos pasando int[]
int[] telefono = { 900471951, 0900934305, 0998765432 };  // ❌ int[], no string[]
```

**Corregir:**
```csharp
// Cambiar a:
string[] telefono = { "900471951", "0900934305", "0998765432" };  // ✅ string[]
```

---

## FASE 4: LIMPIAR CACHÉ Y RECOMPILAR

A veces el compilador guarda información antigua en las carpetas `bin` y `obj`.

```powershell
cd "C:\Users\quiar\Downloads\visualcode3s\semana3"

# Opción 1: Eliminar y compilar
rm -r bin, obj
dotnet build

# Opción 2: Limpiar completamente
dotnet clean
dotnet build
```

---

## FASE 5: VERIFICAR Y EJECUTAR

```powershell
# Paso 1: Compilar
dotnet build

# Si hay errores, repite FASE 2-3
# Si compila correctamente, ejecuta:

# Paso 2: Ejecutar desde la carpeta del proyecto
cd semana3
dotnet run

# Paso 3: Ver resultado
# Deberías ver el output sin errores
```

---

## TABLA RÁPIDA DE SOLUCIONES

| Síntoma | Comando de diagnóstico | Solución |
|---------|------------------------|----------|
| `CS5001: Main no existe` | `findstr /i "main" Program.cs` | Cambiar `main` a `Main` |
| `CS0246: Tipo no encontrado` | `findstr /r "public class" *.cs` | Verificar nombres y namespaces coincidan |
| `CS1729: Constructor error` | `dotnet build` (leer el error) | Verificar tipos de parámetros |
| `Errors después de cambios` | `rm -r bin, obj; dotnet build` | Limpiar caché |

---

## RESUMEN DEL FLUJO DE REPARACIÓN

```
1. COMPILAR → Ver errores
   └─ dotnet build

2. LEER ERROR → Entender qué falta
   └─ Busca: CS#### + descripción

3. DIAGNOSTICAR → Verificar archivos
   └─ findstr, Get-Content, grep_search

4. REPARAR → Cambiar código
   └─ (Get-Content) -replace | Set-Content

5. LIMPIAR → Eliminar caché antiguo
   └─ rm -r bin, obj

6. COMPILAR → Verificar que funciona
   └─ dotnet build

7. EJECUTAR → Probar resultado
   └─ dotnet run
```

---

## CONSEJOS PRÁCTICOS

### 1. **Siempre lee el número de error (CS####)**
   - `CS5001` = Problema con Main
   - `CS0246` = Tipo no encontrado
   - `CS1729` = Constructor no coincide
   - `CS8981` = Nombre con solo minúsculas (warning, no error)

### 2. **Verifica los detalles del error**
   - Línea exacta donde está el error
   - Nombre de la clase/variable
   - Namespace correcto

### 3. **Después de cambiar código, SIEMPRE:**
   - Limpiar caché: `rm -r bin, obj`
   - Recompilar: `dotnet build`
   - Ejecutar: `dotnet run`

### 4. **Conflictos de nombres comunes:**
   - Namespace vs clase con mismo nombre → Renombra uno
   - Variable `datos` vs clase `Datos` → Usa mayúsculas para clases
   - Método `main` vs `Main` → C# es sensible a mayúsculas

### 5. **Arrays - Lo importante:**
   - `int[] numeros` → Solo números enteros
   - `string[] nombres` → Solo texto
   - **Deben coincidir** con lo que espera el constructor

---

## EJEMPLO PRÁCTICO: Archivo con errores

**Antes (Con errores):**
```csharp
// Program.cs
namespace Estudiante  // ← Mismo nombre que la clase
{
    public class Program
    {
        static void main(string[] args)  // ← Minúscula
        {
            int[] telefono = { 900471951, 0900934305 };  // ← int[], no string[]
            Estudiante est = new Estudiante("Carlos", telefono);
        }
    }
}

// Estudiante.cs
namespace Estudiante  // ← Conflicto de nombres
{
    public class Estudiante  // ← Mismo nombre que namespace
    {
        public Estudiante(string nombre, string[] telefono) { }  // ← Espera string[]
    }
}
```

**Después (Corregido):**
```csharp
// Program.cs
namespace MiApp  // ← Renombrado
{
    public class Program
    {
        static void Main(string[] args)  // ← Mayúscula
        {
            string[] telefono = { "900471951", "0900934305" };  // ← string[]
            Estudiante est = new Estudiante("Carlos", telefono);
        }
    }
}

// Estudiante.cs
namespace MiApp  // ← Mismo namespace que Program
{
    public class Estudiante
    {
        public Estudiante(string nombre, string[] telefono) { }
    }
}
```

---

**Fecha de creación:** 11 de Diciembre de 2025  
**Propósito:** Guía de referencia para diagnosticar y reparar errores en proyectos C#
