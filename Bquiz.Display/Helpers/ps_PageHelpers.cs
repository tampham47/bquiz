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

        public static int GetMark(Guid testId)
        {
            int mark = 0;
            mark += Helpers.ps_PageHelpers.GetMark_Listen(testId);
            mark += Helpers.ps_PageHelpers.GetMark_Read(testId);

            bl_Test blTest = new bl_Test();
            blTest.UpdateMark(testId, mark);

            return mark;
        }
        public static int GetMark_Listen(Guid testId)
        {
            bl_Answer blAnswer = new bl_Answer();
            var answers = blAnswer.GetByTestId(testId);
            int listen = 0, mark_listen = 0;

            foreach (var item in answers)
            {
                if ((item.bq_Question.Answer != 0) && (item.Answer == item.bq_Question.Answer) && ((item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 1) || (item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 2) ||
                    (item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 3) || (item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 4)))
                {
                    listen++;
                    if (listen < 7)
                        mark_listen = 5;
                    if (listen >= 7)
                    {
                        switch (listen)
                        {
                            case 26:
                                mark_listen = 110;
                                break;
                            case 35:
                                mark_listen = 160;
                                break;
                            case 44:
                                mark_listen = 210;
                                break;
                            case 48:
                                mark_listen = 240;
                                break;
                            case 53:
                                mark_listen = 270;
                                break;
                            case 59:
                                mark_listen = 310;
                                break;
                            case 64:
                                mark_listen = 340;
                                break;
                            case 67:
                                mark_listen = 360;
                                break;
                            case 70:
                                mark_listen = 380;
                                break;
                            case 77:
                                mark_listen = 420;
                                break;
                            case 80:
                                mark_listen = 440;
                                break;
                            case 83:
                                mark_listen = 460;
                                break;
                            case 90:
                                mark_listen = 495;
                                break;
                            case 91:
                                mark_listen = 495;
                                break;
                            case 92:
                                mark_listen = 495;
                                break;
                            case 93:
                                mark_listen = 495;
                                break;
                            case 94:
                                mark_listen = 495;
                                break;
                            case 95:
                                mark_listen = 495;
                                break;
                            case 96:
                                mark_listen = 495;
                                break;
                            case 97:
                                mark_listen = 495;
                                break;
                            case 98:
                                mark_listen = 495;
                                break;
                            case 99:
                                mark_listen = 495;
                                break;
                            case 100:
                                mark_listen = 495;
                                break;
                            default:
                                mark_listen = mark_listen + 5;
                                break;
                        }
                    }
                }
            }

            return mark_listen;
        }
        public static int GetMark_Read(Guid testId)
        {
            bl_Answer blAnswer = new bl_Answer();
            var answers = blAnswer.GetByTestId(testId);
            int read = 0, mark_read = 0;

            foreach (var item in answers)
            {
                if ((item.bq_Question.Answer != 0) && (item.Answer == item.bq_Question.Answer) && ((item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 5) || (item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 6) ||
                    (item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 7) || (item.bq_Question.bq_QuestionGroup.bq_Part.PartId == 8)))
                {
                    read++;
                    if (read < 16)
                        mark_read = 5;
                    if (read >= 16)
                    {
                        switch (read)
                        {
                            case 25:
                                mark_read = 60;
                                break;
                            case 28:
                                mark_read = 80;
                                break;
                            case 33:
                                mark_read = 110;
                                break;
                            case 38:
                                mark_read = 140;
                                break;
                            case 41:
                                mark_read = 160;
                                break;
                            case 46:
                                mark_read = 190;
                                break;
                            case 49:
                                mark_read = 210;
                                break;
                            case 56:
                                mark_read = 250;
                                break;
                            case 61:
                                mark_read = 280;
                                break;
                            case 64:
                                mark_read = 300;
                                break;
                            case 67:
                                mark_read = 320;
                                break;
                            case 72:
                                mark_read = 350;
                                break;
                            case 77:
                                mark_read = 380;
                                break;
                            case 92:
                                mark_read = 465;
                                break;

                            case 98:
                                mark_read = 495;
                                break;
                            case 99:
                                mark_read = 495;
                                break;
                            case 100:
                                mark_read = 495;
                                break;
                            default:
                                mark_read = mark_read + 5;
                                break;
                        }
                    }
                }
            }

            return mark_read;
        }
    }
}