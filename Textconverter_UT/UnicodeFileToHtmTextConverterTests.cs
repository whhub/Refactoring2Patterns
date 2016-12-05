using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextConverter;

namespace Textconverter_UT
{
    [TestClass]
    public class UnicodeFileToHtmTextConverterTests
    {
        // TODO-new-feature: Make the UnicodeFileToHtmTextConverter working for not only a file but also a string

        // TODO-user-intent-test-working-on: should convert ampersand
        public void Should_covert_ampersand()
        {
            // Arrange
            var converter = new UnicodeFileToHtmTextConverter(new StringReader("H&M"));
            
            // Act & Assert
            Assert.AreEqual("", convert.ConvertToHtml());
        }

        // TODO-user-intent-test: should convert greater than and less than
        
        // TODO-user-intent-test: should add a line break for a new line

    }
}
