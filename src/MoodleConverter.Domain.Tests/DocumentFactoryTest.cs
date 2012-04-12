using NUnit.Framework;

namespace MoodleConverter.Domain.Tests
{
    [TestFixture]
    class DocumentFactoryTest
    {
       [Test]
        public void GetDocumentInstanceTest()
       {
           Assert.IsInstanceOf<DocxWorker>(DocumentFactory.GetDocumentInstance("qqq.docx"));
           Assert.IsInstanceOf<DocxWorker>(DocumentFactory.GetDocumentInstance("qqq.doc"));
           Assert.IsInstanceOf<PdfWorker>(DocumentFactory.GetDocumentInstance("qqq.pdf"));
           Assert.IsInstanceOf<DjvuWorker>(DocumentFactory.GetDocumentInstance("qqq.djvu"));
           Assert.IsNull(DocumentFactory.GetDocumentInstance("qqq.TXT"));
       }
    }
}
