using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Utility;

namespace BquizDB.Entities
{
    public partial class bq_User
    {
        public string GetDisplayName()
        {
            if (DisplayName != null)
                return DisplayName;
            else
                return UserName;
        }

        public string GetAvatar()
        {
            if (Avatar.Contains("http"))
                return Avatar;
            else
                return Server.AvatarPath + Avatar;
        }
    }
}
