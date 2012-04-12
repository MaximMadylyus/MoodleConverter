using System;
using System.Collections.Generic;

namespace MoodleConverter.Domain
{
    public class Task
    {        
        public Task()
        {
            Ansvers = new List<Ansver>();
        }

        #region private fields

        private string _taskText = String.Empty;

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets task text
        /// </summary>
        public string TaskText
        {
            get { return _taskText; }
            set { _taskText = value; }
        }

        /// <summary>
        /// Gets Ansvers Ilist
        /// </summary>
        public List<Ansver> Ansvers { get; private set; }

        #endregion

    }
}
