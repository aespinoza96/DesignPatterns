using NUnit.Framework;

namespace Interpreter;

[TestFixture]
public class UnitTest
{
    [Test]
    public void TestPattern()
    {
        var lexer = new Lexer("1");
        lexer.Lex();
        var parser = new Parser(lexer.Tokens);
        var result = parser.Parse();
        Assert.That(result.Value, Is.EqualTo(1));
        
        lexer = new Lexer("1+2");
        lexer.Lex();
        parser = new Parser(lexer.Tokens);
        result = parser.Parse();
        Assert.That(result.Value, Is.EqualTo(3));

        lexer = new Lexer("1+x");
        lexer.Variables.Add('x', 5);
        lexer.Lex();
        parser = new Parser(lexer.Tokens);
        result = parser.Parse();
        Assert.That(result.Value, Is.EqualTo(6));

        lexer = new Lexer("1+xy");
        lexer.Variables.Add('x', 5);
        lexer.Lex();
        parser = new Parser(lexer.Tokens);
        result = parser.Parse();
        Assert.That(result.Value, Is.EqualTo(0));
    }
}