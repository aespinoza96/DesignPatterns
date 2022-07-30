using NUnit.Framework;

namespace ChainOfResponsabilityPattern;

[TestFixture]
public class UnitTest
{
    [Test]
    public void TestPattern()
    {
        var game = new Game();
        var goblin = new Goblin(game);
        game.Creatures.Add(goblin);

        Assert.That(goblin.Attack, Is.EqualTo(1));
        Assert.That(goblin.Defense, Is.EqualTo(1));

        var goblin2 = new Goblin(game);
        game.Creatures.Add(goblin2);

        Assert.That(goblin.Attack, Is.EqualTo(1));
        Assert.That(goblin.Defense, Is.EqualTo(2));

        var goblin3 = new GoblinKing(game);
        game.Creatures.Add(goblin3);

        Assert.That(goblin.Attack, Is.EqualTo(2));
        Assert.That(goblin.Defense, Is.EqualTo(3));
    }
}