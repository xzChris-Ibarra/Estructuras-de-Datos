public class ColaClientes<T>
{
    public T[] clientes;
    public int frente;
    public int final;

    public ColaClientes(int capacidad)
    {
        clientes = new T[capacidad];
        frente = 0;
        final = 0;
    }

    public void Enqueue(T cliente)
    {
        if (final == clientes.Length)
        {
            Console.WriteLine("La fila esta llena");
            return;
        }
        clientes[final] = cliente;
        final++;
        Console.WriteLine($"{cliente} llego y se une a la fila.");
    }

    public T Dequeue()
    {
        if (frente == final)
        {
            Console.WriteLine("Fila vacia");
            return default(T);
        }
        T clienteAtendido = clientes[frente];
        frente++;
        Console.WriteLine($"{clienteAtendido} atendido y salio de la fila.");
        return clienteAtendido;
    }

    public T Peek()
    {
        if (frente == final)
        {
            Console.WriteLine("Fila vacia");
            return default(T);
        }
        return clientes[frente];
    }

    public void MostrarCola()
    {
        if (frente == final)
        {
            Console.WriteLine("Fila vacia");
            return;
        }
        for (int i = frente; i < final; i++)
        {
            Console.WriteLine(clientes[i] + " ");
        }
        Console.WriteLine();
    }
}