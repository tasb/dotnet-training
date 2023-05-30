
namespace Interfaces.Greatings;

public interface IHello
{
    string SayHello();
}

public class HelloWorldGreater : IHello
{
    public string SayHello() => "Hello, World!";
}

public class CustomGreater : IHello
{
    public string GreatingWord { get; set; }
    public CustomGreater(string word) => GreatingWord = word;

    public string SayHello() => $"Hello, {GreatingWord}";
}

public struct Coords
{
    public int X { get; init; }
    public int Y { get; init; }

    public Coords(int x, int y) => (X, Y) = (x, y);

    public override string ToString() => $"({X}, {Y})";

    public static Coords operator +(Coords c1, Coords c2)
        => new Coords(c1.X + c2.X, c1.Y + c2.Y);
}

