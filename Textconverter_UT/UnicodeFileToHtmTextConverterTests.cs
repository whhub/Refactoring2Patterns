﻿using System.IO;
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

        [TestMethod]
        public void Should_covert_greater_than_and_less_than()
        {
            // Arrange
            var converter = new UnicodeFileToHtmTextConverter(new StringReader(">_<|||"));

            // Act & Assert
            Assert.AreEqual("&gt;_&lt;|||<br />", converter.ConvertToHtml());
        }


        [TestMethod]
        public void Should_add_a_line_break_for_a_new_line()
        {
            // Arrange
            var converter = new UnicodeFileToHtmTextConverter(new StringReader("Cheers\nBen Wu"));
            
            // Act & Assert
            Assert.AreEqual("Cheers<br />Ben Wu<br />", converter.ConvertToHtml());
        }


    }
}
