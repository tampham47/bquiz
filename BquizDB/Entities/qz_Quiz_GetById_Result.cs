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
    
    public partial class qz_Quiz_GetById_Result
    {
        public System.Guid QuizId { get; set; }
        public System.Guid UserId { get; set; }
        public string Name { get; set; }
        public string FinanceCompany { get; set; }
        public string CompanyIcon { get; set; }
        public int NumberOfTesting { get; set; }
        public int MaxScore { get; set; }
        public System.DateTime DateCreated { get; set; }
        public byte Status { get; set; }
    }
}
