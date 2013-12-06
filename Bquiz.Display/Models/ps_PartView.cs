using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BquizDB.Business;
using BquizDB.Entities;

namespace Bquiz.Display.Models
{
    public class ps_PartViewItem
    {
        public string PartName = "part1";
        public Guid TestId { get; set; }
        public List<bq_QuestionGroup> Groups { get; set; }
    }

    public class ps_PartView
    {
        public ps_PartView(Guid quizId)
        {

        }
    }
}