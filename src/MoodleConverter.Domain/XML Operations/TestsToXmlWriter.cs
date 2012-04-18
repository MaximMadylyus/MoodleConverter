using System.Collections.Generic;
using System.IO;

namespace MoodleConverter.Domain
{
    public class TestsToXmlWriter
    {
        #region ***** private fields

        private string _category = string.Empty;

        #endregion

        #region ***** public properties

        #endregion

        public void ConvertToFile(List<Task> tasks, string path)
        {

            if (path != ".xml")
            {
                StreamWriter writer = new StreamWriter(path);


                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                writer.WriteLine("<quiz>");
                writer.WriteLine("<!--  question: 0  -->");
                writer.WriteLine("<question type=\"category\">");
                writer.WriteLine("<category>");
                writer.WriteLine("<text>" + _category + "</text>");
                writer.WriteLine("</category>");
                writer.WriteLine("</question>");

                for (int i = 0; i < tasks.Count; i++)
                {

                    writer.WriteLine("- <!--  question: " + (i + 1).ToString() + "  -->");


                    writer.WriteLine("<question type=\"multichoice\">");
                    writer.WriteLine("<name>");
                    writer.WriteLine("<text>Question" + (i + 1).ToString() + "</text>");
                    writer.WriteLine("</name>");
                    writer.WriteLine("<questiontext format=\"html\">");
                    writer.WriteLine("<text>" + tasks[i].TaskText + "</text>");
                    writer.WriteLine("</questiontext>");
                    writer.WriteLine("<image />");
                    writer.WriteLine("<generalfeedback>");
                    writer.WriteLine("<text />");
                    writer.WriteLine("</generalfeedback>");
                    writer.WriteLine("<defaultgrade>1</defaultgrade>");
                    writer.WriteLine("<penalty>0.1</penalty>");
                    writer.WriteLine("<hidden>0</hidden>");
                    writer.WriteLine("<shuffleanswers>1</shuffleanswers>");
                    writer.WriteLine("<single>false</single>");
                    writer.WriteLine("<shuffleanswers>true</shuffleanswers>");
                    writer.WriteLine("<correctfeedback>");
                    writer.WriteLine("<text />");
                    writer.WriteLine("</correctfeedback>");
                    writer.WriteLine("<partiallycorrectfeedback>");
                    writer.WriteLine("<text />");
                    writer.WriteLine("</partiallycorrectfeedback>");
                    writer.WriteLine("<incorrectfeedback>");
                    writer.WriteLine("<text />");
                    writer.WriteLine("</incorrectfeedback>");
                    writer.WriteLine("<answernumbering>123</answernumbering>");

                    for (int j = 0; j < tasks[i].Ansvers.Count; j++)
                    {
                        writer.WriteLine(tasks[i].Ansvers[j].IsCorrect
                                             ? "<answer fraction=\"100\">"
                                             : "<answer fraction=\"0\">");

                        writer.WriteLine("<text>" + tasks[i].Ansvers[j].AnsverText + "</text>");
                        writer.WriteLine("<feedback>");
                        writer.WriteLine("<text />");
                        writer.WriteLine("</feedback>");
                        writer.WriteLine("</answer>");
                    }

                    writer.WriteLine("</question>");
                }

                writer.WriteLine("</quiz>");
                writer.Close();

            }
        }
    }
}
