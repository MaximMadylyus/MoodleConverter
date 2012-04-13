using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleConverter.Domain
{
    public class TestMaker
    {
        #region ***** private fields
        private IDocument _document;
        private int _paragraphPosition;
        private int _testCount;
        #endregion

        #region ***** public properties

        public IDocument Document
        {
            get { return _document; }
            set { _document = value; }
        }

        #endregion

        /// <summary>
        /// Opens the document.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <remarks></remarks>
        public void OpenDocument (string path)
        {
            try
            {
                _document = DocumentFactory.GetDocumentInstance(path);
                _document.OpenDocument(path);
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Finds the test begin.
        /// </summary>
        /// <remarks></remarks>
        public void FindTestBegin()
        {

            bool isFind = false;
            while (!isFind && (_document.GetParagraphCount()> _paragraphPosition))
            {
                _paragraphPosition += 1;
                string curWord = _document.GetTextFromPosition(TextBlockType.word, 1);
                string nextWord = _document.GetTextFromPosition(TextBlockType.word, 1);
                if (KeyWord.IsTaskStart(curWord, nextWord))
                {
                    isFind = true;
                    _testCount++;
                }
                else
                {
                    _document.MoveCursor(1, 0);

                }
            }
        }


    }
}
