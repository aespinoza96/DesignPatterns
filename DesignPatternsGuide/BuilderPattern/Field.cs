namespace BuilderPattern;

public class Field
{
    public string Name { get; set; }

    public string Type { get; set; }

    public override string ToString()
    {
        return $"public {Type} {Name}";
    }
}