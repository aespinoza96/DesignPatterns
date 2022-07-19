using System.Text;
using NUnit.Framework;

namespace FacadePattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestFacadePattern()
    {
        var gen = new MagicSquareGenerator();
        var square = gen.Generate(3);

        Console.WriteLine(SquareToString(square));

        var v = new Verifier(); // prevents cheating :)
        Assert.IsTrue(v.Verify(square),
            "Verification failed: this is not a magic square");
    }
    
    private string SquareToString(List<List<int>> square)
    {
        var sb = new StringBuilder();
        foreach (var row in square)
        {
            sb.AppendLine(string.Join(" ",
                row.Select(x => x.ToString())));
        }

        return sb.ToString();
    }
}