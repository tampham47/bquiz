using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BquizDB.Entities;
using BquizDB.Business;
using Bquiz.Display.Helpers;
using Bquiz.Display.Models;

namespace Bquiz.Display.Controllers
{
    public class PartController : Controller
    {
        public ActionResult Index(Guid quizId)
        {
            bl_Part bl_part = new bl_Part();
            var model = bl_part.GetByParentId(0);

            ViewBag.QuizId = quizId;
            return View(model); ;
        }

        public ActionResult EdittingMenu(Guid? quizId)
        {
            if (!quizId.HasValue)
                quizId = Guid.Parse("55A0C125-226C-454D-B8D9-D70E8E75045E");

            bl_Quiz bl_quiz = new bl_Quiz();
            bl_Part bl_part = new bl_Part();

            var quiz = bl_quiz.GetById(quizId.Value);
            var parts = bl_part.GetAllChild();

            //var quiz = db.bq_Quiz_GetById(quizId).Single();
            //var parts = db.bq_Part_GetAllChilds().ToList();

            ViewBag.QuizId = quizId;
            ViewBag.QuizName = quiz.Name;

            return View(parts);
        }

        public ActionResult PublishingMenu(Guid? quizId, Guid testId)
        {
            if (!quizId.HasValue)
                quizId = Guid.Parse("55A0C125-226C-454D-B8D9-D70E8E75045E");

            bl_Quiz bl_quiz = new bl_Quiz();
            bl_Part bl_part = new bl_Part();

            var quiz = bl_quiz.GetById(quizId.Value);
            var parts = bl_part.GetAllChild();

            ViewBag.QuizId = quizId;
            ViewBag.QuizName = quiz.Name;
            ViewBag.TestId = testId;

            return View(parts);
        }

        public ActionResult PublishingMenuResult(Guid? quizId, Guid testId)
        {
            if (!quizId.HasValue)
                quizId = Guid.Parse("55A0C125-226C-454D-B8D9-D70E8E75045E");

            bl_Quiz bl_quiz = new bl_Quiz();
            bl_Part bl_part = new bl_Part();

            var quiz = bl_quiz.GetById(quizId.Value);
            var parts = bl_part.GetAllChild();

            ViewBag.QuizId = quizId;
            ViewBag.QuizName = quiz.Name;
            ViewBag.TestId = testId;

            return View(parts);
        }
    }
}
