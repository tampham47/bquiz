using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Net;
using Bquiz.Display.Helpers;
using BquizDB.Entities;

namespace Bquiz.Display.ServiceModels
{
    [DataContract]
    public class Question
    {
        public Question(bq_Question question)
        {
            QuestionId = question.QuestionId;
            OptionA = question.OptionA;
            OptionB = question.OptionB;
            OptionC = question.OptionC;
            OptionD = question.OptionD;
            Answer = question.Answer;

            ImagePath = null;
            if (question.ImagePath != null)
                ImagePath = ps_Server.ImagePath + question.ImagePath;

            MediaPath = null;
            if (question.MediaPath != null)
                MediaPath = ps_Server.AudioPath + question.MediaPath;

            Paragraph = question.Paragraph;

            //QuestionGroupId = question.QuestionGroupId;
            //Order = question.Order;
        }

        [DataMember]
        public System.Guid QuestionId { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public string MediaPath { get; set; }
        [DataMember]
        public string Paragraph { get; set; }
        [DataMember]
        public string OptionA { get; set; }
        [DataMember]
        public string OptionB { get; set; }
        [DataMember]
        public string OptionC { get; set; }
        [DataMember]
        public string OptionD { get; set; }
        [DataMember]
        public byte Answer { get; set; }

        //[DataMember]
        //public System.Guid QuestionGroupId { get; set; }
        //[DataMember]
        //public byte Order { get; set; }
    }
}