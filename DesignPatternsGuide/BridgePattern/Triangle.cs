namespace BridgePattern;

public class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer)
    {
        Name = "Triangle";
    }
}