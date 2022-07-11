using NUnit.Framework;

namespace PrototypePattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestProtoypePatter()
    {
        var line1 = new Line
        {
            A = new Point { X = 3, Y = 3},
            B = new Point { X = 10, Y = 10}
        };

        var line2 = line1.DeepCopy();
        line1.A.X = line1.B.X = line1.A.Y = line1.B.Y = 0;

        Assert.That(line2.A.X, Is.EqualTo(3));
        Assert.That(line2.A.Y, Is.EqualTo(3));
        Assert.That(line2.B.X, Is.EqualTo(10));
        Assert.That(line2.B.Y, Is.EqualTo(10));
    }
}