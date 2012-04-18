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
        public void GetTasksTest()
        {
                var tm = new TestMaker();
            tm.OpenDocument(TestStatics.TestFilePath);
            tm.AddTasks();
            Assert.IsNotEmpty(tm.Tasks);
            tm.Document.CloseDocument(false);
        }

        [Test]
        public void WriteToXmlTest()
        {
            var tm = new TestMaker();
            tm.OpenDocument(TestStatics.TestFilePath);
            tm.AddTasks();
            tm.WriteToXML(TestStatics.TestXMLPath);
            tm.Document.CloseDocument(false);
        }

    }
}
