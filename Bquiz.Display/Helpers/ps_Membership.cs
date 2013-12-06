using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BquizDB.Entities;
using BquizDB.Business;

namespace Bquiz.Display.Helpers
{
    public static class ps_Membership
    {
        public static bool IsAuthenticated()
        {
            return WebMatrix.WebData.WebSecurity.IsAuthenticated;
        }

        //return current user
        public static bq_User GetUser()
        {
            var userName = WebMatrix.WebData.WebSecurity.CurrentUserName;
            bl_User bl_user = new bl_User();

            return bl_user.GetByUserName(userName);
        }
    }
}