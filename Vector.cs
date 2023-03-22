namespace Pong;

public struct Vector
{
    public static Vector Left => new(-1, 0);

    public static Vector Right => new(1, 0);

    public static Vector Up => new(0, -1);

    public static Vector Down => new(0, 1);

    public int x;

    public int y;

    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj) => obj is Vector vector && x == vector.x && y == vector.y;

    public override int GetHashCode() => HashCode.Combine(x, y);

    public override string ToString() => $"({x,2}, {y,2})";

    public static Vector operator +(Vector left, Vector right) => new(left.x + right.x, left.y + right.y);

    public static bool operator ==(Vector left, Vector right) => left.Equals(right);

    public static bool operator !=(Vector left, Vector right) => !left.Equals(right);
}
