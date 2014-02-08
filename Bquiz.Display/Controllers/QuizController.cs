using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;

using Bquiz.Display.Helpers;
using Bquiz.Display.Models;
using BquizDB.Entities;
using BquizDB.Business;

namespace Bquiz.Display.Controllers
{
    public class QuizController : Controller
    {
        private bool IsValidPart7(string part7Info)
        {
            List<string> data = part7Info.Split(',').ToList();
            int count = 0;
            foreach (var item in data)
            {
                count += Convert.ToInt32(item);
            }

            if (count == 28)
                return true;
            else
                return false;
        }

        public ActionResult Publishing(Guid quizId, Guid testId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            var group = bl_group.GetByQuizId(quizId).First();

            return Redirect(string.Format("/group/run?groupId={0}&testId={1}", group.QuestionGroupId, testId));
        }

        //public ActionResult Editting(Guid quizId)
        //{
        //    var group = db.bq_QuestionGroup_GetByQuiz(quizId, 1).Take(1).Single();
        //    var part = db.bq_Part_GetById(1).Single();

        //    return Redirect(string.Format("/{0}?groupId={1}", part.EdittingUrl, group.QuestionGroupId));
        //}

        //public ActionResult Delete(Guid quizId)
        //{
        //    if (db.bq_Quiz_GetById(quizId).Single().UserId == (Guid)Membership.GetUser().ProviderUserKey)
        //    {
        //        db.bq_Quiz_Delete(quizId);
        //    }

        //    return Redirect("/");
        //}

        //public ActionResult EdittingNav(Guid groupId)
        //{
        //    return View();
        //}

        //
        // GET: /Quiz/

        public ActionResult Index()
        {
            bl_Quiz bl_quiz = new bl_Quiz();
            var quiz = bl_quiz.GetByStatus(0);
            return View(quiz);
        }

        [Authorize]
        public ActionResult New()
        {
            var quiz = new bq_Quiz();
            return View(quiz);
        }

        [HttpPost]
        public ActionResult New(bq_Quiz quiz)
        {
            var url = Request["imagesname"];
            byte numberGroup = Convert.ToByte(Request["no"]); // lay request tu id= no
            var Itemlist = new List<byte>();

            for (var i = 0; i < numberGroup; i++)
            {
                Itemlist.Add(Convert.ToByte((Request["num" + (i + 1).ToString()])));
            }
            if (ModelState.IsValid)
            {
                bl_Quiz bl_quiz = new bl_Quiz();

                var quizId = bl_quiz.Create(
                    ps_Membership.GetUser().UserId,
                    Request["QuizTitle"],
                    null, url);

                //Bq_HauController.NewPart1(quizId);
                //Bq_HauController.NewPart2(quizId);

                //Bq_AnController.NewPart3(quizId);
                //Bq_AnController.NewPart4(quizId);

                //Bq_TienController.NewPart5(quizId);
                //Bq_TienController.NewPart6(quizId);

                //Bq_TuCuongController.NewPart7(quizId, numberGroup, Itemlist);
                //Bq_TuCuongController.NewPart8(quizId);

                return Redirect("/quiz");
            }
            else
            {
                return Redirect("/quiz");
            }
        }

        public ActionResult Create()
        {
            Session["photos-upload"] = new List<string>();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ps_NewQuiz model)
        {
            //get image upload name
            List<string> listImage = (List<string>)Session["photos-upload"];
            var centerIcon = (listImage.Count > 0) ? listImage.First() : null;

            if (centerIcon != null && ModelState.IsValid && IsValidPart7(model.Part7Info))
            {
                bl_Quiz blquiz = new bl_Quiz();
                var id = blquiz.Create2(
                    ps_Membership.GetUser().UserId,
                    model.Quiz.Name,
                    model.Quiz.EnglishCenter,
                    centerIcon,
                    model.Quiz.EnglishCenterDescription);

                blquiz.CreateQuiz2(id, model.Part7Info);
                return Redirect("/quiz/manage");
            }

            return View(model);
        }

        public ActionResult Update(Guid quizId)
        {
            Session["photos-upload"] = new List<string>();

            bl_Quiz bl_quiz = new bl_Quiz();
            var model = bl_quiz.GetById(quizId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(bq_Quiz model)
        {
            //get image upload name
            List<string> listImage = (List<string>)Session["photos-upload"];
            var centerIcon = (listImage.Count > 0) ? listImage.First() : model.EnglishCenterIcon;

            if (centerIcon != null && ModelState.IsValid)
            {
                bl_Quiz blquiz = new bl_Quiz();
                var id = blquiz.Update2(
                    model.QuizId,
                    model.Name,
                    model.EnglishCenter,
                    centerIcon,
                    model.EnglishCenterDescription);

                return Redirect("/quiz/manage");
            }

            return View(model);
        }

        public ActionResult Manage()
        {
            bl_Quiz bl_Quiz = new bl_Quiz();
            var model = bl_Quiz.GetByUserId(ps_Membership.GetUser().UserId);

            return View(model);
        }

        public ActionResult Result(Guid testId)
        {
            bl_Test blTest = new bl_Test();
            bl_Quiz blQuiz = new bl_Quiz();
            bl_Answer blAnswer = new bl_Answer();
            ps_Result model = new ps_Result();

            model.AnswerList = blAnswer
                .GetByTestId(testId)
                .OrderBy(m => m.bq_Question.Order)
                .ToList();

            var test = blTest.GetById(testId);
            var quiz = blQuiz.GetById(test.QuizId);

            model.TestModel = test;
            model.QuizModel = quiz;
            return View(model);
        }

        public ActionResult Approval()
        {
            bl_Quiz blQuiz = new bl_Quiz();
            var quizList = blQuiz.GetByStatus(e_QuizStatus.Pending);

            return View(quizList);
        }

        public ActionResult Accept(Guid quizId)
        {
            bl_Quiz blQuiz = new bl_Quiz();
            blQuiz.UpdateStatus(quizId, e_QuizStatus.Approval);

            return View();
        }
    }
}
