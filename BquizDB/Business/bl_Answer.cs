using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Entities;

namespace BquizDB.Business
{
    public class bl_Answer
    {
        BquizEntities db = new BquizEntities();
        public bl_Answer(BquizEntities connection = null)
        {
            if (connection != null)
            {
                db = connection;
            }
        }

        public int Create(Guid testId, Guid questionId, byte answer)
        {
            var result = (int)db.qz_Answer_Create(
                testId, questionId, answer).Single();

            return result;
        }
        public int Update(Guid testId, Guid questionId, byte answer)
        {
            var result = (int)db.qz_Answer_Update(
                testId, questionId, answer).Single();

            return result;
        }
        public int Modify(Guid testId, Guid questionId, byte answer)
        {
            var result = GetById(testId, questionId);
            if (result != null)
            {
                return Update(testId, questionId, answer);
            }
            else
            {
                return Create(testId, questionId, answer);
            }
        }

        public int DeleteByQuizId(Guid quizId)
        {
            var re = (int)db.qz_Answer_DeleteByQuizId(quizId).Single();
            return re;
        }
        public int DeleteByTestId(Guid testId)
        {
            var re = (int)db.qz_Answer_DeleteByTestId(testId).Single();
            return re;
        }

        public bq_Answer GetById(Guid testId, Guid questionId)
        {
            var result = db.qz_Answer_GetById(testId, questionId).ToList();

            if (result.Count > 0)
                return result.First();
            else
                return null;
        }
        public List<bq_Answer> GetByGroupId(Guid groupId, Guid testId)
        {
            var result = db.qz_Answer_GetByGroupId(groupId, testId)
                .OrderBy(m => m.bq_Question.Order)
                .ToList();

            return result;
        }
        public List<bq_Answer> GetByTestId(Guid testId)
        {
            var result = db.qz_Answer_GetByTestId(testId).ToList();
            return result;
        }
        public List<bq_Answer> GetQuestionDone(Guid testId)
        {
            var result = db.qz_Answer_QuestionDone(testId).ToList();
            return result;
        }

        //for test service
        public bq_Answer TestService()
        {
            var data = new bq_Answer();
            data.Answer = 4;
            data.QuestionId = Guid.NewGuid();
            data.TestId = Guid.NewGuid();
            return data;
        }
    }
}
