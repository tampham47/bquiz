using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Entities;

namespace BquizDB.Business
{
    public class e_QuizStatus
    {
        public const int Avaiable = 0;
        public const int UnAvaiable = 1;
    }

    public class bl_Quiz
    {
        BquizEntities db = new BquizEntities();
        public bl_Quiz(BquizEntities connection = null)
        {
            if (connection != null)
            {
                db = connection;
            }
        }

        public Guid Create(Guid userId, string name, string financeCompany, string companyIcon)
        {
            var quizId = Guid.NewGuid();
            var result = db.qz_Quiz_Create(
                quizId,
                userId,
                name, financeCompany, companyIcon).Single();

            if (result > 0)
                return quizId;
            else
                return Guid.Empty;
        }
        public Guid Create2(Nullable<System.Guid> userId, string name, string englishCenter, string englishCenterIcon, string englishCenterDescription)
        {
            var quizId = Guid.NewGuid();
            var result = db.qz_Quiz_Create2(
                quizId, userId, name, 
                englishCenter, 
                englishCenterIcon, 
                englishCenterDescription).Single();

            if (result > 0)
                return quizId;
            else
                return Guid.Empty;
        }
        public int Detele(Guid quizId)
        {
            var result = (int)db.qz_Quiz_Delete(quizId).Single();
            return result;
        }

        public int Update(Guid quizId, string name, string financeCompany, string companyIcon)
        {
            var result = (int)db.qz_Quiz_Update(
                quizId, name,
                financeCompany, companyIcon).Single();

            return result;
        }
        public int UpdateCompanyIcon(Guid quizId, string companyIcon)
        {
            var result = (int)db.qz_Quiz_UpdateCompanyIcon(
                quizId,
                companyIcon).Single();

            return result;
        }
        public int UpdateNumberOfTesting(Guid quizId)
        {
            var result = (int)db.qz_Quiz_UpdateNumberOfTesting(quizId).Single();

            return result;
        }
        public int UpdateStatus(Guid quizId, byte? status)
        {
            if (!status.HasValue)
                status = 0;

            var result = (int)db.qz_Quiz_UpdateStatus(quizId, status).Single();

            return result;
        }

        public bq_Quiz GetById(Guid quizId)
        {
            var result = db.qz_Quiz_GetById(quizId).ToList();
            if (result.Count > 0)
                return result.First();
            else
                return null;
        }
        public List<bq_Quiz> GetByUserId(Guid userId)
        {
            var result = db.qz_Quiz_GetByUserId(userId).ToList();
            return result;
        }
        public List<bq_Quiz> GetByStatus(int? status)
        {
            if (!status.HasValue)
                status = 0;

            var result = db.qz_Quiz_GetByStatus(status).ToList();

            return result;
        }

        private int NewPart1(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

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
                        groupId,
                        quizId, //phải trả về đúng với group id phía trên
                        (byte)(1 + i * 5 + ord),
                        null, null, null, null, null, null, null, 0);
                }
            }

            return 0;
        }
        private int NewPart2(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

            for (byte i = 0; i < 6; i++)
            {
                //4 pairs of reading texts with 5 questions per pair
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
                        groupId,
                        quizId,
                        (byte)(11 + i * 5 + ord),
                        null, null, null, null, null, null, null, 0);
                }

            }

            return 0;
        }
        private int NewPart3(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

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
                        groupId,
                        quizId,
                        (byte)(s + ord + 1),
                        null, null, null, null, null, null, null, 0);
                }

            }
            return 0;
        }
        private int NewPart4(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

            for (byte i = 0; i < 10; i++)
            {
                Int32 s = 70 + i * 3;

                //4 pairs of reading texts with 10 questions per pair
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
                        groupId,
                        quizId,
                        (byte)(s + ord + 1),
                        null, null, null, null, null, null, null, 0);
                }

            }
            return 0;
        }
        private int NewPart5(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

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
            return 0;
        }
        private int NewPart6(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

            for (byte i = 0; i < 3; i++)
            {
                //3 pairs of reading texts with 4 questions per pair
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
                        groupId,
                        quizId,
                        (byte)(141 + i * 4 + ord),
                        null, null, null, null, null, null, null, 0);
                }
            }

            return 0;
        }
        private int NewPart7(Guid quizId, int numberOfGroup, List<int> itemList)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

            int tmp = 0;
            for (byte i = 0; i < itemList.Count; i++)
            {
                //4 pairs of reading texts with 5 questions per pair
                var groupId = bl_group.Create(
                    quizId,
                    7, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part7.{0}-{1}", 153 + tmp, 153 + tmp + itemList[i] - 1),
                    i,
                    null, null);

                for (byte ord = 0; ord < itemList[i]; ord++)
                {
                    bl_question.Create(
                        groupId,
                        quizId,
                        (byte)(153 + tmp + ord), //đúng thứ tự câu hỏi trong một bộ quiz
                        null, null, null, null, null, null, null, 0);
                }

                tmp += itemList[i];
            }

            return 0;
        }
        private int NewPart8(Guid quizId)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup(db);
            bl_Question bl_question = new bl_Question(db);

            for (byte i = 0; i < 4; i++)
            {
                //4 pairs of reading texts with 5 questions per pair
                var groupId =bl_group.Create(
                    quizId,
                    8, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part8.{0}-{1}", 181 + i * 5, 185 + i * 5),
                    i,
                    null, null);

                //Create 5 question each a group
                for (byte ord = 0; ord < 5; ord++)
                {
                    bl_question.Create(
                        groupId,
                        quizId,
                        (byte)(181 + i * 5 + ord), //đúng thứ tự câu hỏi trong một bộ quiz
                        null, null, null, null, null, null, null, 0);
                }

            }

            return 0;
        }

        public int NewQuiz(Guid quizId, int numberOfGroup, List<int> itemList)
        {
            int result = 0;
            result += NewPart1(quizId);
            result += NewPart2(quizId);
            result += NewPart3(quizId);
            result += NewPart4(quizId);
            result += NewPart5(quizId);
            result += NewPart6(quizId);
            result += NewPart7(quizId, numberOfGroup, itemList);
            result += NewPart8(quizId);

            if (result == 0)
                return 0;
            else
                return -1;
        }
        public int CreateQuiz(Guid userId, string name, string financeCompany, string companyIcon, int numberOfGroup, List<int> itemList)
        {
            var quizId = Create(userId, name, financeCompany, companyIcon);
            NewQuiz(quizId, numberOfGroup, itemList);

            return 0;
        }
        public int CreateQuiz2(Guid quizId, string part7Info)
        {
            List<string> data = part7Info.Split(',').ToList();
            List<int> part7 = new List<int>();
            foreach (var item in data)
            {
                part7.Add(Convert.ToInt32(item));
            }

            NewQuiz(quizId, part7.Count, part7);
            return 0;
        }
    }
}

