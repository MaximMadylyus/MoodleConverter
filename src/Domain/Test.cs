using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Test
    {
        
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

        #endregion

    }
}
