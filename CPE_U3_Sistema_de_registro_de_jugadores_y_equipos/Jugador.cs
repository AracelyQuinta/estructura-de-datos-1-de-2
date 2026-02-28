namespace CPE_U3_Sistema_de_registro_de_jugadores_y_equipos
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public string Equipo { get; set; }

        public Jugador(string nombre, string equipo)
        {
            Nombre = nombre;
            Equipo = equipo;
        }
    }
}