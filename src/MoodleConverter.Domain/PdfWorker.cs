using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleConverter.Domain
{
    public class PdfWorker : IDocument
    {
        public void OpenDocument(string path)
        {
            throw new NotImplementedException();
        }

        public void CloseDocument(bool doSave)
        {
            throw new NotImplementedException();
        }

        public string GetTextFromPosition(TextBlockType textBlockType, int unitCount)
        {
            throw new NotImplementedException();
        }

        public bool IsTextMarked(TextBlockType textBlockType, int unitCount)
        {
            throw new NotImplementedException();
        }

        public void HomeKey()
        {
            throw new NotImplementedException();
        }

        public void MoveToStart()
        {
            throw new NotImplementedException();
        }

        public string GetParagraphText(int index)
        {
            throw new NotImplementedException();
        }

        public void MarkText(int index)
        {
            throw new NotImplementedException();
        }

        public void MoveCursor(int paragraphCount, int wordCount)
        {
            throw new NotImplementedException();
        }
    }
}
