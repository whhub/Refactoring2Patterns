using System.IO;
using System.Web;

namespace TextConverter
{
    public class UnicodeFileToHtmTextConverter
    {
        private TextReader _reader;
        private StringEscaper _stringEscaper;

        public UnicodeFileToHtmTextConverter(string fullFilenameWithPath) : this(new StreamReader(new FileStream(fullFilenameWithPath, FileMode.Open)))
        {
        }

        public UnicodeFileToHtmTextConverter(TextReader reader) : this(reader, new StringEscaper())
        {
        }

        public UnicodeFileToHtmTextConverter(TextReader reader, StringEscaper stringEscaper)
        {
            _reader = reader;
            _stringEscaper = stringEscaper;
        }

        public string ConvertToHtml()
        {
            var html = string.Empty;

            var line = _reader.ReadLine();
            while (line != null)
            {
                // TODO-working-on: Depending on the third party library violates the Dependency Inversion Principle and Open-Closed Principle
                html += _stringEscaper.EscapeHtml(line);
                html += "<br />";
                line = _reader.ReadLine();
            }

            return html;
        }
    }
}