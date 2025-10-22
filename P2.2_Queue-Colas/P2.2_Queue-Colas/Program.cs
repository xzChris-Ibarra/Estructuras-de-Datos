class Program
{
    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Simulación de Fila Atención al Cliente - Cola Simple ---");
            Console.WriteLine("1. Simular con Cola Simple manual");
            Console.WriteLine("2. Simular con Queue<T> de C#");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    SimulacionSimple();
                    break;
                case "2":
                    SimulacionQueue();
                    break;
                case "3":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void SimulacionSimple()
    {
        Console.WriteLine("\n--- Simulación Cola Simple ---");

        ColaClientes<string> fila = new ColaClientes<string>(4);

        fila.Enqueue("Chris");
        fila.Enqueue("Alex");
        fila.Enqueue("Aarón");
        fila.MostrarCola();

        Console.WriteLine("\nAtendiendo a dos clientes..");
        fila.Dequeue();
        fila.Dequeue();
        fila.MostrarCola();

        Console.WriteLine("\nLlegan más clientes..");
        fila.Enqueue("Mariana");
        fila.Enqueue("Angelina");
        fila.MostrarCola();

        Console.WriteLine("\nIntentando agregar un cliente más a la fila (llena)..");
        fila.Enqueue("Emma");
        fila.MostrarCola();
    }

    static void SimulacionQueue()
    {
        Console.WriteLine("\n--- Simulación con Queue<T> ---");
        Queue<string> filaNativa = new Queue<string>();

        filaNativa.Enqueue("Ana");
        Console.WriteLine("Ana ha llegado y se une a la fila.");
        filaNativa.Enqueue("Luis");
        Console.WriteLine("Luis ha llegado y se une a la fila.");
        filaNativa.Enqueue("María");
        Console.WriteLine("María ha llegado y se une a la fila.");

        Console.WriteLine($"Clientes en fila: {string.Join(", ", filaNativa)}");

        Console.WriteLine($"Siguiente en ser atendido: {filaNativa.Peek()}");

        string atendido = filaNativa.Dequeue();
        Console.WriteLine($"{atendido} ha sido atendido.");
        Console.WriteLine($"Clientes en fila: {string.Join(", ", filaNativa)}");

        filaNativa.Enqueue("Pedro");
        Console.WriteLine("Pedro ha llegado y se une a la fila.");
        Console.WriteLine($"Clientes en fila: {string.Join(", ", filaNativa)}");
    }
}