using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Bquiz.Display.Helpers;
using BquizDB.Entities;
using BquizDB.Business;

namespace Bquiz.Display.ServiceModels
{
    [DataContract]
    public class Group
    {
        public Group(bq_QuestionGroup group)
        {
            GroupId = group.QuestionGroupId;
            PartId = group.PartId;
            Order = group.Order;
            SyncVersion = group.SyncVersion;

            MediaPath = null;
            if (group.MediaPath != null)
                MediaPath = ps_Server.AudioPath + group.MediaPath;

            Paragraph = null;
            if (group.Paragraph != null)
                Paragraph = ps_TextHelpers.ToPlainText(group.Paragraph);

            Questions = new List<Question>();

            //QuizId = group.QuizId;
            //Name = group.Name;
            //IsDone = group.IsDone;
        }

        [DataMember]
        public Guid GroupId { get; set; }
        [DataMember]
        public short PartId { get; set; }
        [DataMember]
        public short Order { get; set; }
        [DataMember]
        public string Paragraph { get; set; }
        [DataMember]
        public string MediaPath { get; set; }
        [DataMember]
        public int SyncVersion { get; set; }
        [DataMember]
        public List<Question> Questions { get; set; }

        //[DataMember]
        //public Guid QuizId { get; set; }
        //[DataMember]
        //public string Name { get; set; }
        //[DataMember]
        //public bool IsDone { get; set; }
    }
}