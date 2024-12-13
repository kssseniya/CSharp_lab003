struct Vector
{
    private double x, y, z;
    public Vector(double x, double y, double z)
    {
        (this.x, this.y, this.z) = (x, y, z);
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }
    
    public static Vector operator *(Vector v1, Vector v2)
    {
        return new Vector( v1.y * v2.z - v1.z * v2.y,
                           v1.z * v2.x - v1.x * v2.z,
                           v1.x * v2.y - v1.y * v2.x );
    }
    
    public static Vector operator *(Vector v, double num)
    {
        return new Vector(v.x * num, v.y * num, v.z * num);
    }

    public static Vector operator *(double num, Vector v) { return v * num; }

    public double Length()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }
    
    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.Length() > v2.Length();
    }
    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.Length() < v2.Length();
    }
    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.Length() == v2.Length();
    }
    public static bool operator !=(Vector v1, Vector v2)
    {
        return v1.Length() != v2.Length();
    }
    public override string ToString()
    {
        return $"Vector({x}, {y}, {z})";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);
        Console.WriteLine($"v1: {v1}");
        Console.WriteLine($"v2: {v2}");
        Console.WriteLine($"Сложение двух векторов: {v1 + v2}");
        Console.WriteLine($"Произведение векторов: {v1 * v2}");
        Console.WriteLine($"Умножение вектора v1 на число (на 2): {v1 * 2}");
        Console.WriteLine($"v1 > v2: {v1 > v2}");
        Console.WriteLine($"v1 < v2: {v1 < v2}");
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");
    }
}