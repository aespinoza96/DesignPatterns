using NUnit.Framework;

namespace FlyweightPattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestFlyweightPattern()
    {
        var s = new Sentence("alpha beta gamma");
        s[1].Capitalize = true;
        Assert.That(s.ToString(),
            Is.EqualTo("alpha BETA gamma"));
    }
}