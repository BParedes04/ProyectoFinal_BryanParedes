using System;
using System.Collections.Generic;

namespace DonJuanMarket_Bryan_Paredes
{
    // Cola de prioridad basada en Min-Heap para la atencion de clientes
    internal class ColaPrioridadBP
    {
        private List<ClienteBP> heap;

        public ColaPrioridadBP()
        {
            heap = new List<ClienteBP>();
        }

        public int Cantidad => heap.Count;

        // Compara dos clientes: primero por nivel de prioridad y luego por hora de llegada (FIFO)
        private bool EsMayorPrioridad(ClienteBP c1, ClienteBP c2)
        {
            if (c1.Prioridad < c2.Prioridad) return true;
            if (c1.Prioridad > c2.Prioridad) return false;

            // Si la prioridad es igual, el que llego antes tiene preferencia
            return c1.HoraLlegada < c2.HoraLlegada;
        }

        // Reorganiza hacia arriba al insertar (Bubble Up)
        private void BubbleUp(int indice)
        {
            while (indice > 0)
            {
                int padre = (indice - 1) / 2;

                if (EsMayorPrioridad(heap[indice], heap[padre]))
                {
                    ClienteBP temp = heap[indice];
                    heap[indice] = heap[padre];
                    heap[padre] = temp;

                    indice = padre;
                }
                else
                {
                    break;
                }
            }
        }

        // Reorganiza hacia abajo tras extraer la raiz (Bubble Down)
        private void BubbleDown(int indice)
        {
            int menor = indice;
            int izq = 2 * indice + 1;
            int der = 2 * indice + 2;

            if (izq < heap.Count && EsMayorPrioridad(heap[izq], heap[menor]))
            {
                menor = izq;
            }

            if (der < heap.Count && EsMayorPrioridad(heap[der], heap[menor]))
            {
                menor = der;
            }

            if (menor != indice)
            {
                ClienteBP temp = heap[indice];
                heap[indice] = heap[menor];
                heap[menor] = temp;

                BubbleDown(menor);
            }
        }

        // Agrega un nuevo cliente a la cola de prioridad
        public int AgregarCliente(ClienteBP cliente)
        {
            heap.Add(cliente);
            int posicionInsertada = heap.Count - 1;
            BubbleUp(posicionInsertada);

            // Retorna una posicion estimada en la cola
            return ObtenerPosicionEstimada(cliente);
        }

        // Retorna la posicion en la que quedo el cliente tras el reordenamiento
        private int ObtenerPosicionEstimada(ClienteBP cliente)
        {
            for (int i = 0; i < heap.Count; i++)
            {
                if (heap[i] == cliente)
                {
                    return i + 1;
                }
            }
            return heap.Count;
        }

        // Extrae y retorna el cliente con mayor prioridad de la raiz
        public ClienteBP? AtenderSiguiente()
        {
            if (heap.Count == 0) return null;

            ClienteBP atendido = heap[0];
            int ultimo = heap.Count - 1;

            heap[0] = heap[ultimo];
            heap.RemoveAt(ultimo);

            if (heap.Count > 0)
            {
                BubbleDown(0);
            }

            return atendido;
        }

        // Imprime en consola todos los clientes que se encuentran en la cola de espera
        public void MostrarClientesEnEspera()
        {
            if (heap.Count == 0)
            {
                Console.WriteLine("\nNo hay clientes en espera.");
                return;
            }

            Console.WriteLine("==========================================================");
            Console.WriteLine("                  CLIENTES EN ESPERA");
            Console.WriteLine("==========================================================");
            Console.WriteLine($"{"Posición",-10} {"Nombre",-22} {"Tipo",-16} {"Productos",-10}");
            Console.WriteLine("----------------------------------------------------------");

            for (int i = 0; i < heap.Count; i++)
            {
                Console.WriteLine($"{i + 1,-10} {heap[i].Nombre,-22} {heap[i].TipoCliente,-16} {heap[i].NumProductos,-10}");
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Total en cola: {heap.Count}");
        }
    }
}
