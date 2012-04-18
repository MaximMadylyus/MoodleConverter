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
            tm.OpenDocument(TestStatics.TestFilePath);
            Assert.IsNotNull(tm.Document);
            tm.Document.CloseDocument(false);
        }

        [Test]
        public void FindTestBeginTest()
        {
            var tm = new TestMaker();
            tm.OpenDocument(TestStatics.TestFilePath);
            Assert.IsTrue(tm.FindTestBegin());
            tm.Document.CloseDocument(false);
            Assert.AreEqual(1,tm.TestCount);
        }

        [Test]
        public void IsAnsverBeginTest()
        {
            var tm = new TestMaker();
            tm.OpenDocument(TestStatics.TestFilePath);
            tm.FindTestBegin();
            Assert.IsFalse(tm.IsAnsverBegin());
            tm.Document.MoveCursor(1,0);
            Assert.IsTrue(tm.IsAnsverBegin());
            tm.Document.CloseDocument(false);
        }

        [Test]
        public void GetAnsverText()
        {
            var tm = new TestMaker();
            tm.OpenDocument(TestStatics.TestFilePath);
            tm.FindTestBegin();
            tm.Document.MoveCursor(1, 2);
            Assert.IsNotNullOrEmpty(tm.GetAnsverText());
            tm.Document.CloseDocument(false);
        }

        [Test]
        public void GetTasksTest()
        {
            var tm = new TestMaker();
            tm.OpenDocument(TestStatics.TestFilePath);
            tm.AddTasks();
            Assert.IsNotEmpty(tm.Tasks);
            tm.Document.CloseDocument(false);
        }

    }
}
