using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bquiz.Display.Models;
using BquizDB.Business;

namespace Bquiz.Display.Helpers
{
    public static class ps_PageHelpers
    {
        public static ps_TestingNav GetNav(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            var nav = new ps_TestingNav();
            var nextId = Guid.NewGuid();
            var backId = Guid.NewGuid();

            var group = bl_group.GetById(groupId);
            var temp = bl_group.GetByPartId(group.QuizId, group.PartId);

            int m = temp.Count();
            for (int i = 0; i < m; i++)
            {
                if (temp[i].QuestionGroupId == groupId)
                {
                    if (i == 0)
                    {
                        nextId = temp[i + 1].QuestionGroupId;
                        backId = temp[m - 1].QuestionGroupId;
                    }
                    if (i == m - 1)
                    {
                        nextId = temp[0].QuestionGroupId;
                        backId = temp[i - 1].QuestionGroupId;
                    }

                    if (i > 0 && i < m - 1)
                    {
                        nextId = temp[i + 1].QuestionGroupId;
                        backId = temp[i - 1].QuestionGroupId;
                    }
                }
            }

            nav.PreGroup = backId;
            nav.NextGroup = nextId;
            return nav;
        }
    }
}