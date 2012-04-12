namespace MoodleConverter.Domain
{
    public class Ansver
    {
        #region private fields
        private string _ansverText = string.Empty;
        private bool _isCorrect = false;
        #endregion

        #region public properties

        public string AnsverText
        {
            get { return _ansverText; }
            set { _ansverText = value; }
        }

        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        #endregion
    }
}
