using NUnit.Framework;

namespace CompositePattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestCompositePatter()
    {
        var singleValue = new SingleValue {Value = 11};
        var otherValues = new ManyValues
        {
            22,
            33
        };
        Assert.That(new List<IValueContainer>{singleValue, otherValues}.Sum(),
            Is.EqualTo(66));
    }
    
}