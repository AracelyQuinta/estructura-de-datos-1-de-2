// Espacio de nombres 'estructura_de_datos'
// Se utiliza para organizar y agrupar clases relacionadas dentro de un mismo proyecto
namespace estructura_de_datos
{
    // Clase 'figura2'
    // Representa una figura geométrica rombo definida por sus diagonales y lado
    public class figura2
    {
        // Campos privados: solo accesibles dentro de la clase
        // Guardan las dimensiones de la figura
        private int diagonalMayor;
        private int diagonalMenor;
        private int lado;

        // Propiedades públicas: permiten acceder y modificar los campos privados
        // Uso de 'get' y 'set' para encapsular los atributos
        public int DiagonalMayor { get => diagonalMayor; set => diagonalMayor = value; }
        public int DiagonalMenor { get => diagonalMenor; set => diagonalMenor = value; }
        public int Lado { get => lado; set => lado = value; }

        // Constructor de la clase
        // Inicializa el rombo con valores de diagonales y opcionalmente el lado
        public figura2(int _diagonalMayor, int _diagonalMenor, int lado = 0)
        {
            this.diagonalMayor = _diagonalMayor; // Asigna el valor recibido al campo 'diagonalMayor'
            this.diagonalMenor = _diagonalMenor; // Asigna el valor recibido al campo 'diagonalMenor'
            this.Lado = lado;                    // Asigna el valor recibido al campo 'lado'
        }

        // Método 'area'
        // Calcula el área del rombo
        // Fórmula: (DiagonalMayor * DiagonalMenor) / 2
        public int area()
        {
            return (diagonalMayor * diagonalMenor) / 2;
        }

        // Método 'calculoperimetro'
        // Calcula el perímetro del rombo
        // Fórmula: 4 * lado
        public double calculoperimetro(int lado)
        {
            return 4 * lado;
        }
    }
}
