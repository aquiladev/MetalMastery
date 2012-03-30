using MetalMastery.Core.Web;
using NUnit.Framework;

namespace MetalMastery.Core.Tests.Web
{
    [TestFixture]
    public class ExtentionsTests
    {
        [Test]
        public void GetPreviewText_LengthLess100()
        {
            const string source = "test";
            string result = source.GetPreviewText();

            Assert.AreEqual(result, source);
        }

        [Test]
        public void GetPreviewText_LengthMore100()
        {
            const string source = "In nautical (and aeronautical) contexts, a vessel may declare a number of 'souls onboard'. I've jkoa";
            const string source2 = " may declare a number of 'souls onboard'. I've";
            string result = string.Concat(source, source2).GetPreviewText();

            Assert.AreEqual(result, string.Concat(source, "..."));
        }
    }
}
