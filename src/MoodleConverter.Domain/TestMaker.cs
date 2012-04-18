using System;
using System.Collections.Generic;


namespace MoodleConverter.Domain
{
    public class TestMaker
    {
        #region ***** private fields
        private IDocument _document;
        private int _paragraphPosition;
        private int _testCount;
        private List<Task> _tasks = new List<Task>();
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

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        /// <remarks></remarks>
        public List<Task> Tasks
        { 
            get { return _tasks;} 
        }

        #endregion

        #region ***** private methods
        /// <summary>
        /// Moves cursor to the start of first test
        /// </summary>
        /// <remarks></remarks>
        private bool FindTestBegin()
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
            return isFind;
        }

        /// <summary>
        /// Determines whether [is ansver begin].
        /// </summary>
        /// <returns><c>true</c> if [is ansver begin]; otherwise, <c>false</c>.</returns>
        /// <remarks></remarks>
        private bool IsAnsverBegin()
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
        private void MoveToNextAnsver()
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
        private string GetAnsverText()
        {
            string annsverText = string.Empty;
            while ((_document.GetTextFromPosition(TextBlockType.word, 1).Trim(' ') != KeyWord.NewLine) &&
                   !IsAnsverBegin())
            {
                annsverText += _document.GetTextFromPosition(TextBlockType.word, 1);
                _document.MoveCursor(0, 1);
            }
            if (_document.GetTextFromPosition(TextBlockType.word, 1).Trim(' ') == KeyWord.NewLine)
            {
                _document.MoveCursor(0, 1);
            }
            return annsverText;
        }

        #endregion

        #region ***** public methods
        /// <summary>
        /// Opens the document.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <remarks></remarks>
        public void OpenDocument(string path)
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
        /// Adds the tasks to task list.
        /// </summary>
        /// <remarks></remarks>
        public void AddTasks()
        {
            while (FindTestBegin())
            {
                var curTask = new Task();
                curTask.TaskText = _document.GetTextFromPosition(TextBlockType.paragraph, 1);
                _document.MoveCursor(1,0);

                while (IsAnsverBegin())
                {
                    _document.MoveCursor(0,2);
                    bool isCorrect = _document.IsTextMarked(TextBlockType.word, 1);
                    string answerText = GetAnsverText();
                    curTask.Ansvers.Add(new Ansver(answerText, isCorrect));
                }
                
                _tasks.Add(curTask);
            }

        }

        /// <summary>
        /// Writes to XML.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <remarks></remarks>
        public void WriteToXML(string path)
        {
            var xmlWriter = new TestsToXmlWriter();
            xmlWriter.ConvertToFile(_tasks, path);
        }

        #endregion  

    }
}
