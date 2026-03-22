# BST_Visual

Aplicación en C# para gestionar un Árbol Binario de Búsqueda (BST) con interfaz gráfica.

## Funcionalidades

- **Insertacion de valores**: Agrega un número entero al árbol.
- **Busqueda de valores**: Verifica si un número existe en el árbol.
- **Eliminar valores**: Remueve un número del árbol.
- **Mostrar recorridos**: Muestra Preorden, Inorden y Postorden.
- **Mostrar información**: Muestra el mínimo, máximo y altura del árbol.
- **Limpiar árbol**: Elimina todos los nodos del árbol.
- **Visualización gráfica**: Dibuja el árbol en un PictureBox.

## Cómo usar

1. Ejecuta la aplicación con `dotnet run`.
2. Ingresa un valor en el cuadro de texto.
3. Usa los botones para realizar operaciones.
4. El árbol se actualiza visualmente después de insertar o eliminar.

## Estructura del proyecto

- `Nodo.cs`: Clase para los nodos del árbol.
- `ArbolBinarioBusqueda.cs`: Clase para el BST con todas las operaciones.
- `Form1.cs`: Interfaz gráfica de usuario.
- `Program.cs`: Punto de entrada de la aplicación.