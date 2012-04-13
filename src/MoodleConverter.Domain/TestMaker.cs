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

        public int TestCount
        { get { return _testCount; }
            set { _testCount = value; }
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
        /// Moves cursor to the start of first test
        /// </summary>
        /// <remarks></remarks>
        public void FindTestBegin()
        {
            bool isFind = false;
            while (!isFind && (_document.GetParagraphCount()> _paragraphPosition))
            {
                _paragraphPosition += 1;
                string curWord = _document.GetTextFromPosition(TextBlockType.word, 1);
                _document.MoveCursor(0, 1);
                string nextWord = _document.GetTextFromPosition(TextBlockType.word, 1);
                _document.MoveCursor(0, -1);
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

        /// <summary>
        /// Determines whether [is ansver begin].
        /// </summary>
        /// <returns><c>true</c> if [is ansver begin]; otherwise, <c>false</c>.</returns>
        /// <remarks></remarks>
        public bool IsAnsverBegin()
        {
            try
            {
                string curWord = _document.GetTextFromPosition(TextBlockType.word, 1);
                _document.MoveCursor(0, 1);
                string nextWord = _document.GetTextFromPosition(TextBlockType.word, 1);
                _document.MoveCursor(0, -1);
                return KeyWord.IsAnswerStart(curWord, nextWord);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Moves cursor to next ansver start.
        /// </summary>
        /// <remarks></remarks>
        public void MoveToNextAnsver()
        {
            while ((_document.GetTextFromPosition(TextBlockType.word, 1).Trim(' ') != KeyWord.NewLine) &&
                   !IsAnsverBegin())
            {
                _document.MoveCursor(0, 1);
            }
        }


        /// <summary>
        /// Gets the ansver text.
        /// </summary>
        /// <returns>String with ansver</returns>
        /// <remarks></remarks>
        public string GetAnsverText()
        {
            string annsverText = string.Empty;
            while ((_document.GetTextFromPosition(TextBlockType.word, 1).Trim(' ') != KeyWord.NewLine) &&
                   !IsAnsverBegin())
            {
                annsverText += _document.GetTextFromPosition(TextBlockType.word, 1);
                _document.MoveCursor(0, 1);
            }
            return annsverText;
        }


    }
}
