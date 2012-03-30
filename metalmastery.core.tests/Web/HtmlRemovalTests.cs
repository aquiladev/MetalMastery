using MetalMastery.Core.Web;
using NUnit.Framework;

namespace MetalMastery.Core.Tests.Web
{
    [TestFixture]
    public class HtmlRemovalTests
    {
        [Test]
        public void StripTags_ClearText()
        {
            const string source = "test text";
            string str = HtmlRemoval.StripTags(source);

            Assert.AreEqual(source, str);
        }

        [Test]
        public void StripTags_TextWithTags()
        {
            const string source = "test text<br>dsfdsfdsfgv <a>test</a> bla-bla-bla-bla</br>";
            string str = HtmlRemoval.StripTags(source);

            Assert.AreEqual("test textdsfdsfdsfgv test bla-bla-bla-bla", str);
        }
    }
}
