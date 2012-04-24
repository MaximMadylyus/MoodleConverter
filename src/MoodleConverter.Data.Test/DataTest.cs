using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MoodleConverter.Data;

namespace MoodleConverter.Data.Test
{
    [TestFixture]
    public class DataTest
    {
        [Test]
        public void CreateDBTest()
        {
            var context = new MoodleConverterDBContext();
            if (!context.Database.Exists())
            {
                context.Database.Initialize(false);
            }
            Assert.IsTrue(context.Database.Exists());
        }
    }
}
