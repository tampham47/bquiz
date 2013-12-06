using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;

using BquizDB.Entities;
using BquizDB.Business;
using Bquiz.Display.Models;

namespace Bquiz.Display.Controllers
{
    public class Bq_AnController : Controller
    {
        //
        // GET: /Bq_An/
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public static bool NewPart3(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            for (byte i = 0; i < 10; i++)
            {
                Int32 s = 40 + i * 3;
                //4 pairs of reading texts with 10 questions per pair
                var groupId = bl_group.Create(
                    quizId,
                    3, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part3.{0}-{1}", s + 1, s + 3),
                    i,
                    null, null);

                //Create 3 question each a group
                for (byte ord = 0; ord < 3; ord++)
                {
                    bl_question.Create(
                        groupId, quizId,
                        (byte)(s + ord + 1),
                        null, null, null, null, null, null, null, 0);
                }

            }

            return true;
        }

        [Authorize]
        public static bool NewPart4(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();
            for (byte i = 0; i < 10; i++)
            {
                Int32 s = 70 + i * 3;

                //4 pairs of reading texts with 10 questions per pair
                var questionGroupId = Guid.NewGuid();

                var groupId = bl_group.Create(
                    quizId,
                    4, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part4.{0}-{1}", s + 1, s + 3),
                    i,
                    null, null);

                //Create 3 question each a group
                for (byte ord = 0; ord < 3; ord++)
                {
                    bl_question.Create(
                        groupId, //phải trả về đúng với group id phía trên
                        quizId,
                        (byte)(s + ord + 1),
                        null, null, null, null, null, null, null, 0);
                }

            }

            return true;
        }

        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart3(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                 (Guid)Membership.GetUser().ProviderUserKey)
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

            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                (Guid)Membership.GetUser().ProviderUserKey)
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
    }
}
