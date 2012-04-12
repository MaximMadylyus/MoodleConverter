using NUnit.Framework;

namespace MoodleConverter.Domain.Tests
{
    [TestFixture]
    class InitialTextTest
    {
        [Test]
        public void OpenDocumentGetsTextFromDocument()
        {
            var initialText = new InitialText();
            initialText.OpenDocument(TestStatics.TestFilePath);
            Assert.IsNotNull(initialText.CurrentDoc);
        }

        [Test]
        public void CloseDocumentCheckIfclosed()
        {
            var initialText = new InitialText();
            initialText.OpenDocument(TestStatics.TestFilePath);
            initialText.CloseDocument(false);
            Assert.IsNull(initialText.CurrentDoc);
        }

        [Test]
        public void GetTextFromPositionTest()
        {
            var initialText = new InitialText();
            initialText.OpenDocument(TestStatics.TestFilePath);
            Assert.IsNotNullOrEmpty(initialText.GetTextFromPosition(TextBlockType.word,1));
            Assert.IsNotNullOrEmpty(initialText.GetTextFromPosition(TextBlockType.paragraph, 1));
            Assert.IsNotNullOrEmpty(initialText.GetTextFromPosition(TextBlockType.line, 1));
            initialText.CloseDocument(false);
        }

        [Test]
        public void IsTextMarkedTest ()
        {
            var initialText = new InitialText();
            initialText.OpenDocument(TestStatics.TestFilePath);
            Assert.IsTrue(initialText.IsTextMarked(TextBlockType.paragraph, 1));
            Assert.IsTrue(initialText.IsTextMarked(TextBlockType.word, 1));
            Assert.IsTrue(initialText.IsTextMarked(TextBlockType.line, 1));
            initialText.CloseDocument(false);
        }

        [Test]
        public void GetParagraphTextTest()
        {
            var initialText = new InitialText();
            initialText.OpenDocument(TestStatics.TestFilePath);
            Assert.IsNotNullOrEmpty(initialText.GetParagraphText(2));
            initialText.CloseDocument(false);
        }

    }
}
