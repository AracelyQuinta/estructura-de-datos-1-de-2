namespace semana3
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Se define un arreglo con tres números de teléfono
            string[] telefono = { "900471951", "0900934305", "0998765432" };

            // Se crea un objeto 'Datos' con la información del estudiante
            Datos datos = new Datos("1723456789", "Carlos", "Perez",
                "Av. Siempre Viva 123", telefono);

            // Se imprime un encabezado en consola
            Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");

            // Se muestran los datos del estudiante
            Console.WriteLine($"ID: {datos.id}");
            Console.WriteLine($"Nombre: {datos.nombres} {datos.apellidos}");
            Console.WriteLine($"Direccion: {datos.direccion}");

            // Se imprime la lista de teléfonos
            Console.WriteLine("Telefonos:");
            for (int i = 0; i < datos.telefono.Length; i++)
            {
                Console.WriteLine($"  Telefono {i + 1}: {datos.telefono[i]}");
            }
        }
    }
}
