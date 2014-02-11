using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Bquiz.Services.Helpers;
using BquizDB.Entities;
using BquizDB.Business;

namespace Bquiz.Services.Models
{
    [DataContract]
    public class UserProfile
    {
        public UserProfile(bq_User user)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            Email = user.Email;
            Avatar = ps_Server.AvatarPath + user.Avatar;   
            Gender = user.Gender;
            BirthDay = user.Birthday;
            BestScore = user.BestScore;

            bl_User blUser = new bl_User();
            Ranking = blUser.GetRanking(BestScore);
        }

        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Avatar { get; set; }
        [DataMember]
        public bool? Gender { get; set; }
        [DataMember]
        public DateTime? BirthDay { get; set; }
        [DataMember]
        public int BestScore { get; set; }
        [DataMember]
        public int Ranking { get; set; }
    }
}