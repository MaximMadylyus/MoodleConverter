using NUnit.Framework;

namespace MoodleConverter.Domain.Tests
{
    [TestFixture]
    public class AnsverTest
    {
        [Test]
        public void InitializationTest()
        {
            var ans = new Ansver();
            Assert.False(ans.IsCorrect);
            Assert.AreEqual(string.Empty, ans.AnsverText);
        }
    }
}
