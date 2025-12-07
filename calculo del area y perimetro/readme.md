# Proyecto: Estructura de Datos en C#

Este proyecto es una práctica básica de **programación orientada a objetos (POO)** en C#.  
Se definen clases que representan figuras geométricas y se calculan sus propiedades como **área** y **perímetro**.

##  Clases principales

###  `figura1` (Rectángulo)
- **Atributos:** `Largo`, `Ancho`
- **Métodos:**
  - `area()` → Calcula el área (`largo * ancho`)
  - `perimetro()` → Calcula el perímetro (`2 * (largo + ancho)`)

###  `figura2` (Rombo)
- **Atributos:** `DiagonalMayor`, `DiagonalMenor`, `Lado`
- **Métodos:**
  - `area()` → Calcula el área (`(DiagonalMayor * DiagonalMenor) / 2`)
  - `calculoperimetro(lado)` → Calcula el perímetro (`4 * lado`)

---

## Ejecución del programa

El archivo `Program.cs` contiene el método `Main`, que es el punto de entrada del programa.  
Ejemplo de ejecución:

