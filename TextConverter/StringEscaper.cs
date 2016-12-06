using System.Web;

namespace TextConverter
{
    public class StringEscaper
    {
        public string EscapeHtml(string line)
        {
            return HttpUtility.HtmlEncode(line);
        }
    }
}
