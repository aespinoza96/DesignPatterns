using System.Text;

namespace Interpreter;

public class Lexer
{
    private readonly string _expression;
    
    public Lexer(string expression)
    {
        _expression = expression;
        Variables = new Dictionary<char, int>();
        Tokens = new List<Token>();
    }

    public Dictionary<char, int> Variables { get; set; }

    public IList<string> errors = new List<string>();
    public List<Token> Tokens { get; }

    public void Lex()
    {
        for (int i = 0; i < _expression.Length; i++)
        {
            switch (_expression[i])
            {
                case '+':
                    Tokens.Add(new Token(Token.Type.Plus, "+"));
                    break;
                case '-':
                    Tokens.Add(new Token(Token.Type.Minus, "-"));
                    break;   
                case '(':
                    Tokens.Add(new Token(Token.Type.LeftParenthesis, "("));
                    break; 
                case ')':
                    Tokens.Add(new Token(Token.Type.RightParenthesis, ")"));
                    break;
                default:
                    string element = $"";
                    if (Variables.ContainsKey(_expression[i]))
                    {
                        if ((i + 1) <_expression.Length && !char.IsDigit(_expression[i + 1]))
                        {
                             errors.Add("Two letters together");
                             Tokens.Clear();
                             return;
                        }
                        element += $"{Variables[_expression[i]]}";
                        Tokens.Add(new Token(Token.Type.Integer, element));
                        break;
                    }

                    element = $"{_expression[i]}";
                    for (int j = i + 1; j < _expression.Length; j++)
                    {
                        if (char.IsDigit(_expression[j]))
                        {
                            element += $"{_expression[j]}";
                            ++i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Tokens.Add(new Token(Token.Type.Integer, element));
                    break;
            }
        }
    }
}