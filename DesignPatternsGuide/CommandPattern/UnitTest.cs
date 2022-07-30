using NUnit.Framework;

namespace CommandPattern;

[TestFixture]
public class UnitTest
{
    [Test]
    public void TestPattern()
    {
        var a = new Account();

        var command = new Command{Amount = 100, TheAction = Command.Action.Deposit};
        a.Process(command);

        Assert.That(a.Balance, Is.EqualTo(100));
        Assert.IsTrue(command.Success);

        command = new Command{Amount = 50, TheAction = Command.Action.Withdraw};
        a.Process(command);

        Assert.That(a.Balance, Is.EqualTo(50));
        Assert.IsTrue(command.Success);

        command = new Command { Amount = 150, TheAction = Command.Action.Withdraw };
        a.Process(command);

        Assert.That(a.Balance, Is.EqualTo(50));
        Assert.IsFalse(command.Success);
    }
}