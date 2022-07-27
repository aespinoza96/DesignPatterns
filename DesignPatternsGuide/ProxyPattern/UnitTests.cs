using NUnit.Framework;

namespace ProxyPattern;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestProxyPattern()
    {
        var person = new Person { Age = 10 };
        var responsiblePerson = new ResponsiblePerson(person);

        Assert.That(responsiblePerson.Drive(), Is.EqualTo("too young"));
        Assert.That(responsiblePerson.Drink(), Is.EqualTo("too young"));
        Assert.That(responsiblePerson.DrinkAndDrive(), Is.EqualTo("dead"));

        responsiblePerson.Age = 20;

        Assert.That(responsiblePerson.Drive(), Is.EqualTo("driving"));
        Assert.That(responsiblePerson.Drink(), Is.EqualTo("drinking"));
        Assert.That(responsiblePerson.DrinkAndDrive(), Is.EqualTo("dead"));
    }
}