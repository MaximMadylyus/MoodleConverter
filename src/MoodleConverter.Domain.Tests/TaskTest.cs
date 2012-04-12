using NUnit.Framework;

namespace MoodleConverter.Domain.Tests
{
    [TestFixture]
    public class TaskTest
    {
        [Test]
        public void InitializeTest()
        {
            var taskObj = new Task();
            Assert.AreEqual(string.Empty, taskObj.TaskText);
        }

        
        
        [Test]
        public void QuestionsShouldNotBeNullForNewTest()
        {
            var task = new Task();
            Assert.NotNull(task.Ansvers);
            Assert.AreEqual(task.Ansvers.Count, 0);
        }


        /// <summary>
        /// Cheks if there are any ansvers in task and if there is correct one
        /// </summary>
        //[Test]
        //public void AnsversInTest()
        //{
        //    var testObj = new Task();
        //    var isCorrectAnsver = false;

        //    Assert.AreNotEqual(0, testObj.Ansvers.Count);

        //    foreach (var ansver in testObj.Ansvers)
        //    {
        //        if (ansver.IsCorrect)
        //        {
        //            isCorrectAnsver = true;
        //        }
        //    }

        //    Assert.False(isCorrectAnsver);
        //}


    }
}
