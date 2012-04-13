using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleConverter.Domain
{
    public interface IDocument
    {
        /// <summary>
        /// Opens the document.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <remarks></remarks>
        void OpenDocument(string path);

        /// <summary>
        /// Closes the document.
        /// </summary>
        /// <param name="doSave">if set to <c>true</c> [do save].</param>
        /// <remarks></remarks>
        void CloseDocument(bool doSave);

        /// <summary>
        /// Returns text from current cursor position
        /// </summary>
        /// <param name="textBlockType">Type of text blocks</param>
        /// <param name="unitCount">Count of text blocks</param>
        /// <returns>string of text</returns>
        string GetTextFromPosition(TextBlockType textBlockType, int unitCount);


        /// <summary>
        /// Returns true if current text is bold or italic
        /// </summary>
        /// <param name="textBlockType">Type of text blocks</param>
        /// <param name="unitCount">Count of text blocks</param>
        /// <returns>bool</returns>
        bool IsTextMarked(TextBlockType textBlockType, int unitCount);


        /// <summary>
        /// Moves cursor on the begining of current line
        /// </summary>
        void HomeKey();


        /// <summary>
        /// Move cursor on the Begin of Document
        /// </summary>
        void MoveToStart();


        /// <summary>
        /// Returns text of paragraph
        /// </summary>
        /// <param name="index">number of paragraph</param>
        /// <returns>Paragraph text</returns>
        string GetParagraphText(int index);


        /// <summary>
        /// Mark paragraph text
        /// </summary>
        /// <param name="index"></param>
        void MarkText(int index);



        /// <summary>
        /// Moves the cursor.
        /// </summary>
        /// <param name="paragraphCount">The paragraph count.</param>
        /// <param name="wordCount">The word count.</param>
        /// <remarks></remarks>
        void MoveCursor(int paragraphCount, int wordCount);

        /// <summary>
        /// Gets the paragraph count.
        /// </summary>
        /// <remarks></remarks>
        int GetParagraphCount();
    }
}
