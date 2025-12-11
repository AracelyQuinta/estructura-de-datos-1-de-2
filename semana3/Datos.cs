using System;

namespace semana3
{
    public class Datos
    {
        // Propiedades del estudiante
        public string id { get; set; }          // Identificador único del estudiante
        public string nombres { get; set; }     // Nombres del estudiante
        public string apellidos { get; set; }   // Apellidos del estudiante
        public string direccion { get; set; }   // Dirección del estudiante
        public string[] telefono { get; set; }  // Arreglo de números de teléfono

        // Constructor que inicializa los datos del estudiante
        public Datos(string _id, string _nombres, string _apellidos, string _direccion, string[] _telefono)
        {
            id = _id;
            nombres = _nombres;
            apellidos = _apellidos;
            direccion = _direccion;
            telefono = _telefono;

        }
    }
}
