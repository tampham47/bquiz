//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BquizDB.Entities
{
    using System;
    
    public partial class bq_Question_GetByQuizId_Result
    {
        public System.Guid QuestionId { get; set; }
        public System.Guid QuestionGroupId { get; set; }
        public System.Guid QuizId { get; set; }
        public byte Order { get; set; }
        public string ImagePath { get; set; }
        public string MediaPath { get; set; }
        public string Paragraph { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public byte Answer { get; set; }
        public bool IsDone { get; set; }
    }
}
