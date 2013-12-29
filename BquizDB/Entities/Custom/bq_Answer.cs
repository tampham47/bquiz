using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BquizDB.Entities
{
    public partial class bq_Answer
    {
        public string GetStrAnswer()
        {
            switch (Answer)
            {
                case 1: return "A";
                case 2: return "B";
                case 3: return "C";
                case 4: return "D";
                default: return "-";
            }
        }
    }
}
