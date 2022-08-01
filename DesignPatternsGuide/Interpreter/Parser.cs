namespace Interpreter;

public class Parser
{
    private List<Token> _tokens;
    private List<BinaryOperation> _binariesOps = new List<BinaryOperation>();
    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
    }
    public IElement Parse()
    {
        BinaryOperation binaryOperation = new BinaryOperation
        {
            Left = new Integer(0),
            Right = new Integer(0),
            MyType = BinaryOperation.Type.Addition
        };
        bool haveLHS = false;
        for (int i = 0; i < _tokens.Count; i++)
        {
            Token token = _tokens[i];
            switch (token.MyType)
            {
                case Token.Type.Integer:
                    Integer integer = new Integer(int.Parse(token.Text));
                    if (!haveLHS)
                    {
                        binaryOperation.Left = integer;
                        haveLHS = true;
                    }
                    else
                    {
                        binaryOperation.Right = integer;
                        if (i + 1 < _tokens.Count)
                        binaryOperation.Left = new Integer(binaryOperation.Value);
                    }
                    break;
                case Token.Type.Plus:
                    binaryOperation.MyType = BinaryOperation.Type.Addition;
                    break;
                case Token.Type.Minus:
                    binaryOperation.MyType = BinaryOperation.Type.Substraction;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return binaryOperation;
    }
}