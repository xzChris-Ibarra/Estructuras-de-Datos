public class ArregloGen<T> where T : IComparable<T>
{
    public T[] datos;
    public int contador;
    public ArregloGen(int capacidadInicial)
    {
        datos = new T[capacidadInicial];
        contador = 0;
    }
    public void Agregar(T elemento)
    {
        if (contador == datos.Length)
        {
            T[] datosNuevos = new T[datos.Length * 2];
            for (int i = 0; i < datos.Length; i++)
            {
                datosNuevos[i] = datos[i];
            }
            datos = datosNuevos;
        }
        datos[contador] = elemento;
        contador++;
    }
    public T Obtener(int indice)
    {
        if (indice < 0 && indice >= contador)
        {
            throw new IndexOutOfRangeException("Indice fuera de rango");
        }
        return datos[indice];
    }
    public void Eliminar(int indice)
    {
        if (indice >= 0 && indice < contador)
        {
            for (int i = indice; i < contador - 1; i++)
            {
                datos[i] = datos[i + 1];
            }
            datos[contador - 1] = default(T);
            contador--;
        }
        else Console.WriteLine("Indice fuera de rango");
    }
    public void Mostrar()
    {
        for (int i = 0; i < contador - 1; i++)
        {
            Console.Write(datos[i] + ", ");
        }
        if (contador > 0)
        {
            Console.WriteLine(datos[contador - 1]);
        }
        else
        {
            Console.WriteLine("Arreglo vacio");
        }
    }
    public void Ordenar()
    {
        //logica del bubble sort
        for (int i = 0; i < contador - 1; i++)
        {
            for (int j = 0; j < contador - i - 1; j++)
            {
                //si datos[j] es mayor que datos[j+1], intercambiarlos
                if (datos[j].CompareTo(datos[j + 1]) > 0)
                {
                    T temp = datos[j];
                    datos[j] = datos[j + 1];
                    datos[j + 1] = temp;
                }
            }
        }
    }
}