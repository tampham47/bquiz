using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using BquizDB.Entities;
using BquizDB.Business;
using Bquiz.Display.Models;

namespace Bquiz.Display.Controllers
{
    public class Bq_HauController : Controller
    {
        public static bool NewPart1(Guid? quizId) //Tất cả cái add đều phải có một cái quizId
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            for (byte i = 0; i < 2; i++)
            {
                //4 pairs of reading texts with 5 questions per pair
                var groupId = bl_group.Create(
                    quizId,
                    1, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part1.{0}-{1}", 1 + i * 5, 5 + i * 5),
                    i,
                    null, null);

                //Create 5 question each a group
                for (byte ord = 0; ord < 5; ord++)
                {
                    bl_question.Create(
                        groupId, //phải trả về đúng với group id phía trên
                        quizId,
                        (byte)(1 + i * 5 + ord),
                        null, null, null, null, null, null, null, 0);
                }

            }
            return true;
        }

        /// <summary> part2
        /// part 2
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        public static bool NewPart2(Guid? quizId) //Tất cả cái add đều phải có một cái quizId
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            for (byte i = 0; i < 6; i++)
            {
                //4 pairs of reading texts with 5 questions per pair
                var questionGroupId = Guid.NewGuid();
                var groupId = bl_group.Create(
                    quizId,
                    2, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part2.{0}-{1}", 11 + i * 5, 15 + i * 5),
                    i,
                    null, null);

                //Create 5 question each a group
                for (byte ord = 0; ord < 5; ord++)
                {
                    bl_question.Create(
                        groupId, //phải trả về đúng với group id phía trên
                        quizId,
                        (byte)(11 + i * 5 + ord),
                        null, null, null, null, null, null, null, 0);
                }

            }
            return true;
        }

        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart1(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            //Phải là người tạo mới được sửa
            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                (Guid)Membership.GetUser().ProviderUserKey)
            {
                var group = bl_group.GetById(groupId);
                var questionList = bl_question.GetByGroupId(group.QuestionGroupId);

                ps_Group part1 = new ps_Group();
                part1.Group = group;
                part1.QuestionList = questionList;

                ViewBag.QuizId = group.QuizId;
                return View(part1);
            }
            else {
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

            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                (Guid)Membership.GetUser().ProviderUserKey)
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
    }
}
