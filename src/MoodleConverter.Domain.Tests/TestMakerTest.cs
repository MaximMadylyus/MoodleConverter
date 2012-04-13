using NUnit.Framework;

namespace MoodleConverter.Domain.Tests
{
    [TestFixture]
    class TestMakerTest
    {
        [Test]
        public void OpenDocumentTest()
        {
            var tm = new TestMaker();
            tm.OpenDocument("");
            Assert.IsNull(tm.Document);
        }

    }
}
