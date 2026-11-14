# 🛒 Sistema de Gestión de Supermercado - Don Juan Market

Aplicación de consola desarrollada en **C# (.NET)** para la gestión operativa de un supermercado. El sistema optimiza tanto el control de inventario como la atención de clientes en cajas mediante la implementación desde cero de estructuras de datos avanzadas.

---

## 📋 Características Principales

### 1. Control de Inventario (Árbol AVL)
* **Registro de productos:** Alta de artículos con validación de código único, precio y stock.
* **Búsqueda rápida:** Consulta inmediata de productos por código en tiempo logarítmico $O(\log n)$.
* **Actualización y baja:** Modificación de datos y eliminación de artículos manteniendo el árbol automáticamente balanceado.
* **Listado ordenado:** Visualización del inventario completo ordenado de forma ascendente mediante recorrido *In-Orden*.

### 2. Atención de Clientes en Cajas (Cola de Prioridad / Min-Heap)
* **Gestión por jerarquía:** Organización automática de la fila según el tipo de cliente:
  1. **VIP** (Máxima prioridad)
  2. **Adulto Mayor** (Prioridad intermedia)
  3. **Regular** (Prioridad estándar)
* **Criterio FIFO:** En caso de empate en el nivel de prioridad, se respeta estrictamente el orden de llegada.
* **Atención en tiempo real:** Extracción del siguiente cliente con mayor prioridad y visualización dinámica de la fila de espera.

### 3. Interfaz en Consola
* Menú interactivo dividido por módulos con código de colores.
* Validación de entradas para prevenir errores de ejecución.
* Transiciones animadas y retroalimentación visual en cada operación.

---

## 🏗️ Arquitectura del Proyecto

El código sigue una arquitectura modular orientada a objetos:

* `Program.cs`: Interfaz de usuario, menú principal y validaciones de entrada.
* `SupermercadoBP.cs`: Clase integradora que coordina el inventario y la cola de atención.
* `ArbolAVLBP.cs` / `NodoAVLBP.cs`: Implementación del Árbol Binario de Búsqueda Autobalanceable (rotaciones simples y dobles) para el catálogo.
* `ColaPrioridadBP.cs`: Implementación de *Min-Heap* con operaciones *Bubble Up* y *Bubble Down*.
* `ProductoBP.cs` / `ClienteBP.cs`: Modelos de entidad del dominio.

---

## 🚀 Requisitos y Ejecución

### Requisitos previos
* [.NET SDK 9.0](https://dotnet.microsoft.com/download) o superior.

### Instrucciones para ejecutar
1. Clona este repositorio en tu equipo:
   ```bash
   git clone https://github.com/BParedes04/ProyectoFinal_BryanParedes.git
   ```
2. Ingresa a la carpeta del proyecto:
   ```bash
   cd ProyectoFinal_BryanParedes
   ```
3. Compila y ejecuta la aplicación:
   ```bash
   dotnet run
   ```

---

## 👨‍💻 Autor
* **Bryan Alexander Paredes Benegas** - *Desarrollo e implementación*
* **Repositorio:** [https://github.com/BParedes04/ProyectoFinal_BryanParedes](https://github.com/BParedes04/ProyectoFinal_BryanParedes)