namespace BuilderPattern;

public class CodeBuilder
{
    private readonly Class _theClass = new Class();

    public CodeBuilder(string rootName)
    {
        _theClass.Name = rootName;
    }
    
    public CodeBuilder AddField(string name, string type)
    {
        _theClass.Fields.Add(new Field {Name = name, Type = type});
        return this;
    }

    public override string ToString()
    {
        return _theClass.ToString();
    }
}