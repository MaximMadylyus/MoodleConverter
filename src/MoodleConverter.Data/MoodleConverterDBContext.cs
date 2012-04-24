using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;
using MoodleConverter.Domain.Model;


namespace MoodleConverter.Data
{
    class MoodleConverterDBContext : DbContext 
    {
        public DbSet<User> Test
        {
            get;
            set;
        }
    }
}
