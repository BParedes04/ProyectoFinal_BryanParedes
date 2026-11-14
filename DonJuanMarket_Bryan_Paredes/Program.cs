using System;

namespace DonJuanMarket_Bryan_Paredes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SupermercadoBP mercado = new SupermercadoBP();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();

                // Encabezado principal en color Cian
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==========================================================");
                Console.WriteLine("             SISTEMA DE GESTIÓN DE SUPERMERCADO");
                Console.WriteLine("                      DON JUAN MARKET");
                Console.WriteLine("==========================================================");
                Console.ResetColor();

                // Sección de Inventario en Amarillo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("INVENTARIO (AVL)");
                Console.ResetColor();
                Console.WriteLine(" [1] Registrar producto");
                Console.WriteLine(" [2] Buscar producto por código");
                Console.WriteLine(" [3] Actualizar producto");
                Console.WriteLine(" [4] Eliminar producto");
                Console.WriteLine(" [5] Mostrar inventario ordenado");

                // Sección de Atención en Verde Claro
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ATENCIÓN DE CLIENTES (HEAP)");
                Console.ResetColor();
                Console.WriteLine(" [6] Agregar cliente a la cola");
                Console.WriteLine(" [7] Atender siguiente cliente");
                Console.WriteLine(" [8] Mostrar clientes en espera");

                // Sección de Reportes en Magenta
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("REPORTES");
                Console.ResetColor();
                Console.WriteLine(" [9] Mostrar estadísticas del sistema");
                Console.WriteLine(" [10] Salir");

                Console.WriteLine("----------------------------------------------------------");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        OpcionRegistrarProducto(mercado);
                        break;
                    case "2":
                        OpcionBuscarProducto(mercado);
                        break;
                    case "3":
                        OpcionActualizarProducto(mercado);
                        break;
                    case "4":
                        OpcionEliminarProducto(mercado);
                        break;
                    case "5":
                        mercado.MostrarInventario();
                        Pausar();
                        break;
                    case "6":
                        OpcionAgregarCliente(mercado);
                        break;
                    case "7":
                        mercado.AtenderSiguienteCliente();
                        Pausar();
                        break;
                    case "8":
                        mercado.MostrarClientesCola();
                        Pausar();
                        break;
                    case "9":
                        mercado.MostrarEstadisticas();
                        Pausar();
                        break;
                    case "10":
                        salir = true;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n¡Gracias por utilizar el sistema de Don Juan Market!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void Pausar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void OpcionRegistrarProducto(SupermercadoBP mercado)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== REGISTRAR PRODUCTO ===");
            Console.ResetColor();

            Console.Write("Código (ej. PROD001) : ");
            string codigo = Console.ReadLine() ?? "";
            Console.Write("Nombre               : ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Categoría            : ");
            string categoria = Console.ReadLine() ?? "";

            double precio = 0;
            while (true)
            {
                Console.Write("Precio (> 0)         : ");
                if (double.TryParse(Console.ReadLine(), out precio) && precio > 0) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Ingrese un precio válido mayor a 0.");
                Console.ResetColor();
            }

            int stock = -1;
            while (true)
            {
                Console.Write("Stock (>= 0)         : ");
                if (int.TryParse(Console.ReadLine(), out stock) && stock >= 0) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Ingrese un stock válido mayor o igual a 0.");
                Console.ResetColor();
            }

            mercado.RegistrarProducto(codigo, nombre, categoria, precio, stock);
            Pausar();
        }

        private static void OpcionBuscarProducto(SupermercadoBP mercado)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== BUSCAR PRODUCTO ===");
            Console.ResetColor();

            Console.Write("Ingrese el código del producto: ");
            string codigo = Console.ReadLine() ?? "";
            mercado.BuscarProducto(codigo);
            Pausar();
        }

        private static void OpcionActualizarProducto(SupermercadoBP mercado)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== ACTUALIZAR PRODUCTO ===");
            Console.ResetColor();

            Console.Write("Ingrese el código del producto a actualizar: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Nuevo Nombre    : ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Nueva Categoría : ");
            string categoria = Console.ReadLine() ?? "";

            double precio = 0;
            while (true)
            {
                Console.Write("Nuevo Precio    : ");
                if (double.TryParse(Console.ReadLine(), out precio) && precio > 0) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Precio inválido.");
                Console.ResetColor();
            }

            int stock = -1;
            while (true)
            {
                Console.Write("Nuevo Stock     : ");
                if (int.TryParse(Console.ReadLine(), out stock) && stock >= 0) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Stock inválido.");
                Console.ResetColor();
            }

            mercado.ActualizarProducto(codigo, nombre, categoria, precio, stock);
            Pausar();
        }

        private static void OpcionEliminarProducto(SupermercadoBP mercado)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== ELIMINAR PRODUCTO ===");
            Console.ResetColor();

            Console.Write("Ingrese el código del producto a eliminar: ");
            string codigo = Console.ReadLine() ?? "";
            mercado.EliminarProducto(codigo);
            Pausar();
        }

        private static void OpcionAgregarCliente(SupermercadoBP mercado)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== AGREGAR CLIENTE A LA COLA ===");
            Console.ResetColor();

            Console.Write("Nombre del cliente       : ");
            string nombre = Console.ReadLine() ?? "";

            Console.WriteLine("Tipos de cliente: 1. VIP  2. Adulto Mayor  3. Regular");
            Console.Write("Seleccione el tipo (1/2/3): ");
            string opcionTipo = Console.ReadLine() ?? "";
            string tipo = "REGULAR";

            if (opcionTipo == "1") tipo = "VIP";
            else if (opcionTipo == "2") tipo = "ADULTO_MAYOR";

            int productos = 0;
            while (true)
            {
                Console.Write("Cantidad de productos    : ");
                if (int.TryParse(Console.ReadLine(), out productos) && productos > 0) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Ingrese una cantidad válida.");
                Console.ResetColor();
            }

            mercado.AgregarClienteCola(nombre, tipo, productos);
            Pausar();
        }
    }
}
