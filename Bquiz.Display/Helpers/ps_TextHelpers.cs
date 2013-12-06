using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bquiz.Display.Helpers
{
    public static class ps_TextHelpers
    {
        public static string ToPlainText(string paragraph)
        {
            var tmp = HttpUtility.HtmlDecode(paragraph);
            tmp = HttpUtility.HtmlDecode(tmp);

            //int first, last;
            //first = tmp.IndexOf("<");
            //last = tmp.IndexOf(">");

            //while (first >= 0 && last >= 0)
            //{
            //    tmp = tmp.Remove(first, last - first + 1);
            //    first = tmp.IndexOf("<");
            //    last = tmp.IndexOf(">");
            //}

            //first = tmp.IndexOf("  ");
            //while (first >= 0)
            //{
            //    tmp = tmp.Replace("  ", " ");
            //    first = tmp.IndexOf("  ");
            //}

            return tmp;
        }
    }
}