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
    public class Bq_TuCuongController : Controller
    {
        //Single Passages: 28 questions;
        //7–10 reading texts with 2–5 questions each
        [Authorize]
        public static bool NewPart7(Guid quizId, byte numberOfGroup, List<byte> itemList)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            int tmp = 0;
            for (byte i = 0; i < itemList.Count; i++)
            {
                //4 pairs of reading texts with 5 questions per pair

                var questionGroupId = Guid.NewGuid();
                var groupId=bl_group.Create(
                    quizId,
                    7, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part7.{0}-{1}", 153 + tmp, 153 + tmp + itemList[i] - 1),
                    i,
                    null, null);

                for (byte ord = 0; ord < itemList[i]; ord++)
                {
                    bl_question.Create(
                        groupId, //phải trả về đúng với group id phía trên
                        quizId,
                        (byte)(153 + tmp + ord), //đúng thứ tự câu hỏi trong một bộ quiz
                        null, null, null, null, null, null, null, 0);
                }

                tmp += itemList[i];
            }
            return true;
        }

        //Hiển thị bộ câu hỏi để cập nhật
        [Authorize]
        public ActionResult UpdatePart7(Guid groupId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                (Guid)Membership.GetUser().ProviderUserKey)
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

        //Cái hàm này như là hàm khởi tạo, chỉ chạy 1 lần mỗi khi tạo một quiz mới
        //Nhiệm vụ : Để insert vào database số lượng câu hỏi của từng questionGroup.
        //Sau đó chúng ta sẽ cập nhật lại để đảm bảo tính đúng đắn của bộ câu hỏi.
        //Có thể xem thêm "http://localhost:12347/Bq_TuCuong/UpdatePart8?groupId=c38d171e-524b-466e-b814-be1d78398f7c" 
        //để hiểu nó hoạt động như thế nào
        public static bool NewPart8(Guid quizId) //Tất cả cái add đều phải có một cái quizId
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

                for (byte i = 0; i < 4; i++)
                {
                    //4 pairs of reading texts with 5 questions per pair
                    var groupId = bl_group.Create(
                        quizId,
                        8, //Thay đổi đối với từng part (thứ tự part)
                        String.Format("Part8.{0}-{1}", 181 + i * 5, 185 + i * 5),
                        i,
                        null, null);

                    //Create 5 question each a group
                    for (byte ord = 0; ord < 5; ord++)
                    {
                        bl_question.Create(
                            groupId, //phải trả về đúng với group id phía trên
                            quizId,
                            (byte)(181 + i * 5 + ord), //đúng thứ tự câu hỏi trong một bộ quiz
                            null, null, null, null, null, null, null, 0);
                    }

                }
            return true;
        }

        //Hiển thị bộ câu hỏi để cập nhật
        [Authorize]
        public ActionResult UpdatePart8(Guid groupId)
        {
            //Phải là người tạo mới được sửa
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            if (bl_group.GetById(groupId).bq_Quiz.UserId ==
                (Guid)Membership.GetUser().ProviderUserKey)
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
    }
}
