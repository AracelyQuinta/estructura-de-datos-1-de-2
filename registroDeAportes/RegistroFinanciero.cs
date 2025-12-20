// Importa el espacio de nombres System, que contiene clases básicas
// como Console, tipos primitivos y utilidades generales.
using System;

// Definición del espacio de nombres "registroDeAportes".
// Sirve para organizar el código y evitar conflictos de nombres.
namespace registroDeAportes
{
    // Definición de un struct llamado "RegistroFinanciero".
    // Un struct es un tipo de valor que se utiliza para agrupar datos relacionados.
    public struct RegistroFinanciero
    {
        // Campo público que almacena el monto abonado en una transacción financiera.
        // Se usa double porque puede contener valores decimales.
        public double MontoAbonado;

        // Constructor del struct.
        // Permite inicializar el campo "MontoAbonado" al crear una nueva instancia.
        public RegistroFinanciero(double montoAbonado)
        {
            // Asigna el valor recibido como parámetro al campo MontoAbonado.
            MontoAbonado = montoAbonado;
        }
    }
}
