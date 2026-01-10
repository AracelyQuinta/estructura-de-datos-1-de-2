using System;
using registroDeAportes;

class Program
{
    static void Main(string[] args)
    {
        // Arrays para almacenar 5 registros
        detalleAporte[] registros = new detalleAporte[5];
        RegistroFinanciero[] montos = new RegistroFinanciero[5];

        // Registro 1 se guarda la información del aporte y el monto correspondiente.
        registros[0] = new detalleAporte("2024-10-01", "Juan Perez", "Aporte mensual");
        montos[0] = new RegistroFinanciero(20.00);

        // Registro 2
        registros[1] = new detalleAporte("2024-10-02", "Maria Gomez", "Aporte especial");
        montos[1] = new RegistroFinanciero(50.00);

        // Registro 3
        registros[2] = new detalleAporte("2024-10-03", "Carlos Ruiz", "Aporte mensual");
        montos[2] = new RegistroFinanciero(20.00);

        // Registro 4
        registros[3] = new detalleAporte("2024-10-04", "Ana Lopez", "Aporte voluntario");
        montos[3] = new RegistroFinanciero(30.00);

        // Registro 5
        registros[4] = new detalleAporte("2024-10-05", "Luis Martinez", "Aporte mensual");
        montos[4] = new RegistroFinanciero(20.00);

        // Reportería: imprime encabezados de la tabla.

        Console.WriteLine("Fecha        | Nombre         | Concepto           |  Monto");
        Console.WriteLine("----------------------------------------------------------");


       //Recorre los registros y muestra cada aporte con su monto en formato tabular.
        for (int i = 0; i < registros.Length; i++)
        {
            Console.WriteLine($"{registros[i].fecha,-12} | {registros[i].nombre,-14} | {registros[i].conceptodeaporte,-18} | {montos[i].MontoAbonado,6}");
        }

        // Calcular total
        double total = 0;
        for (int i = 0; i < montos.Length; i++)
        {
            total += montos[i].MontoAbonado;
        }
        // Imprime el total de aportes.

        Console.WriteLine($"\nTotal de aportes: {total}");
    }
}

