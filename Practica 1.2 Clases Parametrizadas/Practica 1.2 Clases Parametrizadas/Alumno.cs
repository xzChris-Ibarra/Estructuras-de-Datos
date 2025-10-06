public class Alumno : IComparable<Alumno>
{
    public string Nombre { get; set; }
    public int Promedio { get; set; }
    public int CompareTo(Alumno otro)
    {
        if (otro == null) return 1; //mayor a menor
        return otro.Promedio.CompareTo(this.Promedio);
    }
    public override string ToString()
    {
        return $"({Nombre} - {Promedio})";
    }
}