using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BquizDB.Entities;

namespace Bquiz.Display.Models
{
    public static class ps_Global
    {
        public static string AudioPath = "/Bquiz_Data/Audio";
        public static string ImagePath = "/Bquiz_Data/Images";
        public static string AvatarPath = "/Bquiz_Data/Avatars";
    }

    public class ps_Group
    {
        public Guid QuizId { get; set; }
        public Guid TestId { get; set; }

        public bq_QuestionGroup Group { get; set; }
        public List<bq_Question> QuestionList { get; set; }
        public List<bq_Answer> AnswerList { get; set; }
    }

    public class ps_PreStartModel
    {
        public BquizDB.Entities.bq_Quiz Quiz { get; set; }
        public BquizDB.Entities.bq_User User { get; set; }
    }

    public class ps_NewQuiz
    {
        public bq_Quiz Quiz { get; set; }
        public short NumberOfPart7Group { get; set; }
        public List<short> ItemsForeachP7Group { get; set; }
    }

    public class ps_TestingNav
    {
        public Guid PreGroup { get; set; }
        public Guid NextGroup { get; set; }
    }
}