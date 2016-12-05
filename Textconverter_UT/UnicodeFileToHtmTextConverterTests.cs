using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextConverter;

namespace Textconverter_UT
{
    [TestClass]
    public class UnicodeFileToHtmTextConverterTests
    {
        // TODO-new-feature: Make the UnicodeFileToHtmTextConverter working for not only a file but also a string

        [TestMethod]
        public void Should_covert_ampersand()
        {
            // Arrange
            var converter = new UnicodeFileToHtmTextConverter(new StringReader("H&M"));
            
            // Act & Assert
            Assert.AreEqual("H&amp;M<br />", converter.ConvertToHtml());
        }

        // TODO-user-intent-test: should convert greater than and less than
        [TestMethod]
        public void Should_convert_greater_than_and_less_than()
        {
            // Arrange
            var converter = new UnicodeFileToHtmTextConverter(new StringReader(">_<|||"));
            
            // Act & Assert
            Assert.AreEqual("&gt;_&lt;|||<br />", converter.ConvertToHtml());
        }

        // TODO-user-intent-test: should add a line break for a new line

    }
}
