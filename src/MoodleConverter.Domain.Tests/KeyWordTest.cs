using NUnit.Framework;

namespace MoodleConverter.Domain.Tests
{
    [TestFixture]
    public class KeyWordTest
    {
        [Test]
        public void IsTaskStartKeyWord()
        {
            Assert.IsTrue(KeyWord.IsTaskStart("\r" ,"1", ".."));
            Assert.IsFalse(KeyWord.IsTaskStart(".", "З;lghns;g", ")"));
        }

        [Test]
        public void IsAnsversStartKeyWord()
        {
            Assert.IsTrue(KeyWord.IsAnswerStart(".", "A", ")"));
            Assert.IsFalse(KeyWord.IsAnswerStart(".", "Завдання", ")"));
        }
    }
}
