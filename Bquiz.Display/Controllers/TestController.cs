using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bquiz.Display.Helpers;
using Bquiz.Display.Models;
using BquizDB.Business;

namespace Bquiz.Display.Controllers
{
    public class TestController : Controller
    {
        [Authorize]
        public ActionResult PreStart(Guid quizId)
        {
            bl_Quiz bl_quiz = new bl_Quiz();

            var model = new ps_PreStartModel();
            model.Quiz = bl_quiz.GetById(quizId);
            model.User = ps_Membership.GetUser();

            return View(model);
        }

        [Authorize]
        public ActionResult Start(Guid quizId)
        {
            bl_Test bl_test = new bl_Test();
            bl_Question bl_question = new bl_Question();
            bl_Answer bl_answer = new bl_Answer();

            var testId = bl_test.Create(ps_Membership.GetUser().UserId, quizId);
            var questionList = bl_question.GetByQuizId(quizId);

            foreach (var item in questionList)
            {
                bl_answer.Modify(
                    testId,
                    item.QuestionId,
                    0);
            }
            
            return RedirectToAction("Publishing", "Quiz", new { quizId = quizId, testId = testId });
        }

        //[HttpGet]
        //public JsonResult Change(Guid testID, Guid questionID, byte answer = 0)
        //{
        //    bl_Test bl_test = new bl_Test();
        //    bl_Answer bl_answer = new bl_Answer();
        //    var test = bl_test.GetById(testID);

        //    var time = test.StartTime.AddHours(2) - DateTime.Now;
        //    double timedb = time.TotalSeconds;
        //    if (timedb > 0)
        //    {
        //        bl_answer.Modify(testID, questionID, answer);

        //        return Json(
        //            new { timedb },
        //            JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(
        //            new { timedb },
        //            JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult _ViewTop10(Guid quizId)
        {
            bl_Test bl_test = new bl_Test();
            var top10 = bl_test.GetTop10(quizId);

            return View(top10);
        }

        public ActionResult Submit(Guid testId)
        {
            bl_Test blTest = new bl_Test();
            var mark = ps_PageHelpers.GetMark(testId);
            blTest.UpdateMark(testId, mark);

            return RedirectToAction("result", new { testId = testId });
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
    }
}
