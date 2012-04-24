using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MoodleConverter.Domain.Model;

namespace MoodleConverter.Data
{
    class MoodleConverterContext : DbContext
    {
        public  DbSet<User> Users { get; set; }
    }
}
