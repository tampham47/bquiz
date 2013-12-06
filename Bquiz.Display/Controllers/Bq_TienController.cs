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
    public class Bq_TienController : Controller
    {
        //
        // GET: /Bq_Tien/

        public ActionResult Index()
        {
            return View();
        }
        public static bool NewPart5(Guid quizId) //Tất cả cái add đều phải có một cái quizId
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            for (byte i = 0; i < 8; i++)
            {

                //8 pairs of reading texts with 5 questions per pair
                var groupId = bl_group.Create(
                    quizId,
                    5, //Thay đổi đối với từng part
                    String.Format("Part5.{0}-{1}", 101 + i * 5, 105 + i * 5),
                    i,
                    null, null);

                //Create 5 question each a group
                for (byte ord = 0; ord < 5; ord++)
                {
                    bl_question.Create(
                        groupId,
                        quizId,
                        (byte)(101 + i * 5 + ord),
                        null, null, null, null, null, null, null, 0);
                }

            }
            return true;
        }

        public static bool NewPart6(Guid quizId) //Tất cả cái add đều phải có một cái quizId
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            for (byte i = 0; i < 3; i++)
            {
                //3 pairs of reading texts with 4 questions per pair
                var questionGroupId = Guid.NewGuid();
                var groupId = bl_group.Create(
                    quizId,
                    6, //Thay đổi đối với từng part
                    String.Format("Part6.{0}-{1}", 141 + i * 4, 144 + i * 4),
                    i,
                    null, null);

                //Create 4 question each a group
                for (byte ord = 0; ord < 4; ord++)
                {
                    bl_question.Create(
                        groupId, //phải trả về đúng với group id phía trên
                        quizId,
                        (byte)(141 + i * 4 + ord),
                        null, null, null, null, null, null, null, 0);
                }
            }
            return true;
        }

        //Viết vào cái này nhé
        [Authorize]
        public ActionResult UpdatePart5(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            //Phải là người tạo mới được sửa
            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                (Guid)Membership.GetUser().ProviderUserKey)
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

            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                (Guid)Membership.GetUser().ProviderUserKey)
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

    }
}

