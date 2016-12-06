using System.IO;
using System.Web;

namespace TextConverter
{
    public class UnicodeFileToHtmTextConverter
    {
        private TextReader _reader;

        public UnicodeFileToHtmTextConverter(string fullFilenameWithPath)
        {
            _reader = new StreamReader(new FileStream(fullFilenameWithPath, FileMode.Open));
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
                // TODO-working-on: Depending on the third party library violates the Dependency Inversion Principle and Open-Closed Principle
                html += _stringEscapter.EscapeHtml(line);
                html += "<br />";
                line = _reader.ReadLine();
            }

            return html;
        }
    }
}