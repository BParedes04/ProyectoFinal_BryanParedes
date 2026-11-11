using System;

namespace DonJuanMarket_Bryan_Paredes
{
    // Clase para almacenar los datos del cliente y su prioridad
    internal class ClienteBP
    {
        public string Nombre { get; set; }          // Nombre del cliente
        public string TipoCliente { get; set; }     // "VIP", "ADULTO_MAYOR" o "REGULAR"
        public int Prioridad { get; set; }          // 1: VIP, 2: Adulto Mayor, 3: Regular
        public int NumProductos { get; set; }       // Cantidad de productos a comprar
        public DateTime HoraLlegada { get; set; }   // Para controlar el orden de llegada (FIFO)

        public ClienteBP(string nombre, string tipoCliente, int numProductos)
        {
            Nombre = nombre;
            TipoCliente = tipoCliente.ToUpper();
            NumProductos = numProductos;
            HoraLlegada = DateTime.Now;

            // Asignacion del nivel de prioridad segun el tipo de cliente
            switch (TipoCliente)
            {
                case "VIP":
                    Prioridad = 1;
                    break;
                case "ADULTO_MAYOR":
                case "ADULTOMAYOR":
                    Prioridad = 2;
                    break;
                default:
                    Prioridad = 3; // REGULAR
                    break;
            }
        }
    }
}
