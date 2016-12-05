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

        public string ConvertToHtml()
        {
            var reader = new StreamReader(new FileStream(_fullFilenameWithPath, FileMode.Open));

            var html = string.Empty;

            var line = reader.ReadLine();
            while (line != null)
            {
                html += HttpUtility.HtmlEncode(line);
                html += "<br />";
                line = reader.ReadLine();
            }

            return html;
        }
    }
}