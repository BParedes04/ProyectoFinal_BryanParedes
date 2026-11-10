using System;

namespace DonJuanMarket_Bryan_Paredes
{
    internal class ArbolAVLBP
    {
        private NodoAVLBP? raiz;

        public ArbolAVLBP()
        {
            raiz = null;
        }

        // Obtiene la altura de un nodo de forma segura para evitar errores de nulos
        private int ObtenerAltura(NodoAVLBP? nodo)
        {
            return nodo == null ? 0 : nodo.Altura;
        }

        // Calcula el factor de balance (diferencia entre la rama izquierda y derecha)
        private int ObtenerBalance(NodoAVLBP? nodo)
        {
            if (nodo == null) return 0;
            return ObtenerAltura(nodo.Izquierdo) - ObtenerAltura(nodo.Derecho);
        }

        // Actualiza la altura de un nodo basándose en la rama más alta
        private void ActualizarAltura(NodoAVLBP nodo)
        {
            nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izquierdo), ObtenerAltura(nodo.Derecho));
        }

        // Rotacion simple a la derecha para equilibrar desbalances a la izquierda
        private NodoAVLBP RotarDerecha(NodoAVLBP y)
        {
            NodoAVLBP x = y.Izquierdo!;
            NodoAVLBP T2 = x.Derecho!;

            // Reasignacion de ramas
            x.Derecho = y;
            y.Izquierdo = T2;

            // Se recalculan las alturas
            ActualizarAltura(y);
            ActualizarAltura(x);

            return x;
        }

        // Rotacion simple a la izquierda para equilibrar desbalances a la derecha
        private NodoAVLBP RotarIzquierda(NodoAVLBP x)
        {
            NodoAVLBP y = x.Derecho!;
            NodoAVLBP T2 = y.Izquierdo!;

            // Reasignacion de ramas
            y.Izquierdo = x;
            x.Derecho = T2;

            // Se recalculan las alturas
            ActualizarAltura(x);
            ActualizarAltura(y);

            return y;
        }

        // Metodo publico para insertar un producto en el inventario
        public bool Insertar(ProductoBP producto, out string mensaje)
        {
            bool insertadoExitosamente = false;
            raiz = InsertarRecursivo(raiz, producto, ref insertadoExitosamente, out mensaje);
            return insertadoExitosamente;
        }

        // Insercion recursiva con control de duplicados y balanceo automatico AVL
        private NodoAVLBP InsertarRecursivo(NodoAVLBP? nodo, ProductoBP producto, ref bool exito, out string mensaje)
        {
            if (nodo == null)
            {
                exito = true;
                mensaje = $"Producto {producto.Codigo} insertado correctamente.";
                return new NodoAVLBP(producto);
            }

            int comparacion = string.Compare(producto.Codigo, nodo.Producto.Codigo, StringComparison.OrdinalIgnoreCase);

            if (comparacion < 0)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, producto, ref exito, out mensaje);
            }
            else if (comparacion > 0)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, producto, ref exito, out mensaje);
            }
            else
            {
                exito = false;
                mensaje = $"Error: Ya existe un producto con el código {producto.Codigo}.";
                return nodo;
            }

            // Actualizamos la altura del nodo actual
            ActualizarAltura(nodo);

            // Verificamos el factor de balance para ver si hay que rotar
            int balance = ObtenerBalance(nodo);

            // Caso Izquierda - Izquierda
            if (balance > 1 && string.Compare(producto.Codigo, nodo.Izquierdo!.Producto.Codigo, StringComparison.OrdinalIgnoreCase) < 0)
            {
                return RotarDerecha(nodo);
            }

            // Caso Derecha - Derecha
            if (balance < -1 && string.Compare(producto.Codigo, nodo.Derecho!.Producto.Codigo, StringComparison.OrdinalIgnoreCase) > 0)
            {
                return RotarIzquierda(nodo);
            }

            // Caso Izquierda - Derecha
            if (balance > 1 && string.Compare(producto.Codigo, nodo.Izquierdo!.Producto.Codigo, StringComparison.OrdinalIgnoreCase) > 0)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo!);
                return RotarDerecha(nodo);
            }

            // Caso Derecha - Izquierda
            if (balance < -1 && string.Compare(producto.Codigo, nodo.Derecho!.Producto.Codigo, StringComparison.OrdinalIgnoreCase) < 0)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho!);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }

        // Metodo publico para buscar un producto por su codigo unico
        public ProductoBP? Buscar(string codigo)
        {
            return BuscarRecursivo(raiz, codigo);
        }

        private ProductoBP? BuscarRecursivo(NodoAVLBP? nodo, string codigo)
        {
            if (nodo == null) return null;

            int comparacion = string.Compare(codigo, nodo.Producto.Codigo, StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0) return nodo.Producto;
            if (comparacion < 0) return BuscarRecursivo(nodo.Izquierdo, codigo);
            return BuscarRecursivo(nodo.Derecho, codigo);
        }

        // Metodo publico para eliminar un producto del inventario
        public bool Eliminar(string codigo, out string mensaje)
        {
            bool eliminado = false;
            raiz = EliminarRecursivo(raiz, codigo, ref eliminado, out mensaje);
            return eliminado;
        }

        private NodoAVLBP? EliminarRecursivo(NodoAVLBP? nodo, string codigo, ref bool eliminado, out string mensaje)
        {
            if (nodo == null)
            {
                mensaje = $"Error: No existe un producto con el código {codigo}.";
                return null;
            }

            int comparacion = string.Compare(codigo, nodo.Producto.Codigo, StringComparison.OrdinalIgnoreCase);

            if (comparacion < 0)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, codigo, ref eliminado, out mensaje);
            }
            else if (comparacion > 0)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, codigo, ref eliminado, out mensaje);
            }
            else
            {
                eliminado = true;
                mensaje = $"Producto {codigo} eliminado correctamente.";

                // Nodo con un solo hijo o sin hijos
                if (nodo.Izquierdo == null) return nodo.Derecho;
                if (nodo.Derecho == null) return nodo.Izquierdo;

                // Nodo con dos hijos: obtenemos el sucesor in-orden (el menor de la derecha)
                NodoAVLBP sucesor = ObtenerMinimo(nodo.Derecho);
                nodo.Producto = sucesor.Producto;
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Producto.Codigo, ref boolDummy, out stringDummy);
            }

            if (nodo == null) return null;

            ActualizarAltura(nodo);
            int balance = ObtenerBalance(nodo);

            // Rebalanceo tras eliminacion
            if (balance > 1 && ObtenerBalance(nodo.Izquierdo) >= 0) return RotarDerecha(nodo);
            if (balance > 1 && ObtenerBalance(nodo.Izquierdo) < 0)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo!);
                return RotarDerecha(nodo);
            }
            if (balance < -1 && ObtenerBalance(nodo.Derecho) <= 0) return RotarIzquierda(nodo);
            if (balance < -1 && ObtenerBalance(nodo.Derecho) > 0)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho!);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }

        private bool boolDummy;
        private string stringDummy = "";

        private NodoAVLBP ObtenerMinimo(NodoAVLBP nodo)
        {
            NodoAVLBP actual = nodo;
            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }
            return actual;
        }

        // Recorrido In-Orden para mostrar el inventario ordenado ascendentemente
        public void MostrarInOrden()
        {
            if (raiz == null)
            {
                Console.WriteLine("\nEl inventario está vacío.");
                return;
            }

            Console.WriteLine("======================================================================");
            Console.WriteLine("                     INVENTARIO DEL SUPERMERCADO");
            Console.WriteLine("======================================================================");
            Console.WriteLine($"{"Código",-10} {"Nombre",-22} {"Categoría",-15} {"Precio",-10} {"Stock",-6}");
            Console.WriteLine("----------------------------------------------------------------------");

            InOrdenRecursivo(raiz);

            Console.WriteLine("----------------------------------------------------------------------");
        }

        private void InOrdenRecursivo(NodoAVLBP? nodo)
        {
            if (nodo != null)
            {
                InOrdenRecursivo(nodo.Izquierdo);
                Console.WriteLine($"{nodo.Producto.Codigo,-10} {nodo.Producto.Nombre,-22} {nodo.Producto.Categoria,-15} Q{nodo.Producto.Precio,-9:F2} {nodo.Producto.Stock,-6}");
                InOrdenRecursivo(nodo.Derecho);
            }
        }
    }
}