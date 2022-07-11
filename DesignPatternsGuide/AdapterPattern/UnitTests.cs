using NUnit.Framework;

namespace AdapterPattern;

public class UnitTests
{
    [TestFixture]
    public class TestSuite
    {
        [Test]
        public void TestAdapterPattern()
        {
            var square = new Square() { Side = 10 };
            const int area = 10 * 10;
            var adapter = new SquareToRectangleAdapter(square);
            Assert.That(adapter.Area(), Is.EqualTo(area));
        }
    }
}