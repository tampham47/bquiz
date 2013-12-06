using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using BquizDB.Entities;

namespace Bquiz.Display.ServiceModels
{
    [DataContract]
    public class UserProfile
    {
        public UserProfile(bq_User user)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            Email = user.Email;
            Avatar = user.Avatar;
            Gender = user.Gender;
            BirthDay = user.Birthday;
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
    }
}