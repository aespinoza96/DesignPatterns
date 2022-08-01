namespace Interpreter;

public class BinaryOperation: IElement
{
    public enum Type
    {
        Addition,
        Substraction
    }

    public Type MyType { get; set; }
    public IElement Left { get; set; }
    public IElement Right { get; set; }

    public int Value
    {
        get
        {
            if (MyType == Type.Addition)
            {
                return Left.Value + Right.Value;
            }
            else if (MyType == Type.Substraction)
            {
                return Left.Value - Right.Value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}