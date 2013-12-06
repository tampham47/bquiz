using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Bquiz.Display.Helpers;
using BquizDB.Entities;
using BquizDB.Business;
using Bquiz.Display.Models;

namespace Bquiz.Display.Controllers
{
    public class GroupController : Controller
    {
        #region UpdateGroup
        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart1(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            //Phải là người tạo mới được sửa
            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part1 = new ps_Group();
                part1.Group = group;
                part1.QuestionList = questionList;

                ViewBag.QuizId = group.QuizId;
                return View(part1);
            }
            else
            {
                return Redirect("/");
            }
        }
        [HttpPost]
        public ActionResult UpdatePart1(ps_Group part1)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            bl_group.Update(
                part1.Group.QuestionGroupId,
                part1.Group.Paragraph);

            if (ModelState.IsValid)
            {
                foreach (var question in part1.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                part1.Group = bl_group.GetById(part1.Group.QuestionGroupId);
                ViewBag.QuizId = part1.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part1.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part1.QuestionList = questionList;

                return View(part1);
            }
            else
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở
                part1.Group = bl_group.GetById(part1.Group.QuestionGroupId);
                ViewBag.QuizId = part1.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part1.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part1.QuestionList = questionList;

                return View(part1);
            }
        }

        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart2(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part2 = new ps_Group();
                part2.Group = group;
                part2.QuestionList = questionList;

                ViewBag.QuizId = group.QuizId;
                return View(part2);
            }
            else return Redirect("/");
        }
        [HttpPost]
        public ActionResult UpdatePart2(ps_Group part2)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            bl_group.Update(
                part2.Group.QuestionGroupId,
                part2.Group.Paragraph);

            if (ModelState.IsValid)
            {
                foreach (var question in part2.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                part2.Group = bl_group.GetById(part2.Group.QuestionGroupId);
                ViewBag.QuizId = part2.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part2.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part2.QuestionList = questionList;

                return View(part2);
            }
            else
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở
                part2.Group = bl_group.GetById(part2.Group.QuestionGroupId);
                ViewBag.QuizId = part2.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part2.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part2.QuestionList = questionList;

                return View(part2);
            }
        }

        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart3(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part3 = new ps_Group();
                part3.Group = group;
                part3.QuestionList = questionList;

                //db.bq_QuestionGroup_UpdateMediaPath(groupId,null);
                ViewBag.QuestionGroupId = groupId;
                ViewBag.QuizId = group.QuizId;
                return View(part3);
            }
            else
            {
                return Redirect("/");
            }

        }
        //Xử lý từ phía Client Part3
        [HttpPost]
        public ActionResult UpdatePart3(ps_Group part3)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (ModelState.IsValid)
            {
                bl_group.Update(
                    part3.Group.QuestionGroupId,
                    part3.Group.Paragraph);

                foreach (var question in part3.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                part3.Group = bl_group.GetById(part3.Group.QuestionGroupId);
                ViewBag.QuizId = part3.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part3.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part3.QuestionList = questionList;

                //Trả về trang chủ
                return View(part3);
            }
            else
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở
                part3.Group = bl_group.GetById(part3.Group.QuestionGroupId);
                ViewBag.QuizId = part3.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part3.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part3.QuestionList = questionList;

                return View(part3);
            }
        }

        //Update Part4
        [Authorize]
        public ActionResult UpdatePart4(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part4 = new ps_Group();
                part4.Group = group;
                part4.QuestionList = questionList;

                ViewBag.QuestionGroupId = groupId;
                ViewBag.QuizId = group.QuizId;
                return View(part4);
            }
            else
            {
                return Redirect("/");
            }
        }
        //Xử lý từ phía Client Part4
        [HttpPost]
        public ActionResult UpdatePart4(ps_Group part4)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (ModelState.IsValid)
            {
                bl_group.Update(
                    part4.Group.QuestionGroupId,
                    part4.Group.Paragraph);

                foreach (var question in part4.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                part4.Group = bl_group.GetById(part4.Group.QuestionGroupId);
                ViewBag.QuizId = part4.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part4.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part4.QuestionList = questionList;

                //Trả về trang hiện tại
                return View(part4);
            }
            else
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở.
                part4.Group = bl_group.GetById(part4.Group.QuestionGroupId);
                ViewBag.QuizId = part4.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part4.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part4.QuestionList = questionList;

                return View(part4);
            }
        }

        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart5(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            //Phải là người tạo mới được sửa
            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part5 = new ps_Group();
                part5.Group = group;
                part5.QuestionList = questionList;

                ViewBag.QuizId = group.QuizId;
                return View(part5);
            }
            else
            {
                return Redirect("/");
            }
        }
        //Xử lý dữ liệu từ client
        [HttpPost]
        public ActionResult UpdatePart5(ps_Group part5)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (ModelState.IsValid)
            {
                bl_group.Update(
                    part5.Group.QuestionGroupId,

                    part5.Group.Paragraph
                    );

                foreach (var question in part5.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                part5.Group = bl_group.GetById(part5.Group.QuestionGroupId);
                ViewBag.QuizId = part5.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part5.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part5.QuestionList = questionList;

                return View(part5);
            }
            else
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở
                part5.Group = bl_group.GetById(part5.Group.QuestionGroupId);
                ViewBag.QuizId = part5.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part5.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part5.QuestionList = questionList;

                return View(part5);
            }
        }

        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart6(Guid groupId)
        {
            //Phải là người tạo mới được sửa
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part6 = new ps_Group();
                part6.Group = group;
                part6.QuestionList = questionList;

                ViewBag.QuizId = group.QuizId;
                return View(part6);
            }
            else
            {
                return Redirect("/");
            }
        }
        //Xử lý dữ liệu từ client
        [HttpPost]
        public ActionResult UpdatePart6(ps_Group part6)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (ModelState.IsValid)
            {
                bl_group.Update(
                    part6.Group.QuestionGroupId,
                    part6.Group.Paragraph);

                foreach (var question in part6.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                part6.Group = bl_group.GetById(part6.Group.QuestionGroupId);
                ViewBag.QuizId = part6.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part6.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part6.QuestionList = questionList;

                return View(part6);
            }
            else
            {
                part6.Group = bl_group.GetById(part6.Group.QuestionGroupId);
                ViewBag.QuizId = part6.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part6.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part6.QuestionList = questionList;

                return View(part6);
            }
        }

        //Hiển thị bộ câu hỏi để cập nhật
        [Authorize]
        public ActionResult UpdatePart7(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part7 = new ps_Group();
                part7.Group = group;
                part7.Group.Paragraph = HttpUtility.HtmlDecode(part7.Group.Paragraph);
                part7.QuestionList = questionList;

                ViewBag.QuizId = group.QuizId;
                return View(part7);
            }
            else
            {
                return Redirect("/");
            }
        }
        //Xử lý dữ liệu từ client
        [HttpPost]
        public ActionResult UpdatePart7(ps_Group part7)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            bl_group.Update(
                part7.Group.QuestionGroupId,
                part7.Group.Paragraph);

            if (ModelState.IsValid)
            {
                foreach (var question in part7.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                //Trả về trang chủ
                part7.Group = bl_group.GetById(part7.Group.QuestionGroupId);
                part7.Group.Paragraph = HttpUtility.HtmlDecode(part7.Group.Paragraph);
                ViewBag.QuizId = part7.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part7.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part7.QuestionList = questionList;

                return View(part7);
            }
            else
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở
                part7.Group = bl_group.GetById(part7.Group.QuestionGroupId);
                part7.Group.Paragraph = HttpUtility.HtmlDecode(part7.Group.Paragraph);
                ViewBag.QuizId = part7.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part7.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part7.QuestionList = questionList;

                return View(part7);
            }
        }

        [Authorize]
        public ActionResult UpdatePart8(Guid groupId)
        {
            //Phải là người tạo mới được sửa
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId == ps_Membership.GetUser().UserId)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part8 = new ps_Group();
                part8.Group = group;
                part8.Group.Paragraph = HttpUtility.HtmlDecode(part8.Group.Paragraph);
                part8.QuestionList = questionList;

                ViewBag.QuizId = group.QuizId;
                return View(part8);
            }
            else
            {
                return Redirect("/");
            }
        }
        //Xử lý dữ liệu từ client
        [HttpPost]
        public ActionResult UpdatePart8(ps_Group part8)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            bl_group.Update(
                part8.Group.QuestionGroupId,
                part8.Group.Paragraph);

            if (ModelState.IsValid)
            {
                foreach (var question in part8.QuestionList)
                {
                    bl_question.Update(
                        question.QuestionId,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                //Trả về trang chủ
                //return Redirect("/");
                part8.Group = bl_group.GetById(part8.Group.QuestionGroupId);
                part8.Group.Paragraph = HttpUtility.HtmlDecode(part8.Group.Paragraph);
                ViewBag.QuizId = part8.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part8.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part8.QuestionList = questionList;

                return View(part8);
            }
            else
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở
                part8.Group = bl_group.GetById(part8.Group.QuestionGroupId);
                part8.Group.Paragraph = HttpUtility.HtmlDecode(part8.Group.Paragraph);
                ViewBag.QuizId = part8.Group.QuizId;

                //chỉnh lại khi request
                var group = bl_group.GetById(part8.Group.QuestionGroupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);
                part8.QuestionList = questionList;
                return View(part8);
            }
        }
        #endregion

        #region Action
        public ActionResult View(Guid groupId, Guid testId)
        {
            bl_Test bl_test = new bl_Test();
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();
            bl_Answer bl_answer = new bl_Answer();

            var test = bl_test.GetById(testId);
            var time = test.StartTime.AddHours(2) - DateTime.Now;
            var group = new ps_Group();
            group.Group = bl_group.GetById(groupId);
            group.Group.Paragraph = HttpUtility.HtmlDecode(group.Group.Paragraph);
            group.QuestionList = bl_question.GetByGroupId(groupId);

            ViewBag.QuizId = group.Group.QuizId;
            ViewBag.GroupId = group.Group.QuestionGroupId;
            ViewBag.TestId = testId;
            ViewBag.TimeLeft = String.Format("{0}h{1}m{2}s", time.Hours, time.Minutes, time.Seconds);
            ViewBag.QuestionDone = bl_answer.GetQuestionDone(testId).Count;
            double Timeab = time.TotalSeconds;
            ViewBag.Time = Timeab;

            return View(group);
        }

        public ActionResult Run(Guid groupId, Guid testId)
        {
            bl_Test bl_test = new bl_Test();
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();
            bl_Answer bl_answer = new bl_Answer();

            var test = bl_test.GetById(testId);
            var time = test.StartTime.AddHours(2) - DateTime.Now;
            var group = new ps_Group();

            group.Group = bl_group.GetById(groupId);
            group.QuizId = group.Group.QuizId;
            group.TestId = testId;

            group.Group.Paragraph = HttpUtility.HtmlDecode(group.Group.Paragraph);
            group.QuestionList = bl_question.GetByGroupId(groupId);
            group.AnswerList = bl_answer.GetByGroupId(groupId, testId);

            return View(group);
        }

        /// <summary>
        /// This is navigation menu
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="testId"></param>
        /// <returns></returns>
        public ActionResult Navigation(Guid quizId, Guid testId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            List<ps_PartViewItem> model = new List<ps_PartViewItem>();

            for (byte i = 1; i <= 8; i++)
            {
                model.Add(new ps_PartViewItem
                {
                    PartName = String.Format("Part{0}", i),
                    TestId = testId,
                    Groups = bl_group.GetByPartId(quizId, i)
                });
            }

            return View("_Navigation", model);
        }

        [HttpPost]
        public bool UpdateAnswer(Guid testId, Guid questionId, byte answer = 0)
        {
            bl_Answer bl_answer = new bl_Answer();
            var result = bl_answer.Update(testId, questionId, answer);

            if (result > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
