
using NUnit.Framework;

namespace FactoryPattern.UnitTests;

[TestFixture]
public class UnitTests
{
    [Test]
    public void TestFactoryPattern()
    {
        PersonFactory factory = new PersonFactory();
        Person person = factory.Create("Micky Mouse");
        Person person2 = factory.Create("Guffy");
        Assert.That(person.Name, Is.EqualTo("Micky Mouse"));
        Assert.That(person.Id, Is.EqualTo(0));
        Assert.That(person2.Name, Is.EqualTo("Guffy"));
        Assert.That(person2.Id, Is.EqualTo(1));
    }
}