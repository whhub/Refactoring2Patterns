using System.IO;
using System.Web;

namespace TextConverter
{
    public class UnicodeFileToHtmTextConverter
    {
        private readonly string _fullFilenameWithPath;
        private TextReader _reader;

        public UnicodeFileToHtmTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public UnicodeFileToHtmTextConverter(TextReader reader)
        {
            _reader = reader;
        }

        public string ConvertToHtml()
        {
            var html = string.Empty;

            var line = _reader.ReadLine();
            while (line != null)
            {
                // TODO: Depending on the third party library violates the Dependency Inversion Principle and Open-Closed Principle.
                html += HttpUtility.HtmlEncode(line);
                html += "<br />";
                line = _reader.ReadLine();
            }

            return html;
        }
    }
}