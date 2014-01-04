using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BquizDB.Entities
{
    public partial class bq_Quiz
    {
        public string StrStatus
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "Approval";
                    case 1:
                        return "Pending";
                    default:
                        return "Editing";
                }
            }
        }
    }
}
