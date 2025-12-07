// Definimos el espacio de nombres donde estarán nuestras clases
namespace estructura_de_datos
{
    // Clase principal del programa
    class Program
    {
        // Método Main: punto de entrada del programa
        static void Main(string[] args)
        {
            // Creamos un objeto de tipo figura1 (rectángulo) con largo=20 y ancho=9
            figura1 rectangulo = new figura1(20, 9);

            // Mostramos los datos del rectángulo
            Console.WriteLine("-----Rectangulo-----");
            Console.WriteLine($"Largo: {rectangulo.Largo}");
            Console.WriteLine($"Ancho: {rectangulo.Ancho}");
            Console.WriteLine($"Area: {rectangulo.area()}");
            Console.WriteLine($"Perimetro: {rectangulo.perimetro()}");

            // Creamos un objeto de tipo figura2 (rombo) con diagonal mayor=30 y diagonal menor=10
            figura2 rombo = new figura2(30, 10);

            // Mostramos los datos del rombo
            Console.WriteLine("-----Rombo-----");
            Console.WriteLine($"DiagonalMayor: {rombo.DiagonalMayor}");
            Console.WriteLine($"DiagonalMenor: {rombo.DiagonalMenor}");
            Console.WriteLine($"Lado: {rombo.Lado}");
            Console.WriteLine($"Area: {rombo.area()}");
            Console.WriteLine($"Perimetro: {rombo.calculoperimetro(rombo.Lado)}");

            // Espera una entrada del usuario antes de cerrar la consola
            Console.ReadLine();
        }
    }
}
