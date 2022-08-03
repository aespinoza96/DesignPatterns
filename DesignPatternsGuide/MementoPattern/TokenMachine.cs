namespace MementoPattern;

public class TokenMachine
{
    public List<Token> Tokens = new List<Token>();

    public Memento AddToken(int value)
    {
        return AddToken((new Token(value)));
    }

    public Memento AddToken(Token token)
    {
        Tokens.Add(token);
        var memento = new Memento
        {
            Tokens = Tokens.Select(x => new Token(x.Value)).ToList()
        };
        return memento;
    }

    public void Revert(Memento m)
    {
        Tokens = m.Tokens.Select(memento => new Token(memento.Value)).ToList();
    }
}