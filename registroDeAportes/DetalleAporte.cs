using System;

// Define un espacio de nombres llamado "registroDeAportes".
// Sirve para organizar el código y evitar conflictos de nombres.
namespace registroDeAportes
{
    // Declara un record público llamado "detalleAporte".
    // Los records en C# son tipos de referencia inmutables por defecto,
    // Este record almacena tres propiedades: fecha, nombre y conceptodeaporte.

        public record detalleAporte(string fecha, string nombre, string conceptodeaporte);

}
