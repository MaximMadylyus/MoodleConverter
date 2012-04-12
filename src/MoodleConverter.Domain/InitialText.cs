using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Task = MoodleConverter.Domain.Task;

namespace MoodleConverter.Domain
{
    public class InitialText
    {
#region ***** Private fields

        private List<string> _text = new List<string>();
        private List<Task> _tasks = new List<Task>();
        private Document _document;
        private Microsoft.Office.Interop.Word.Application _application = new Microsoft.Office.Interop.Word.Application();

        private int _paragraphCount = 0;

#endregion 

#region ***** Public properties
        public List<string> Text
        {
            get { return _text; }  
            set { _text = value; }
        }


        public List<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        public Document CurrentDoc
        {
            get { return _document; }
            set { _document = value; }
        }

        public Microsoft.Office.Interop.Word.Application CurrentApp
        {
            get { return _application; }
            set { _application = value; }
        }

        #endregion

        /// <summary>
        /// Opens document
        /// </summary>
        /// <param name="pass">Pass to target docx file</param>
        public void OpenDocument(string pass)
        {
            try
            {
                // Open a doc file
                _document = _application.Documents.Open(pass, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read file! \n" + ex.Message );
            }
        }


        /// <summary>
        /// Closes document 
        /// </summary>
        /// <param name="doSave"></param>
        public void CloseDocument(bool doSave)
        {
            try
            {
                if (doSave)
                {
                    _document.Save();
                }
                _document.Close();
                _application.Quit();
                _document = null;
                _application = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read file! \n" + ex.Message);
            }
        }

        /// <summary>
        /// Returns text from current cursor position
        /// </summary>
        /// <param name="textBlockType">Type of text blocks</param>
        /// <param name="unitCount">Count of text blocks</param>
        /// <returns>string of text</returns>
        public string GetTextFromPosition(TextBlockType textBlockType, int unitCount)
        {
           
            Object count = unitCount;
            Object extend = WdMovementType.wdExtend;
            Object move = WdMovementType.wdMove;
            Object unit;

            string SelectedText = String.Empty;

            try
            {
                switch (textBlockType)
                {
                    case TextBlockType.paragraph:
                        unit = WdUnits.wdParagraph;
                        _application.Selection.MoveDown(ref unit, ref count, ref extend);
                        SelectedText = _application.Selection.Text;
                        _application.Selection.MoveLeft();
                        break;
                    case TextBlockType.word:
                        unit = WdUnits.wdWord;
                        _application.Selection.MoveRight(ref unit, ref count, ref extend);
                        SelectedText = _application.Selection.Text;
                        _application.Selection.MoveLeft();
                        break;
                    case TextBlockType.line:
                        unit = WdUnits.wdLine;
                        _application.Selection.MoveDown(ref unit, ref count, ref extend);
                        SelectedText = _application.Selection.Text;
                        _application.Selection.MoveLeft();
                        break;
                }
                return SelectedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get text! \n" + ex.Message);
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns true if current text is bold or italic
        /// </summary>
        /// <param name="textBlockType">Type of text blocks</param>
        /// <param name="unitCount">Count of text blocks</param>
        /// <returns>bool</returns>
        public bool IsTextMarked(TextBlockType textBlockType, int unitCount)
        {
            Object count = unitCount;
            Object extend = WdMovementType.wdExtend;
            Object unit;

            bool flag = false;
            try
            {
                switch (textBlockType)
                {
                    case TextBlockType.paragraph:
                        unit = WdUnits.wdParagraph;
                        _application.Selection.MoveDown(ref unit, ref count, ref extend);

                        if (_application.Selection.Font.Italic >= 1 || _application.Selection.Font.Bold != 1)
                        {
                            flag = true;
                        }
                        _application.Selection.MoveLeft();
                        
                        break;
                    case TextBlockType.word:
                        unit = WdUnits.wdWord;
                        _application.Selection.MoveRight(ref unit, ref count, ref extend);

                        if (_application.Selection.Font.Italic != 0 || _application.Selection.Font.Bold != 0)
                        {
                            flag = true;
                        }
                        _application.Selection.MoveLeft();
                        break;
                    case TextBlockType.line:
                        unit = WdUnits.wdLine;
                        _application.Selection.MoveDown(ref unit, ref count, ref extend);

                        if (_application.Selection.Font.Italic != 0 || _application.Selection.Font.Bold != 0)
                        {
                            flag = true;
                        }
                        _application.Selection.MoveLeft();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not perform! \n" + ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Moves cursor on the begining of current line
        /// </summary>
        public void HomeKey()
        {
            _application.Selection.HomeKey();
        }

        /// <summary>
        /// Move cursor on the Begin of Document
        /// </summary>
        public void MoveToStart()
        {
            Object extend = WdMovementType.wdMove;
            Object unit = WdUnits.wdStory;
            _application.Selection.HomeKey(ref unit, ref extend);
            _paragraphCount = 0;
        }

        /// <summary>
        /// Returns text of paragraph
        /// </summary>
        /// <param name="index">number of paragraph</param>
        /// <returns>Paragraph text</returns>
        public string GetParagraphText(int index)
        {
            try
            {
                Paragraph oParagraph = _document.Paragraphs[index];
                Range wordrange = oParagraph.Range;
                return wordrange.Text;
            }
            catch (Exception ex)
            {

                
            }
            return string.Empty;

        }

        /// <summary>
        /// Mark paragraph text
        /// </summary>
        /// <param name="index"></param>
        public void MarkText(int index)
        {
            try
            {
                Paragraph oParagraph = _document.Paragraphs[index];
                Range wordrange = oParagraph.Range;
                wordrange.Font.Color = WdColor.wdColorRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
