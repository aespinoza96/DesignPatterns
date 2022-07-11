namespace PrototypePattern;

public class Point
{
    public int X { get; set; }
    
    public int Y { get; set; }

    public Point DeppCopy()
    {
        return new Point() { X = X, Y = Y };
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }
}