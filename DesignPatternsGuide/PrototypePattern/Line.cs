namespace PrototypePattern;

public class Line
{
    public Point A { get; set; }
    public Point B { get; set; }

    public Line DeepCopy()
    {
        return new Line() { A = A.DeppCopy(), B = B.DeppCopy() };
    }

    public override string ToString()
    {
        return $"Point A: {A.ToString()}, Point B: {B.ToString()} {Environment.NewLine}";
    }
}