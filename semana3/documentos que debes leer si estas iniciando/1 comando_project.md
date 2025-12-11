# COMANDO --project: Ejecutar proyectos desde carpeta raíz

## ¿QUÉ ES --project?

`--project` es un parámetro de `dotnet` que te permite **especificar qué proyecto ejecutar** cuando tienes múltiples proyectos en una misma solución.

**Uso:** Cuando tienes carpetas como:
```
visualcode3s/
├── Estudiante/
│   ├── Estudiante.csproj
│   └── Program.cs
└── semana3/
    ├── semana3.csproj
    └── Program.cs
```

---

## SINTAXIS BÁSICA

```powershell
dotnet run --project "ruta/al/proyecto/Proyecto.csproj"
```

O más corto:
```powershell
dotnet run --project ./NombreProyecto
```

---

## EJEMPLOS PRÁCTICOS

### Ejemplo 1: Tu estructura actual

```powershell
cd "C:\Users\quiar\Downloads\visualcode3s"

# Ejecutar Estudiante
dotnet run --project .\Estudiante\Estudiante.csproj

# Ejecutar semana3
dotnet run --project .\semana3\semana3.csproj
```

### Ejemplo 2: Forma corta (recomendada)

```powershell
cd "C:\Users\quiar\Downloads\visualcode3s"

# Ejecutar Estudiante (sin .csproj)
dotnet run --project .\Estudiante

# Ejecutar semana3 (sin .csproj)
dotnet run --project .\semana3
```

### Ejemplo 3: Ruta completa

```powershell
# Desde cualquier carpeta
dotnet run --project "C:\Users\quiar\Downloads\visualcode3s\Estudiante\Estudiante.csproj"
```

---

## PASO A PASO: Usar --project

### Paso 1: Abre PowerShell

```powershell
# Presiona Windows + R
# Escribe: powershell
# Presiona Enter
```

### Paso 2: Navega a la carpeta raíz

```powershell
cd "C:\Users\quiar\Downloads\visualcode3s"
```

### Paso 3: Verifica que estés en la carpeta correcta

```powershell
Get-Location

# Deberías ver:
# Path
# ----
# C:\Users\quiar\Downloads\visualcode3s
```

### Paso 4: Lista los proyectos disponibles

```powershell
Get-ChildItem -Directory

# Resultado:
#     Directory: C:\Users\quiar\Downloads\visualcode3s
# 
# Mode                 LastWriteTime         Length Name
# ----                 -------------         ------ ----
# d----          Estudiante
# d----          semana3
```

### Paso 5: Ejecuta el proyecto que quieras

```powershell
# Opción A: Ejecutar Estudiante
dotnet run --project .\Estudiante

# Opción B: Ejecutar semana3
dotnet run --project .\semana3
```

---

## VARIACIONES DEL COMANDO

### Compilar sin ejecutar

```powershell
dotnet build --project .\Estudiante
```

### Limpiar proyecto

```powershell
dotnet clean --project .\Estudiante
```

### Restaurar dependencias

```powershell
dotnet restore --project .\Estudiante
```

### Especificar configuración (Debug/Release)

```powershell
dotnet run --project .\Estudiante -c Release
dotnet run --project .\Estudiante -c Debug
```

### Pasar argumentos al programa

```powershell
dotnet run --project .\Estudiante -- arg1 arg2
```

---

## COMPARACIÓN: CON VS SIN --project

### SIN --project (entrar en la carpeta)

```powershell
# 1. Navega a la carpeta del proyecto
cd .\Estudiante

# 2. Ejecuta directamente
dotnet run

# 3. Ver ubicación
Get-Location
# C:\Users\quiar\Downloads\visualcode3s\Estudiante
```

### CON --project (desde raíz)

```powershell
# 1. Estás en la carpeta raíz
cd "C:\Users\quiar\Downloads\visualcode3s"

# 2. Ejecutas especificando el proyecto
dotnet run --project .\Estudiante

# 3. Ver ubicación
Get-Location
# C:\Users\quiar\Downloads\visualcode3s
```

---

## TABLA RÁPIDA

| Qué quieres | Comando |
|-------------|---------|
| Ejecutar desde su carpeta | `cd Estudiante && dotnet run` |
| Ejecutar desde raíz (corto) | `dotnet run --project .\Estudiante` |
| Ejecutar desde raíz (largo) | `dotnet run --project .\Estudiante\Estudiante.csproj` |
| Compilar específicamente | `dotnet build --project .\Estudiante` |
| Limpiar específicamente | `dotnet clean --project .\Estudiante` |

---

## FLUJO VISUAL COMPLETO

