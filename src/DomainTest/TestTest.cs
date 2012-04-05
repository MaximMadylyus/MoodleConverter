using NUnit.Framework;
using Domain;

namespace DomainTest
{
    [TestFixture]
    public class TestTest
    {
        [Test]
        public void ConstructorTest()
        {
            var testObj = new Test();
            Assert.AreNotEqual(null, testObj);
        }

        [Test]
        public void IsFieldsEmpty ()
        {
            var testObj = new Test();
            Assert.AreEqual(string.Empty, testObj.TaskText);
        }
    }
}
