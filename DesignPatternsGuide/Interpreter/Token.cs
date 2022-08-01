namespace Interpreter;

public class Token
{
    private Type _myType;
    private string _text;
    
    public Token(Type myType, string text)
    {
        _myType = myType;
        _text = text;
    }
    public enum Type {
        Integer, Plus, Minus, LeftParenthesis, RightParenthesis
    }

    public Type MyType
    {
        get { return _myType; }
        set { _myType = value; }
    }
    
    public string Text
    {
        get { return _text; }
    }

}