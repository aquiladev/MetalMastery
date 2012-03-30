using NUnit.Framework;

namespace MetalMastery.Core.Tests
{
    [TestFixture]
    public class ExtentionsTests
    {
        [Test]
        public void ToInt_NotInt_DefaultValue()
        {
            var intValue = "test".ToInt();

            Assert.AreEqual(intValue, default(int));
        }

        [Test]
        public void ToInt_CorrectValue()
        {
            var intValue = "21".ToInt();

            Assert.AreEqual(intValue, 21);
        }
    }
}
