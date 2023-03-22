namespace Pong;

public struct Vector
{
    public int x;

    public int y;

    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector operator +(Vector left, Vector right) => new(left.x + right.x, left.y + right.y);

    public static bool operator ==(Vector left, Vector right) => left.Equals(right);

    public static bool operator !=(Vector left, Vector right) => !left.Equals(right);

    public override bool Equals(object? obj) => obj is Vector vector && x == vector.x && y == vector.y;

    public override int GetHashCode() => HashCode.Combine(x, y);

    public override string ToString() => $"({x,2}, {y,2})";
}
