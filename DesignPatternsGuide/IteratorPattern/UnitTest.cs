using NUnit.Framework;

namespace IteratorPattern;

[TestFixture]
public class UnitTest
{
    [Test]
    public void TestPattern()
    {
        var node = new Node<char>('a',
            new Node<char>('b',
                new Node<char>('c'),
                new Node<char>('d')),
            new Node<char>('e'));
        Assert.That(new string(node.PreOrder.ToArray()), Is.EqualTo("abcde"));
    }
}