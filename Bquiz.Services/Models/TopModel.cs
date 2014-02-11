using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bquiz.Services.Models
{
    [DataContract]
    public class TopModel
    {
        public TopModel()
        {
            UserList = new List<UserProfile>();
        }

        [DataMember]
        public UserProfile CurrentUser { get; set; }
        [DataMember]
        public List<UserProfile> UserList { get; set; }
    }
}