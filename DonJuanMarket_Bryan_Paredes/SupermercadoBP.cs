using System;

namespace DonJuanMarket_Bryan_Paredes
{
    // Clase principal que integra el inventario y la atencion de clientes
    internal class SupermercadoBP
    {
        private ArbolAVLBP inventario;
        private ColaPrioridadBP colaClientes;

        public SupermercadoBP()
        {
            inventario = new ArbolAVLBP();
            colaClientes = new ColaPrioridadBP();
        }

        // --- OPERACIONES DE INVENTARIO ---

        public void RegistrarProducto(string codigo, string nombre, string categoria, double precio, int stock)
        {
            ProductoBP nuevoProducto = new ProductoBP(codigo, nombre, categoria, precio, stock);
            bool resultado = inventario.Insertar(nuevoProducto, out string mensaje);

            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine(mensaje);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void BuscarProducto(string codigo)
        {
            ProductoBP? prod = inventario.Buscar(codigo);

            Console.WriteLine("\nRESULTADO DE LA BÚSQUEDA");
            Console.WriteLine("----------------------------------------------------------------------");

            if (prod != null)
            {
                Console.WriteLine("Producto encontrado:");
                Console.WriteLine($"Código    : {prod.Codigo}");
                Console.WriteLine($"Nombre    : {prod.Nombre}");
                Console.WriteLine($"Categoría : {prod.Categoria}");
                Console.WriteLine($"Precio    : Q{prod.Precio:F2}");
                Console.WriteLine($"Stock     : {prod.Stock}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void ActualizarProducto(string codigo, string nuevoNombre, string nuevaCategoria, double nuevoPrecio, int nuevoStock)
        {
            ProductoBP? prod = inventario.Buscar(codigo);

            Console.WriteLine("\nRESULTADO DE LA ACTUALIZACIÓN");
            Console.WriteLine("----------------------------------------------------------------------");

            if (prod != null)
            {
                prod.Nombre = nuevoNombre;
                prod.Categoria = nuevaCategoria;
                prod.Precio = nuevoPrecio;
                prod.Stock = nuevoStock;

                Console.WriteLine("Producto actualizado correctamente.");
                Console.WriteLine($"Código    : {prod.Codigo}");
                Console.WriteLine($"Nombre    : {prod.Nombre}");
                Console.WriteLine($"Categoría : {prod.Categoria}");
                Console.WriteLine($"Precio    : Q{prod.Precio:F2}");
                Console.WriteLine($"Stock     : {prod.Stock}");
            }
            else
            {
                Console.WriteLine($"Error: No existe un producto con el código {codigo}.");
            }
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void EliminarProducto(string codigo)
        {
            bool resultado = inventario.Eliminar(codigo, out string mensaje);

            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine(mensaje);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void MostrarInventario()
        {
            Console.Clear();
            inventario.MostrarInOrden();
        }

        // --- OPERACIONES DE ATENCIÓN DE CLIENTES ---

        public void AgregarClienteCola(string nombre, string tipo, int productos)
        {
            ClienteBP nuevoCliente = new ClienteBP(nombre, tipo, productos);
            int posicion = colaClientes.AgregarCliente(nuevoCliente);

            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine($"Cliente {nuevoCliente.Nombre} agregado correctamente.");
            Console.WriteLine($"Posición estimada en la cola: {posicion}");
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void AtenderSiguienteCliente()
        {
            ClienteBP? cliente = colaClientes.AtenderSiguiente();

            Console.WriteLine("\n----------------------------------------------------------------------");
            if (cliente != null)
            {
                Console.WriteLine("Atendiendo cliente:");
                Console.WriteLine($"Nombre    : {cliente.Nombre}");
                Console.WriteLine($"Tipo      : {cliente.TipoCliente}");
                Console.WriteLine($"Productos : {cliente.NumProductos}");
                Console.WriteLine("\nCliente atendido correctamente.");
            }
            else
            {
                Console.WriteLine("No hay clientes en espera.");
            }
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void MostrarClientesCola()
        {
            Console.Clear();
            colaClientes.MostrarClientesEnEspera();
        }

        // --- REPORTE DE ESTADÍSTICAS ---
        public void MostrarEstadisticas()
        {
            Console.Clear();
            Console.WriteLine("==========================================================");
            Console.WriteLine("               ESTADÍSTICAS DEL SISTEMA");
            Console.WriteLine("==========================================================");
            Console.WriteLine($"Clientes en espera en la cola : {colaClientes.Cantidad}");
            Console.WriteLine("Estado del Árbol AVL          : Balanceado y operativo");
            Console.WriteLine("----------------------------------------------------------");
        }
    }
}