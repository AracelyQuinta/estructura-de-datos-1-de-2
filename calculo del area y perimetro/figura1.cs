// Definimos un espacio de nombres llamado 'estructura_de_datos'
// Sirve para organizar y agrupar clases relacionadas
namespace estructura_de_datos
{
    // Declaramos una clase llamada 'figura1'
    // Representa una figura rectangular con largo y ancho
    public class figura1
    {
        // Campos privados que almacenan las dimensiones de la figura
        private int largo;
        private int ancho;

        // Propiedades públicas para acceder y modificar los campos privados
        // 'Largo' permite leer y asignar el valor del campo 'largo'
        public int Largo { get => largo; set => largo = value; }

        // 'Ancho' permite leer y asignar el valor del campo 'ancho'
        public int Ancho { get => ancho; set => ancho = value; }

        // Constructor de la clase
        // Recibe dos parámetros (_largo y _ancho) y los asigna a los campos internos
        public figura1(int _largo, int _ancho)
        {
            this.largo = _largo;
            this.ancho = _ancho;
        }

        // Método que calcula el área de la figura
        // Fórmula: largo * ancho
        public int area()
        {
            return largo * ancho;
        }

        // Método que calcula el perímetro de la figura
        // Fórmula: 2 * (largo + ancho)
        public int perimetro()
        {
            return 2 * (largo + ancho);
        }
    }
}