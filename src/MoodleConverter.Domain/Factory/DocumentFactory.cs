using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleConverter.Domain
{
    public class DocumentFactory
    {
        public static IDocument GetDocumentInstance(string path)
        {
            IDocument concreteWorker = null;

            if (path.EndsWith(".docx", StringComparison.InvariantCultureIgnoreCase))
            {
                concreteWorker = new DocxWorker();
            }

            if (path.EndsWith(".doc"))
            {
                concreteWorker = new DocxWorker();
            }

            if (path.EndsWith(".pdf"))
            {
                concreteWorker = new PdfWorker();
            }

            if (path.EndsWith(".djvu"))
            {
                concreteWorker = new DjvuWorker();
            }

            return concreteWorker;
        }
    }
}
