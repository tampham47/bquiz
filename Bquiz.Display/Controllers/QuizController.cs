using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;

using Bquiz.Display.Helpers;
using BquizDB.Entities;
using BquizDB.Business;

namespace Bquiz.Display.Controllers
{
    public class QuizController : Controller
    {
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

        public ActionResult Result(Guid testId)
        {
            bl_Answer blAnswer = new bl_Answer();
            var data = blAnswer
                .GetByTestId(testId)
                .OrderBy(m => m.bq_Question.Order)
                .ToList();

            return View(data);
        }
    }
}
