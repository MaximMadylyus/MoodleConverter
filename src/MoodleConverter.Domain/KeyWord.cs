﻿using System;
using System.Linq;

namespace MoodleConverter.Domain
{
    public class KeyWord
    {
        private static readonly string[] _tasksStartWords = {
                                                                "Task","Test", "Завдання", "Вправа", "Тест", "Запитання"
                                                            };

        private static readonly string[] _ansverStartWords = {
                                                                "A","B", "C", "B", "D", "E", "F","G","H","I", "a", "b", "c", "d", "e", "f", "g", "а","б","в","г","д","е","є","А","Б","В","Г","Д", "Є","Е"
                                                             };

        private static string[] _functionWords = {
                                                     "\r", ",", ".", ")", "#", "№", "\t","\n",":",";","..","...","/r"

                                                 };

        public static string NewLine = "\r";

        public static bool IsTaskStart(string curword, string nextword)
        {
            bool isStart = false;
            bool isNumber;
            try
            {
                int.Parse(curword);
                isNumber = true;
            }
            catch (FormatException)
            {
                isNumber = false;
            }


            if (_tasksStartWords.Contains(curword) && _functionWords.Contains(nextword.Trim(' ')))
            {
                isStart = true;
            }

            if (isNumber && _functionWords.Contains(nextword.Trim(' ')) )
            {
                isStart = true;
            }

            return isStart;
        }

        public static bool IsAnswerStart(string curword, string nextword)
        {
            if (_ansverStartWords.Contains(curword.Trim(' ')) && _functionWords.Contains(nextword.Trim(' ')))
            {
                return true;
            }
            return false;
        }
       public enum WordType
        {
            Ansver,
            Test,
            Separator
        }
    }
}
