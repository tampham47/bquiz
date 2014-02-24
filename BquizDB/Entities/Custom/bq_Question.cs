using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BquizDB.Entities
{
    public partial class bq_Question
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

        public String GetAnswerOrDefault(string option)
        {
            switch (option)
            {
                case "A": return (OptionA != null) ? OptionA : "Answer from audio";
                case "B": return (OptionB != null) ? OptionB : "Answer from audio";
                case "C": return (OptionC != null) ? OptionC : "Answer from audio";
                case "D": return (OptionD != null) ? OptionD : "Answer from audio";
                default: return "Answer from audio";
            }
        }
    }
}
