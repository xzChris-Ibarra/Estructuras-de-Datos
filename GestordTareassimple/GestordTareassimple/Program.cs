// --------- DEFINICIÓN DE TIPOS DE DATOS ---------
// Usamos un 'namespace' para organizar nuestro código.
namespace GestorDeTareasSimple
{
    // -----------------------------------------------------------------------------
    // 1. ENUM (Tipo por Valor)
    // Se usa para definir un conjunto de constantes con nombre. Es ideal para
    // categorías o estados, ya que hace el código más legible y evita errores
    // al limitar las opciones posibles.
    // -----------------------------------------------------------------------------
    public enum EstadoTarea
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    // -----------------------------------------------------------------------------
    // 2. STRUCT (Tipo por Valor)
    // Se usa para encapsular pequeños grupos de variables relacionadas, como un
    // punto de coordenadas, un número complejo o, en este caso, una prioridad.
    // Son eficientes para datos pequeños que no necesitan las características
    // de una clase completa.
    // -----------------------------------------------------------------------------
    public struct Prioridad
    {
        // byte: Un entero sin signo de 8 bits (0-255). Eficiente para
        // valores pequeños como un nivel de prioridad.
        public byte Nivel; // 1 = Baja, 5 = Media, 10 = Alta

        public Prioridad(byte nivel)
        {
            Nivel = nivel;
        }
    }

    // -----------------------------------------------------------------------------
    // 3. CLASS (Tipo por Referencia)
    // Es la estructura fundamental para crear objetos en C#. Se usa para modelar
    // entidades complejas que tienen datos (atributos) y comportamiento (métodos).
    // Una "Tarea" es un objeto complejo, por lo que una clase es la elección correcta.
    // -----------------------------------------------------------------------------
    public class Tarea
    {
        // string: Tipo por referencia ideal para texto de longitud variable.
        public string Descripcion { get; set; }

        // EstadoTarea (enum): Usamos nuestro enum para asegurar que el estado
        // sea siempre uno de los valores válidos (Pendiente, EnProgreso, Completada).
        public EstadoTarea Estado { get; set; }

        // Prioridad (struct): Usamos nuestra estructura para representar la prioridad.
        public Prioridad Prioridad { get; set; }

        // DateTime? (Nullable<T>): Un tipo de valor anulable. El '?' permite que
        // una tarea pueda NO tener una fecha límite (su valor sería null).
        // Esencial para datos opcionales.
        public DateTime? FechaLimite { get; set; }

        // bool: Tipo de valor para representar estados binarios (verdadero/falso).
        // Perfecto para indicar si una tarea es importante o no.
        public bool EsImportante { get; set; }
    }


    // --------- PROGRAMA PRINCIPAL ---------
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Gestor de Tareas Súper Simple ---");

            // -----------------------------------------------------------------------------
            // 4. List<T> y var (Tipo por Referencia y Inferencia de Tipos)
            //
            // List<Tarea>: Una colección genérica para almacenar nuestros objetos Tarea.
            // Es dinámica, por lo que podemos agregar o quitar tareas fácilmente.
            //
            // var: Le decimos al compilador que "infiera" el tipo de la variable a
            // partir de la derecha de la asignación. Es útil para no escribir tipos
            // largos como 'List<Tarea>' dos veces. El código sigue siendo fuertemente
            // tipado.
            // -----------------------------------------------------------------------------
            var tareas = new List<Tarea>();

            // Creamos dos tareas de ejemplo para que la lista no esté vacía.
            tareas.Add(new Tarea
            {
                Descripcion = "Estudiar Tipos de Datos Abstractos",
                Prioridad = new Prioridad(10),
                Estado = EstadoTarea.EnProgreso,
                FechaLimite = new DateTime(2025, 9, 30),
                EsImportante = true
            });
            tareas.Add(new Tarea
            {
                Descripcion = "Jugar baloncesto",
                Prioridad = new Prioridad(5),
                Estado = EstadoTarea.Pendiente,
                FechaLimite = null, // Esta tarea no tiene fecha límite
                EsImportante = false
            });


            while (true)
            {
                Console.WriteLine("\n¿Qué deseas hacer?");
                Console.WriteLine("1. Agregar una nueva tarea");
                Console.WriteLine("2. Ver todas las tareas");
                Console.WriteLine("3. Salir");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarTarea(tareas);
                        break;
                    case "2":
                        VerTareas(tareas);
                        break;
                    case "3":
                        Console.WriteLine("¡Adiós!");
                        return; // Termina el programa
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }

        public static void AgregarTarea(List<Tarea> tareas)
        {
            Console.WriteLine("\n--- Agregar Nueva Tarea ---");
            var nuevaTarea = new Tarea();

            Console.Write("Descripción de la tarea: ");
            // string: Leemos directamente el texto del usuario.
            nuevaTarea.Descripcion = Console.ReadLine();

            Console.Write("Prioridad (1-10): ");
            // byte.TryParse: Intenta convertir el texto a un 'byte'.
            // Es una forma segura de manejar la entrada del usuario sin que el programa
            // se bloquee si escribe algo que no es un número.
            byte.TryParse(Console.ReadLine(), out byte nivelPrioridad);
            nuevaTarea.Prioridad = new Prioridad(nivelPrioridad);

            nuevaTarea.Estado = EstadoTarea.Pendiente; // Toda tarea nueva empieza como pendiente.
            nuevaTarea.EsImportante = false; // Por defecto no es importante.

            Console.WriteLine("Tarea agregada con éxito.");
            tareas.Add(nuevaTarea);
        }

        public static void VerTareas(List<Tarea> tareas)
        {
            Console.WriteLine("\n--- Lista de Tareas ---");
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas para mostrar.");
                return;
            }

            // Usamos un ciclo 'foreach' para recorrer cada elemento de la lista.
            foreach (var tarea in tareas)
            {
                // Para la fecha límite, comprobamos si tiene un valor antes de mostrarla.
                // Si es 'null', mostramos "N/A". Este es el manejo típico de un tipo anulable.
                string fecha = tarea.FechaLimite.HasValue ? tarea.FechaLimite.Value.ToShortDateString() : "N/A";

                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Descripción: {tarea.Descripcion}");
                Console.WriteLine($"Estado: {tarea.Estado}"); // El enum se convierte a texto automáticamente
                Console.WriteLine($"Prioridad: {tarea.Prioridad.Nivel}");
                Console.WriteLine($"Fecha Límite: {fecha}");
            }
            Console.WriteLine("---------------------------------");
        }
    }
}