using System.Text;

namespace BuilderPattern;

public class Class
{
    public string Name { get; set; }
    public List<Field> Fields { get; set; } = new List<Field>();

    public Class()
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"public class {Name}")
            .AppendLine("{");
        foreach (Field field in Fields)
        {
            sb.AppendLine($"  {field};");
        }
        sb.AppendLine("}");
        return sb.ToString();
    }
    
}