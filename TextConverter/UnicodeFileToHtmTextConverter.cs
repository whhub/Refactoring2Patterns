using System.IO;
using System.Web;

namespace TextConverter
{
    public class UnicodeFileToHtmTextConverter
    {
        private readonly string _fullFilenameWithPath;

        public UnicodeFileToHtmTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public UnicodeFileToHtmTextConverter(TextReader reader)
        {

        }

        public string ConvertToHtml()
        {
            // TODO: Depending on the file system violates the Dependency Inversion Principle and Open-closed Principle.
            var reader = new StreamReader(new FileStream(_fullFilenameWithPath, FileMode.Open));

            var html = string.Empty;

            var line = reader.ReadLine();
            while (line != null)
            {
                // TODO: Depending on the third party library violates the Dependency Inversion Principle and Open-Closed Principle.
                html += HttpUtility.HtmlEncode(line);
                html += "<br />";
                line = reader.ReadLine();
            }

            return html;
        }
    }
}