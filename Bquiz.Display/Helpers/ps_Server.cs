using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bquiz.Display.Helpers
{
    public static class ps_Server
    {
        public static string ImagePath = 
            System.Configuration.ConfigurationManager.AppSettings["ImagePath"];

        public static string AudioPath = 
            System.Configuration.ConfigurationManager.AppSettings["AudioPath"];

        public static string AavatarPath =
            System.Configuration.ConfigurationManager.AppSettings["AavatarPath"];
    }
}