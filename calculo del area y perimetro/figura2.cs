// Espacio de nombres 'estructura_de_datos'
// Se utiliza para organizar y agrupar clases relacionadas dentro de un mismo proyecto
namespace estructura_de_datos
{
    // Clase 'figura1'
    // Representa una figura geométrica rectangular definida por su largo y ancho
    public class figura1
    {
        // Campos privados: solo accesibles dentro de la clase
        // Guardan las dimensiones de la figura
        private int largo;
        private int ancho;

        // Propiedades públicas: permiten acceder y modificar los campos privados
        // Uso de 'get' y 'set' para encapsular los atributos
        public int Largo { get => largo; set => largo = value; }
        public int Ancho { get => ancho; set => ancho = value; }

        // Constructor de la clase
        // Inicializa la figura con valores de largo y ancho
        public figura1(int _largo, int _ancho)
        {
            this.largo = _largo; // Asigna el valor recibido al campo 'largo'
            this.ancho = _ancho; // Asigna el valor recibido al campo 'ancho'
        }

        // Método 'area'
        // Calcula el área de la figura rectangular
        // Fórmula: largo * ancho
        public int area()
        {
            return largo * ancho;
        }

        // Método 'perimetro'
        // Calcula el perímetro de la figura rectangular
        // Fórmula: 2 * (largo + ancho)
        public int perimetro()
        {
            return 2 * (largo + ancho);
        }
    }
}