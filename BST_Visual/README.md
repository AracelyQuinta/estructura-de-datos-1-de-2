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

## Visualizacion previa del programa 
<img width="886" height="551" alt="image" src="https://github.com/user-attachments/assets/5bb07816-391b-41ab-91ee-053f84d90d1e" />

Cabe mencionar que el formulario desarrollado en Windows Forms incluye valores preestablecidos en el árbol binario de búsqueda. En el constructor de la clase Form1 se insertan automáticamente los nodos con los valores 50, 30, 70, 20, 40, 60 y 80, lo que permite que al iniciar la aplicación el usuario observe un árbol ya formado.
