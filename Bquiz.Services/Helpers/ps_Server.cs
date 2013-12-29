using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bquiz.Services.Helpers
{
    public static class ps_Server
    {
        public static string ImagePath = System.Configuration.ConfigurationManager.AppSettings["ImagePath"];
        public static string AudioPath = System.Configuration.ConfigurationManager.AppSettings["AudioPath"];
    }

    public static class ps_TextHelpers
    {
        public static string ToPlainText(string paragraph)
        {
            var tmp = HttpUtility.HtmlDecode(paragraph);
            tmp = HttpUtility.HtmlDecode(tmp);
            return tmp;
        }
    }
}