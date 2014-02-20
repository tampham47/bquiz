using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BquizDB.Utility
{
    public static class Server
    {
        public static string ImagePath =
            System.Configuration.ConfigurationManager.AppSettings["ImagePath"];

        public static string AudioPath =
            System.Configuration.ConfigurationManager.AppSettings["AudioPath"];

        public static string AvatarPath =
            System.Configuration.ConfigurationManager.AppSettings["AvatarPath"];
    }
}
