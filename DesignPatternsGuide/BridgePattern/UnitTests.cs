using NUnit.Framework;

namespace BridgePattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestBridgePattern()
    {
        Assert.That(
            new Square(new VectorRenderer()).ToString(),
            Is.EqualTo("Drawing a Square as lines."));
    }
}