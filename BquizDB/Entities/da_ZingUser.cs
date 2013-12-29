using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BquizDB.Entities
{
    public class da_ZingUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string TinyUrl { get; set; }
        public string ProfileUrl { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Avatar160 { get; set; }
    }
}
