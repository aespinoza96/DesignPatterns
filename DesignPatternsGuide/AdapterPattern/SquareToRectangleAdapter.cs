namespace AdapterPattern;

public class SquareToRectangleAdapter : IRectangle
{
    public int Width { get; }
    public int Height { get; }

    public SquareToRectangleAdapter(Square square)
    {
        this.Height = square.Side;
        this.Width = this.Height;
    }
}