using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleConverter.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
