using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zingme_sdk;
using BquizDB.Entities;

namespace BquizDB.Utility
{
    public class ZingMe
    {
        private ZME_Environment env = ZME_Environment.PRODUCTION;
        private string appName = "bquiz";
        private string apiKey = "df3f977079ab4d94844ecef8da0dcb81";
        private string secretKey = "b2d795ef5b1f41fda99b6d2781ccc96d";
        private string getfields = "id, username, displayname, tinyurl, profile_url, gender, dob, ava160";
        private ZME_Config config;
        private string signed_request;
        private string AccessToken;
        private int Expires;
        private ZME_Me Me;

        private da_ZingUser ToZingUser(Hashtable data)
        {
            da_ZingUser user = new da_ZingUser();
            user.Id = data["id"].ToString();
            user.UserName = data["username"].ToString();
            user.DisplayName = data["displayname"].ToString();
            user.TinyUrl = data["tinyurl"].ToString();
            user.ProfileUrl = data["profile_url"].ToString();
            user.Gender = data["gender"].ToString();
            user.Dob = data["dob"].ToString();
            user.Avatar160 = data["ava160"].ToString();

            return user;
        }

        public ZingMe(string signed_request)
        {
            config = new ZME_Config(appName, apiKey, secretKey, env);
            ZME_Authentication auth = new ZME_Authentication(config);
            AccessToken = auth.getAccessTokenFromSignedRequest(signed_request, out Expires);
            Me = new ZME_Me(config);
        }

        public da_ZingUser GetInfo()
        {
            var data = Me.getInfo(AccessToken, "id, username, displayname, tinyurl, profile_url, gender, dob, ava160");
            return ToZingUser(data);
        }

        //public da_ZingUser GetUserInfo(string uids)
        //{
        //    ZME_User zingUser = new ZME_User(config);
        //    var data = zingUser.getInfo(AccessToken, uids, getfields);
        //    return new da_ZingUser();
        //}

        //public bool GetFriends()
        //{
        //    var data = Me.getFriends(AccessToken);
        //    return false;
        //}
    }
}
