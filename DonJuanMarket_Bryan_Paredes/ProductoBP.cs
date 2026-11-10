using System;

namespace DonJuanMarket_Bryan_Paredes
{
    // Clase para guardar la informacion de cada producto en la tienda
    internal class ProductoBP
    {
        public string Codigo { get; set; }      // Clave unica, ej. PROD001
        public string Nombre { get; set; }      // Nombre del articulo
        public string Categoria { get; set; }   // Categoria (Alimentos, Bebidas, etc.)
        public double Precio { get; set; }      // Precio de venta
        public int Stock { get; set; }          // Cantidad disponible en almacen

        public ProductoBP(string codigo, string nombre, string categoria, double precio, int stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
        }
    }
}
