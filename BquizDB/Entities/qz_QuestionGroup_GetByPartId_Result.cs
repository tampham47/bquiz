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
    
    public partial class qz_QuestionGroup_GetByPartId_Result
    {
        public System.Guid QuestionGroupId { get; set; }
        public System.Guid QuizId { get; set; }
        public byte PartId { get; set; }
        public string Name { get; set; }
        public byte Order { get; set; }
        public string Paragraph { get; set; }
        public string MediaPath { get; set; }
        public bool IsDone { get; set; }
    }
}
