using NUnit.Framework;

namespace DecoratorPattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestDecoratorPattern()
    {
        var dragon = new Dragon();

        Assert.That(dragon.Fly(), Is.EqualTo("flying"));
        Assert.That(dragon.Crawl(), Is.EqualTo("too young"));

        dragon.Age = 20;

        Assert.That(dragon.Fly(), Is.EqualTo("too old"));
        Assert.That(dragon.Crawl(), Is.EqualTo("crawling"));
    }
}