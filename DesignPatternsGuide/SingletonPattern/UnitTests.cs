using NUnit.Framework;

namespace SingletonPattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void Test()
    {
        var obj = new object();
        Assert.IsTrue(SingletonTester.IsSingleton(() => obj));
        Assert.IsFalse(SingletonTester.IsSingleton(() => new object()));
    }
}