using System;

namespace CPE_U3_Sistema_de_registro_de_jugadores_y_equipos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear torneo
            Torneo torneo = new Torneo();

            // Cargar datos base
            DatosBase.Cargar(torneo);

            // Pasar torneo al menú
            Menu menu = new Menu(torneo);
            menu.Mostrar();
        }
    }
}
