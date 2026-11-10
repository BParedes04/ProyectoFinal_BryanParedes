using System;

namespace DonJuanMarket_Bryan_Paredes
{
    // Nodo individual que conforma el arbol AVL de inventario
    internal class NodoAVLBP
    {
        public ProductoBP Producto { get; set; }
        public int Altura { get; set; }
        public NodoAVLBP? Izquierdo { get; set; }
        public NodoAVLBP? Derecho { get; set; }

        public NodoAVLBP(ProductoBP producto)
        {
            Producto = producto;
            Altura = 1; // Un nodo nuevo entra como hoja con altura 1
            Izquierdo = null;
            Derecho = null;
        }
    }
}
