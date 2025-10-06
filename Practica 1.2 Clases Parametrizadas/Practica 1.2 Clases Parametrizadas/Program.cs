class Program
{
    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Menu: Practica 1.2 Clases Parametrizadas ---");
            Console.WriteLine("1. Demostración con números enteros");
            Console.WriteLine("2. Demostración con cadenas de texto");
            Console.WriteLine("3. Demostración con objetos Alumno");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción (1-4): ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    DemostracionEnteros();
                    break;
                case "2":
                    DemostracionCadenas();
                    break;
                case "3":
                    DemostracionAlumnos();
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo..");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
    static void DemostracionEnteros()
    {
        Console.WriteLine("\n--- Demostración con Enteros ---");
        ArregloGen<int> numeros = new ArregloGen<int>(3);
        numeros.Agregar(22);
        numeros.Agregar(12);
        numeros.Agregar(32);

        Console.WriteLine("Antes de ordenar:");
        numeros.Mostrar();

        numeros.Ordenar();

        Console.WriteLine("Después de ordenar:");
        numeros.Mostrar();
    }

    static void DemostracionCadenas()
    {
        Console.WriteLine("\n--- Demostración con Cadenas ---");
        ArregloGen<string> palabras = new ArregloGen<string>(3);
        palabras.Agregar("Manzana con chile");
        palabras.Agregar("Pera");
        palabras.Agregar("Melón");

        Console.WriteLine("Antes de ordenar:");
        palabras.Mostrar();

        palabras.Ordenar();

        Console.WriteLine("Después de ordenar:");
        palabras.Mostrar();
    }
    static void DemostracionAlumnos()
    {
        Console.WriteLine("\n--- Demostración con Alumnos por Promedio descendente ---");
        ArregloGen<Alumno> alumnos = new ArregloGen<Alumno>(3);
        alumnos.Agregar(new Alumno { Nombre = "Chris", Promedio = 85 });
        alumnos.Agregar(new Alumno { Nombre = "Aarón", Promedio = 95 });
        alumnos.Agregar(new Alumno { Nombre = "Bee", Promedio = 100 });

        Console.WriteLine("Contenido inicial:");
        alumnos.Mostrar();

        alumnos.Ordenar();
        Console.WriteLine("Después de ordenar:");
        alumnos.Mostrar();
    }
}