```
Carpeta raíz: visualcode3s/
│
├── Presiona Windows + R
│   └─ Escribe: powershell
│      └─ Presiona Enter
│
├── En PowerShell:
│   cd "C:\Users\quiar\Downloads\visualcode3s"
│
├── Ejecuta uno de estos:
│   ├─ dotnet run --project .\Estudiante
│   └─ dotnet run --project .\semana3
│
└── Ver resultado en consola
    ├─ Si es Estudiante → muestra promedio (89)
    └─ Si es semana3 → muestra registro de estudiante
```

---

## EN VISUAL STUDIO CODE

Si quieres ejecutar con `--project` desde VS Code, crea tareas personalizadas:

### Crear archivo `.vscode/tasks.json`

1. En VS Code, presiona `Ctrl + Shift + P`
2. Escribe: `Tasks: Create tasks.json from template`
3. Selecciona `.NET: build`
4. Reemplaza el contenido por:

```json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "Run Estudiante",
            "command": "dotnet",
            "type": "process",
            "args": [
                "run",
                "--project",
                ".\\Estudiante"
            ],
            "group": {
                "kind": "build",
                "isDefault": false
            }
        },
        {
            "label": "Run semana3",
            "command": "dotnet",
            "type": "process",
            "args": [
                "run",
                "--project",
                ".\\semana3"
            ],
            "group": {
                "kind": "build",
                "isDefault": false
            }
        },
        {
            "label": "Build Estudiante",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "--project",
                ".\\Estudiante"
            ]
        },
        {
            "label": "Build semana3",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "--project",
                ".\\semana3"
            ]
        }
    ]
}
```

### Usar las tareas

1. Presiona `Ctrl + Shift + B` en VS Code
2. Selecciona:
   - `Run Estudiante` para ejecutar Estudiante
   - `Run semana3` para ejecutar semana3
   - `Build Estudiante` para compilar Estudiante
   - `Build semana3` para compilar semana3

---

## ERRORES COMUNES

### Error 1: "No se puede encontrar el proyecto"

```powershell
# ❌ Mal
dotnet run --project Estudiante
# Error: No se encontró el archivo Estudiante

# ✅ Bien
dotnet run --project .\Estudiante
# Funciona
```

**Solución:** Usa `.\` (punto barra invertida) para rutas relativas

### Error 2: "No estoy en la carpeta correcta"

```powershell
# Verifica dónde estás
Get-Location

# Deberías estar en:
# C:\Users\quiar\Downloads\visualcode3s

# Si no, navega:
cd "C:\Users\quiar\Downloads\visualcode3s"
```

### Error 3: "El proyecto no tiene Program.cs"

```powershell
# Verifica que exista
Get-ChildItem .\Estudiante

# Deberías ver:
# - Program.cs
# - Estudiante.csproj
# - obj/
```

### Error 4: "Conflicto de nombres" (namespace vs clase)

```powershell
# Limpia y recompila
Remove-Item -Recurse -Force .\Estudiante\bin, .\Estudiante\obj
dotnet build --project .\Estudiante
dotnet run --project .\Estudiante
```

---

## EJEMPLO COMPLETO: Flujo real

```powershell
# 1. Abre PowerShell (Windows + R → powershell)

# 2. Navega a la carpeta
cd "C:\Users\quiar\Downloads\visualcode3s"

# 3. Verifica que estés en la carpeta correcta
Get-Location
# Resultado: C:\Users\quiar\Downloads\visualcode3s

# 4. Lista los proyectos
Get-ChildItem -Directory
# Resultado: Estudiante, semana3

# 5. Ejecuta Estudiante
dotnet run --project .\Estudiante
# Resultado: 89

# 6. O ejecuta semana3
dotnet run --project .\semana3
# Resultado:
# === REGISTRO DE ESTUDIANTE ===
# ID: 179
# Nombre: Carlos Pérez
# Dirección: Av. Siempre Viva 123
# Teléfonos:
#   Teléfono 1: 0904719501
#   Teléfono 2: 0900934305
#   Teléfono 3: 0998765432
```

---

## RESUMEN RÁPIDO

**Forma más simple (recomendada):**
```powershell
cd Estudiante
dotnet run
```

**Forma con --project (desde raíz):**
```powershell
cd ..  # Si estás en Estudiante
dotnet run --project .\Estudiante
```

**Forma con ruta completa:**
```powershell
dotnet run --project "C:\Users\quiar\Downloads\visualcode3s\Estudiante"
```

---

## REFERENCIA RÁPIDA: Todos los comandos

```powershell
# EJECUTAR
dotnet run --project .\Estudiante
dotnet run --project .\semana3

# COMPILAR
dotnet build --project .\Estudiante
dotnet build --project .\semana3

# LIMPIAR
dotnet clean --project .\Estudiante
dotnet clean --project .\semana3

# RESTAURAR
dotnet restore --project .\Estudiante
dotnet restore --project .\semana3

# VER INFO
dotnet --info
```

---

**Fecha:** 11 de Diciembre de 2025  
**Propósito:** Guía completa sobre cómo usar --project
