using NUnit.Framework;

namespace NullObject;

[TestFixture]
public class UnitTest
{
    [Test] 
    public void SingleCallTest()
    {
        var a = new Program.Account(new Program.NullLog());
        a.SomeOperation();
    }
  
    [Test]
    public void ManyCallsTest()
    {
        var a = new Program.Account(new Program.NullLog());
        for (int i = 0; i < 100; ++i)
            a.SomeOperation();
    }
}