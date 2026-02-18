using System;
using System.Collections.Generic;
using System.Linq;

class ProgramaVacunacion
{
    static void Main()
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("   CAMPAÑA DE VACUNACIÓN COVID-19 - INFORME FICTICIO  ");
        Console.WriteLine("======================================================");

        Console.WriteLine("El Gobierno Nacional, a través del Ministerio de Salud, requiere información sobre la campaña de vacunación contra el COVID-19.\n");

        // 1. Generar 500 ciudadanos ficticios
        var ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i);
        }

        // 2. Crear subconjuntos de vacunados
        var vacunadosPfizer = new HashSet<string>();
        var vacunadosAstraZeneca = new HashSet<string>();

        // Selección ficticia de 75 ciudadanos para Pfizer
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add("Ciudadano " + i);
        }

        // Selección ficticia de 75 ciudadanos para AstraZeneca
        for (int i = 50; i < 125; i++)
        {
            vacunadosAstraZeneca.Add("Ciudadano " + i);
        }

        // 3. Operaciones de teoría de conjuntos
        var noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer.Union(vacunadosAstraZeneca));

        var ambasDosis = new HashSet<string>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstraZeneca);

        var soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        var soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        // 4. Mostrar resultados con formato
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("RESULTADOS DE LA CAMPAÑA DE VACUNACIÓN");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ciudadanos con ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Ciudadanos solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Ciudadanos solo AstraZeneca: {soloAstraZeneca.Count}");

        Console.WriteLine("\nEjemplo de ciudadanos no vacunados:");
        foreach (var c in noVacunados.Take(10))
        {
            Console.WriteLine(" - " + c);
        }

        Console.WriteLine("\n======================================================");
        Console.WriteLine("        FIN DEL INFORME FICTICIO DE VACUNACIÓN        ");
        Console.WriteLine("======================================================");
    }
}
