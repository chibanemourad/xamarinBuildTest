using NUnit.Framework;

namespace xamarin.nunit.test.UnitTests
{
    [TestFixture]
    public class SameAssemblySampleUnitTest
    {
        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(10, 10, ExpectedResult = 20)]
        [TestCase(12, 13, ExpectedResult = 24)] // Deliberate failure
        public int TestAddWithResult(int x, int y)
        {
            return x + y;
        }

        [TestCase(1, 1, 2)]
        [TestCase(10, 10, 20)]
        [TestCase(12, 13, 24)] // Deliberate failure
        public void TestAddWithExpected(int x, int y, int expected)
        {
            Assert.That(x + y, Is.EqualTo(expected));
        }
    }
}